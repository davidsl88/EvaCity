using EvaCity.Models.Entidades;
using EvaCity.Models.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Servicios
{
    public class SeccionServicio
    {
        private SeccionRepositorio seccionRepositorio = new SeccionRepositorio();

        public Seccion ObtenerSeccionPorNombre(string nombreSeccion)
        {
            return seccionRepositorio.ObtenerSeccionPorNombre(nombreSeccion);
        }

        public Seccion ObtenerSeccionPorId(int idSeccion)
        {
            return seccionRepositorio.ObtenerSeccionPorId(idSeccion);
        }

        public ICollection<Seccion> ObtenerTodasSecciones()
        {
            return seccionRepositorio.ObtenerTodasSecciones();
        }
    }
}