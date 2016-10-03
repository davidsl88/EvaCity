using EvaCity.Models.Entidades;
using EvaCity.Models.ViewModels;
using EvaCity.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvaCity.Controllers
{
    public class UbicacionController : Controller
    {
        private UbicacionServicio ubicacionServicio = new UbicacionServicio();
        private CiudadServicio ciudadServicio = new CiudadServicio();
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private TipoUbicacionServicio tipoUbicacionServicio = new TipoUbicacionServicio();

        public ActionResult InsertarUbicacion(UbicacionViewModel ubicacionVM)
        {
            if (ubicacionVM.Direccion != null)
            {
                Ubicacion ubicacion = new Ubicacion();
                ubicacionServicio.UbicacionViewModelToModel(ubicacion, ubicacionVM);
                //ubicacion.EstadoId = 2;
                ubicacionServicio.CrearUbicacion(ubicacion);
            }
            return Json(ubicacionVM);
        }

        public ActionResult EliminarUbicacion(int idUbicacion)
        {
            ubicacionServicio.EliminarUbicacion(idUbicacion);
            return RedirectToAction("Index", "Configuracion");
        }

        public ActionResult ObtenerUbicaciones(UbicacionViewModel model)
        {
            IList<UbicacionViewModel> ubicacionesVM = new List<UbicacionViewModel>();
            IList<Ubicacion> ubicaciones = new List<Ubicacion>();
            ubicaciones = ubicacionServicio.ObtenerUbicacionesPorCiudad(model.NombreCiudad);
            foreach (var ubicacion in ubicaciones)
            {
                UbicacionViewModel ubicacionVM = new UbicacionViewModel();
                ubicacionServicio.UbicacionModelToViewModel(ubicacionVM, ubicacion);
                ubicacionesVM.Add(ubicacionVM);
            }

            return Json(ubicacionesVM);
        }
    }
}