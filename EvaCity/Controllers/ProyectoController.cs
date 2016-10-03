using EvaCity.Models.Entidades;
using EvaCity.Models.ViewModels;
using EvaCity.Servicios;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvaCity.Controllers
{
    public class ProyectoController : Controller
    {
        private ProyectoServicio proyectoServicio = new ProyectoServicio();
        private CiudadServicio ciudadServicio = new CiudadServicio();
        private SeccionServicio seccionServicio = new SeccionServicio();
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private ValoracionServicio valoracionServicio = new ValoracionServicio();
        private TipoUbicacionServicio tipoUbicacionServicio = new TipoUbicacionServicio();
        private UbicacionServicio ubicacionServicio = new UbicacionServicio();

        private ApplicationUserManager _userManager;

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

        // GET: Proyecto
        public ActionResult Index()
        {
            return View();
        }

        //Listado de proyectos
        public ActionResult Informacion(int seccion, string ciudad)
        {
            if (System.Web.HttpContext.Current.Session != null)
            {
                System.Web.HttpContext.Current.Session["idSeccion"] = seccion;
            }

            //Tipo de seccion
            if (seccion == 1)
            {
                ViewBag.Seccion = "Contaminacion";
            }
            else if (seccion == 2)
            {
                ViewBag.Seccion = "Energías Renovables";
            }
            else if (seccion == 3)
            {
                ViewBag.Seccion = "Reciclaje";
            }
            else if (seccion == 4)
            {
                ViewBag.Seccion = "Movilidad Sostenible";
            }
            else if (seccion == 5)
            {
                ViewBag.Seccion = "Negocios Sostenibles";
            }

            IList<Proyecto> listadoProyectos = new List<Proyecto>();
            IList<Ubicacion> listadoEmpresas = new List<Ubicacion>();
            IList<Ciudad> listadoCiudades = new List<Ciudad>();

            InformacionViewModel infoVM = new InformacionViewModel();
            UsuarioViewModel usuarioVM = new UsuarioViewModel();

            if (User.Identity.GetUserId() != null)
            {
                usuarioVM.CiudadUsuario = ciudadServicio.ObtenerCiudadPorId(usuarioServicio.ObtenerIdCiudadUsuario(User.Identity.GetUserId())).Nombre;
                infoVM.usuarioViewModel = usuarioVM;
            }

            infoVM.proyectosViewModel = new List<ProyectoViewModel>();
            infoVM.ubicacionesViewModel = new List<UbicacionViewModel>();
            infoVM.ciudadesViewModel = new List<CiudadViewModel>();

            if (ciudad != null)
            {
                listadoProyectos = proyectoServicio.ObtenerProyectosPorSeccionYCiudad(seccion, ciudadServicio.ObtenerCiudadPorNombre(ciudad).CiudadId);
                listadoEmpresas = ubicacionServicio.ObtenerEmpresas(ciudad);
            }
            else
            {
                listadoProyectos = proyectoServicio.ObtenerProyectosPorSeccion(seccion);
                listadoEmpresas = ubicacionServicio.ObtenerTodasEmpresas();
            }

            foreach (var proyecto in listadoProyectos)
            {
                ProyectoViewModel proyectoVM = new ProyectoViewModel();
                proyectoServicio.ProyectoModelToViewModel(proyectoVM, proyecto);
                if (usuarioServicio.ObtenerUsuarioPorNombre(proyectoVM.NombreUsuario).Id == User.Identity.GetUserId()) {
                    proyectoVM.Editable = true;
                }
                if (UserManager.IsInRole(usuarioServicio.ObtenerUsuarioPorNombre(proyectoVM.NombreUsuario).Id, "Administracion Publica")) {
                    proyectoVM.EsAP = true;
                }
                infoVM.proyectosViewModel.Add(proyectoVM);
            }
            foreach (var empresa in listadoEmpresas)
            {
                UbicacionViewModel empresaVM = new UbicacionViewModel();
                ubicacionServicio.UbicacionModelToViewModel(empresaVM, empresa);
                infoVM.ubicacionesViewModel.Add(empresaVM);
            }

            listadoCiudades = ciudadServicio.ObtenerTodasCiudades();

            foreach (var ciudadModel in listadoCiudades)
            {
                CiudadViewModel ciudadVM = new CiudadViewModel();
                ciudadVM.Proyectos = proyectoServicio.ObtenerProyectosPorSeccionYCiudad(seccion, ciudadModel.CiudadId);
                ciudadServicio.CiudadModelToViewModel(ciudadVM, ciudadModel);
                infoVM.ciudadesViewModel.Add(ciudadVM);
            }
            var ciudades = infoVM.ciudadesViewModel.OrderByDescending(v => v.Valoracion).ToList();
            infoVM.ciudadesViewModel = ciudades;

            var todosTiposUbicaciones = tipoUbicacionServicio.ObtenerTodosTipoUbicacion();
            var factorOptions = todosTiposUbicaciones.Select(tiposUbicaciones => new SelectListItem { Text = tiposUbicaciones.Nombre, Value = tiposUbicaciones.TipoUbicacionId.ToString() }).ToList();

            var tuple = new Tuple<InformacionViewModel, TipoUbicacionViewModel>(infoVM, new TipoUbicacionViewModel { TiposUbicaciones = factorOptions });

            return View(tuple);
        }
        public ActionResult ActualizarRanking(SeccionViewModel seccionVM) {
            InformacionViewModel infoVM = new InformacionViewModel();
            IList<Ciudad> listadoCiudades = new List<Ciudad>();

            infoVM.ciudadesViewModel = new List<CiudadViewModel>();
            listadoCiudades = ciudadServicio.ObtenerTodasCiudades();

            foreach (var ciudadModel in listadoCiudades)
            {
                CiudadViewModel ciudadVM = new CiudadViewModel();
                ciudadVM.Proyectos = proyectoServicio.ObtenerProyectosPorSeccionYCiudad(Int32.Parse(System.Web.HttpContext.Current.Session["idSeccion"].ToString()), ciudadModel.CiudadId);
                ciudadServicio.CiudadModelToViewModel(ciudadVM, ciudadModel);
                infoVM.ciudadesViewModel.Add(ciudadVM);
            }
            var ciudades = infoVM.ciudadesViewModel.OrderByDescending(v => v.Valoracion).ThenByDescending(c => c.VotosTotales).ToList();
            infoVM.ciudadesViewModel = ciudades;

            UsuarioViewModel usuarioVM = new UsuarioViewModel();

            if (User.Identity.GetUserId() != null)
            {
                usuarioVM.CiudadUsuario = ciudadServicio.ObtenerCiudadPorId(usuarioServicio.ObtenerIdCiudadUsuario(User.Identity.GetUserId())).Nombre;
                infoVM.usuarioViewModel = usuarioVM;
            }

            return Json(infoVM);
        }

        public ActionResult BuscarProyectosAP(ProyectoViewModel model)
        {
            //System.Web.HttpContext.Current.Session["idSeccion"] =;

            IList<Proyecto> listadoProyectos = new List<Proyecto>();

            listadoProyectos = proyectoServicio.ObtenerProyectosAP();
            //if (ciudad != null)
            //{
            //    listadoProyectos = proyectoServicio.ObtenerProyectosPorSeccionYCiudad(seccion, ciudadServicio.ObtenerCiudadPorNombre(ciudad).CiudadId);
            //}
            //else
            //{
            //    listadoProyectos = proyectoServicio.ObtenerProyectosPorSeccion(seccion);
            //}

            IList<ProyectoViewModel> listaViewProyecto = new List<ProyectoViewModel>();

            foreach (var proyecto in listadoProyectos)
            {
                ProyectoViewModel proyectoVM = new ProyectoViewModel();
                proyectoServicio.ProyectoModelToViewModel(proyectoVM, proyecto);
                listaViewProyecto.Add(proyectoVM);
            }


            var todosTiposUbicaciones = tipoUbicacionServicio.ObtenerTodosTipoUbicacion();
            var factorOptions = todosTiposUbicaciones.Select(tiposUbicaciones => new SelectListItem { Text = tiposUbicaciones.Nombre, Value = tiposUbicaciones.TipoUbicacionId.ToString() }).ToList();

            var tuple = new Tuple<IList<ProyectoViewModel>, UbicacionViewModel>(listaViewProyecto, new UbicacionViewModel { TiposUbicaciones = factorOptions });

            //return View(tuple);
            return RedirectToAction("Informacion", new { seccion = System.Web.HttpContext.Current.Session["idSeccion"] });
        }

        // GET: /Proyecto/NuevoProyecto
        public ActionResult NuevoProyecto()
        {
            var todasCiudades = ciudadServicio.ObtenerTodasCiudades();
            var ciudadesModel = todasCiudades.Select(ciudades => new SelectListItem { Text = ciudades.Nombre, Value = ciudades.CiudadId.ToString() }).ToList();
            return View(new ProyectoViewModel { Ciudades = ciudadesModel });
        }

        // POST: /Proyecto/NuevoProyecto
        [HttpPost()]
        public ActionResult NuevoProyecto(ProyectoViewModel proyectoVM)
        {
            if (!ModelState.IsValid)
                return View(proyectoVM);

            Proyecto proyecto = new Proyecto();

            proyecto.Nombre = proyectoVM.Nombre;
            proyecto.Descripcion = proyectoVM.Descripcion;
            proyecto.CiudadId = ciudadServicio.ObtenerCiudadPorId(Int32.Parse(proyectoVM.CiudadSeleccionada)).CiudadId;
            proyecto.FechaCreacion = DateTime.Now;
            proyecto.FechaModificacion = DateTime.Now;
            proyecto.SeccionId = (int)System.Web.HttpContext.Current.Session["idSeccion"];
            proyecto.UsuarioId = User.Identity.GetUserId();
            
            var ciudadActual = "";
            if (System.Web.HttpContext.Current.Session["ciudad"] != null)
            {
                ciudadActual = System.Web.HttpContext.Current.Session["ciudad"].ToString();
            }

            proyectoServicio.CrearProyecto(proyecto);

            return RedirectToAction("Informacion", new { seccion = System.Web.HttpContext.Current.Session["idSeccion"], ciudad = ciudadActual });
        }

        public ActionResult EditarProyecto(int id)
        {
            var proyecto = proyectoServicio.ObtenerProyectoPorId(id);
            ProyectoViewModel proyectoVM = new ProyectoViewModel();
            proyectoServicio.ProyectoModelToViewModel(proyectoVM, proyecto);

            var todasCiudades = ciudadServicio.ObtenerTodasCiudades();
            var ciudadesModel = todasCiudades.Select(ciudades => new SelectListItem { Text = ciudades.Nombre, Value = ciudades.CiudadId.ToString() }).ToList();

            var todasSecciones = seccionServicio.ObtenerTodasSecciones();
            var seccionesModel = todasSecciones.Select(secciones => new SelectListItem { Text = secciones.Nombre, Value = secciones.SeccionId.ToString() }).ToList();

            proyectoVM.Ciudades = ciudadesModel;
            proyectoVM.CiudadSeleccionada = proyectoVM.NombreCiudad;

            proyectoVM.Secciones = seccionesModel;
            proyectoVM.SeccionSeleccionada = proyectoVM.NombreSeccion;

            if (proyecto == null)
                return HttpNotFound();
            else
                return View(proyectoVM);
        }

        [HttpPost()]
        public ActionResult EditarProyecto(ProyectoViewModel proyectoVM)
        {
            if (!ModelState.IsValid) return View(proyectoVM);

            try
            {
                Proyecto proyecto = new Proyecto();
                proyectoServicio.ProyectoViewModelToModel(proyecto, proyectoVM);
                proyecto.FechaModificacion = DateTime.Now;

                proyectoServicio.ActualizarProyecto(proyecto);

                var ciudadActual = "";
                if (System.Web.HttpContext.Current.Session["ciudad"] != null) {
                    ciudadActual = System.Web.HttpContext.Current.Session["ciudad"].ToString();
                }

                return RedirectToAction("Informacion", new { seccion = System.Web.HttpContext.Current.Session["idSeccion"], ciudad = ciudadActual });
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                return View(proyectoVM);
            }
        }

        public ActionResult Detalles(int idProyecto)
        {
            Proyecto proyecto = proyectoServicio.ObtenerProyectoPorId(idProyecto);
            ProyectoViewModel proyectoVM = new ProyectoViewModel();

            proyectoServicio.ProyectoModelToViewModel(proyectoVM, proyecto);
            if (usuarioServicio.ObtenerUsuarioPorNombre(proyectoVM.NombreUsuario).Id == User.Identity.GetUserId())
            {
                proyectoVM.Editable = true;
            }
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(proyectoVM);
            }
        }

        public ActionResult EliminarProyecto(int idProyecto)
        {
            proyectoServicio.EliminarProyecto(idProyecto);

            var ciudadActual = "";
            if (System.Web.HttpContext.Current.Session["ciudad"] != null)
            {
                ciudadActual = System.Web.HttpContext.Current.Session["ciudad"].ToString();
            }

            return RedirectToAction("Informacion", new { seccion = System.Web.HttpContext.Current.Session["idSeccion"], ciudad = ciudadActual });
        }

        public ActionResult EliminarUbicacion(int idUbicacion)
        {
            ubicacionServicio.EliminarUbicacion(idUbicacion);
            return RedirectToAction("Informacion", new { seccion = System.Web.HttpContext.Current.Session["idSeccion"] });
        }

        public ActionResult InsertarValoracion(ValoracionViewModel valoracionVM) {
            if (valoracionVM.Username != null)
            {
                Valoracion valoracion = valoracionServicio.ObtenerValoracionPorProyectoYUsuario(valoracionVM.ProyectoId, usuarioServicio.ObtenerUsuarioPorNombre(valoracionVM.Username).Id);
                valoracionVM.Votado = false;

                if (valoracion == null)
                {
                    valoracion = new Valoracion();
                    valoracionServicio.ValoracionViewModelToModel(valoracion, valoracionVM);
                    valoracionServicio.CrearValoracion(valoracion);

                    valoracionVM.VotosTotalesPositivos = valoracionServicio.ObtenerVotosPositivosPorProyecto(valoracion.ProyectoId);
                    valoracionVM.VotosTotalesNegativos = valoracionServicio.ObtenerVotosNegativosPorProyecto(valoracion.ProyectoId);
                    valoracionVM.Votado = true;
                }
                else {
                    if (valoracionVM.Voto == 1 && valoracion.Voto == 0)
                    {
                        valoracion.Voto = 1;
                        valoracionServicio.ActualizarValoracion(valoracion);
                        valoracionVM.VotosTotalesPositivos = valoracionServicio.ObtenerVotosPositivosPorProyecto(valoracion.ProyectoId);
                        valoracionVM.VotosTotalesNegativos = valoracionServicio.ObtenerVotosNegativosPorProyecto(valoracion.ProyectoId);
                        valoracionVM.Votado = true;
                    }
                    else if (valoracionVM.Voto == 0 && valoracion.Voto == 1)
                    {
                        valoracion.Voto = 0;
                        valoracionServicio.ActualizarValoracion(valoracion);
                        valoracionVM.VotosTotalesNegativos = valoracionServicio.ObtenerVotosNegativosPorProyecto(valoracion.ProyectoId);
                        valoracionVM.VotosTotalesPositivos = valoracionServicio.ObtenerVotosPositivosPorProyecto(valoracion.ProyectoId);
                        valoracionVM.Votado = true;
                    }
                    else {
                        valoracionVM.VotosTotalesNegativos = valoracionServicio.ObtenerVotosNegativosPorProyecto(valoracion.ProyectoId);
                        valoracionVM.VotosTotalesPositivos = valoracionServicio.ObtenerVotosPositivosPorProyecto(valoracion.ProyectoId);
                    }
                }
            }
            else {
                return View();
            }

            return Json(valoracionVM);
        }
        
        protected override void Dispose(bool disposing)
        {
            proyectoServicio.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}