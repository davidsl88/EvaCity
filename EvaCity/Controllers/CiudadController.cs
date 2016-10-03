using EvaCity.Models.Entidades;
using EvaCity.Servicios;
using System.Web.Mvc;

namespace EvaCity.Controllers
{
    public class CiudadController : Controller
    {
        private CiudadServicio ciudadServicio = new CiudadServicio();

        // GET: Ciudad
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuscarCiudad(string nombreCiudad)
        {
            Ciudad ciudad = ciudadServicio.ObtenerCiudadPorNombre(nombreCiudad);
            if (ciudad == null || nombreCiudad == "")
            {
                if (System.Web.HttpContext.Current.Session != null)
                {
                    System.Web.HttpContext.Current.Session["ciudad"] = null;
                }
                return View();
            }
            
            if (System.Web.HttpContext.Current.Session != null)
            {
                System.Web.HttpContext.Current.Session["ciudad"] = ciudad.Nombre;
            }
            return View(ciudad);
        }
    }
}