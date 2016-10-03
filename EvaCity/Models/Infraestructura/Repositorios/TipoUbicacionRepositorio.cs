using EvaCity.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Infraestructura.Repositorios
{
    public class TipoUbicacionRepositorio : Repositorio<TipoUbicacion>
    {
        public List<TipoUbicacion> ObtenerTodosTipoUbicacion()
        {
            return GetAll();
        }

        public TipoUbicacion ObtenerTipoUbicacionPorNombre(string nombreTipoUbicacion)
        {
            return dbSet.Where(a => a.Nombre == nombreTipoUbicacion).FirstOrDefault();
        }

        public TipoUbicacion ObtenerTipoUbicacionPorId(int idTipoUbicacion)
        {
            return dbSet.Where(a => a.TipoUbicacionId == idTipoUbicacion).FirstOrDefault();
        }
    }
}