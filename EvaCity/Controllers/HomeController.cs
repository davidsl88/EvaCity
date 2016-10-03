using EvaCity.Models.ViewModels;
using EvaCity.Servicios;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EvaCity.Controllers
{
    public class HomeController : Controller
    {
        private ProyectoServicio proyectoServicio = new ProyectoServicio();

        public ActionResult Index()
        {
            var listaProyectos = proyectoServicio.ObtenerUltimosProyectos(5);

            IList<ProyectoViewModel> listaProyectosVM = new List<ProyectoViewModel>();

            foreach (var proyecto in listaProyectos)
            {
                ProyectoViewModel proyectoVM = new ProyectoViewModel();
                proyectoServicio.ProyectoModelToViewModel(proyectoVM, proyecto);
                listaProyectosVM.Add(proyectoVM);
            }

            return View(listaProyectosVM);
        }
    }
}