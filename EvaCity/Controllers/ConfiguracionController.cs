using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using EvaCity.Models;
using EvaCity.Models.Infraestructura.Repositorios;
using EvaCity.Models.Entidades;
using System.Reflection;
using EvaCity.Servicios;
using System.Collections.Generic;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using EvaCity.Models.ViewModels;

namespace EvaCity.Controllers
{
    [Authorize]
    public class ConfiguracionController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private ProyectoServicio proyectoServicio = new ProyectoServicio();
        private CiudadServicio ciudadServicio = new CiudadServicio();
        private SeccionServicio seccionServicio = new SeccionServicio();
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private PerfilServicio perfilServicio = new PerfilServicio();
        private UbicacionServicio ubicacionServicio = new UbicacionServicio();

        public ConfiguracionController()
        {
        }

        public ConfiguracionController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Su contraseña ha sido actualizada."
                : message == ManageMessageId.Error ? "Se ha producido un error."
                : "";
            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel();

            model.TienePassword = HasPassword();
            model.Logins = await UserManager.GetLoginsAsync(userId);
            model.RecordarNavegador = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId);

            IList<UbicacionViewModel> listaViewUbicacion = new List<UbicacionViewModel>();
            IList<Ubicacion> ubicaciones = new List<Ubicacion>();

            model.DatosPersonales = UserManager.FindById(userId);
            if (this.User.IsInRole("Administrador"))
            {
                model.Proyectos = proyectoServicio.ObtenerTodosProyectos();
                model.Usuarios = usuarioServicio.ObtenerTodosUsuarios();
                ubicaciones = ubicacionServicio.ObtenerTodasUbicaciones();

                foreach (var ubicacion in ubicaciones) {
                    UbicacionViewModel ubicacionVM = new UbicacionViewModel();
                    ubicacionServicio.UbicacionModelToViewModel(ubicacionVM, ubicacion);
                    listaViewUbicacion.Add(ubicacionVM);
                }

                model.Ubicaciones = listaViewUbicacion;
                foreach (var usuario in model.Usuarios)
                {
                    IList<string> rolesUsuario = UserManager.GetRoles(usuario.Id);
                    usuario.Perfil = rolesUsuario[0];
                }
            }
            else
            {
                model.Proyectos = proyectoServicio.ObtenerProyectosPorUsuario(userId);
                ubicaciones = ubicacionServicio.ObtenerUbicacionesPorUsuario(userId);

                foreach (var ubicacion in ubicaciones)
                {
                    UbicacionViewModel ubicacionVM = new UbicacionViewModel();
                    ubicacionServicio.UbicacionModelToViewModel(ubicacionVM, ubicacion);
                    listaViewUbicacion.Add(ubicacionVM);
                }

                model.Ubicaciones = listaViewUbicacion;
            }

            model.Ciudades = ciudadServicio.ObtenerTodasCiudades();
            model.Secciones = seccionServicio.ObtenerTodasSecciones();

            IList<string> roles = UserManager.GetRoles(model.DatosPersonales.Id);
            model.DatosPersonales.Perfil = roles[0];

            var todosPefiles = perfilServicio.ObtenerTodosPerfiles();
            var listadoPerfiles = todosPefiles.Select(perfiles => new SelectListItem { Text = perfiles.Name, Value = perfiles.Name }).ToList();
            model.Perfiles = listadoPerfiles;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditarUsuario(UsuarioViewModel model)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                ApplicationUser user = new ApplicationUser();
                user = UserManager.FindById(model.IdUsuario);
                if (model.NombreUsuario != null)
                    user.UserName = model.NombreUsuario;
                else if (model.Email != null)
                    user.Email = model.Email;
                else if (model.Telefono != null)
                    user.PhoneNumber = model.Telefono;
                else if (model.FechaNacimiento != null)
                    user.FechaNacimiento = model.FechaNacimiento;
                else if (model.Perfil != null) {
                    var oldRoleId = user.Roles.SingleOrDefault().RoleId;
                    UserManager.RemoveFromRole(user.Id, oldRoleId);
                    UserManager.AddToRole(user.Id, model.Perfil);
                }

                usuarioServicio.ActualizarUsuario(user);

                model.Email = user.Email;
                model.NombreUsuario = user.UserName;
                model.Telefono = user.PhoneNumber;
                model.FechaNacimiento = user.FechaNacimiento;
                
                return Json(model);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                return View();
            }
        }

        public ActionResult EliminarUsuario(string idUsuario)
        {
            if (idUsuario != User.Identity.GetUserId())
            {
                usuarioServicio.EliminarUsuario(idUsuario);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CambiarPassword(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
                //return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.CambiarPassword.ActualPassword, model.CambiarPassword.NuevaPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return RedirectToAction("Index");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

#region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

#endregion
    }
}