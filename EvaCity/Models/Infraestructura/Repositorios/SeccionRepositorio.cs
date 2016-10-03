using EvaCity.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Infraestructura.Repositorios
{
    public class SeccionRepositorio : Repositorio<Seccion>
    {
        public ICollection<Seccion> ObtenerTodasSecciones()
        {
            return GetAll();
        }

        public Seccion ObtenerSeccionPorId(int idSeccion)
        {
            return dbSet.Where(a => a.SeccionId.Equals(idSeccion)).FirstOrDefault();
        }

        public Seccion ObtenerSeccionPorNombre(string nombreSeccion)
        {
            return dbSet.Where(a => a.Nombre.Contains(nombreSeccion)).FirstOrDefault();
        }
    }
}