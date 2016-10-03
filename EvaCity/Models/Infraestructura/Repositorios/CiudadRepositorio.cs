using EvaCity.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Infraestructura.Repositorios
{
    public class CiudadRepositorio : Repositorio<Ciudad>
    {
        public IList<Ciudad> ObtenerTodasCiudades()
        {
            return GetAll().OrderBy(c => c.Nombre).ToList();
        }

        public Ciudad ObtenerCiudadPorId(int idCiudad)
        {
            return dbSet.Where(a => a.CiudadId.Equals(idCiudad)).FirstOrDefault();
        }

        public Ciudad ObtenerCiudadPorNombre(string nombre) {
            return dbSet.Where(a => a.Nombre.Contains(nombre)).FirstOrDefault();
        }
    }
}