using EvaCity.Models.Entidades;
using EvaCity.Models.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Servicios
{
    public class TipoUbicacionServicio
    {
        private TipoUbicacionRepositorio tipoUbicacionRepositorio = new TipoUbicacionRepositorio();

        public ICollection<TipoUbicacion> ObtenerTodosTipoUbicacion()
        {
            return tipoUbicacionRepositorio.ObtenerTodosTipoUbicacion();
        }

        public TipoUbicacion ObtenerTipoUbicacionPorNombre(string nombreTipoUbicacion)
        {
            return tipoUbicacionRepositorio.ObtenerTipoUbicacionPorNombre(nombreTipoUbicacion);
        }

        public TipoUbicacion ObtenerTipoUbicacionPorId(int idTipoUbicacion)
        {
            return tipoUbicacionRepositorio.ObtenerTipoUbicacionPorId(idTipoUbicacion);
        }
    }
}