using EvaCity.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Infraestructura.Repositorios
{
    public class UbicacionRepositorio : Repositorio<Ubicacion>
    {
        public List<Ubicacion> ObtenerTodasUbicaciones()
        {
            return GetAll();
        }

        public IList<Ubicacion> ObtenerEmpresas(int idCiudad)
        {
            return dbSet.Where(v => v.CiudadId == idCiudad && (v.TipoUbicacion.Nombre == "Empresa Sostenible" || v.TipoUbicacion.Nombre == "Alquiler de Vehículos Sostenibles")).ToList();
        }

        public IList<Ubicacion> ObtenerTodasEmpresas()
        {
            return dbSet.Where(v => v.TipoUbicacion.Nombre == "Empresa Sostenible" || v.TipoUbicacion.Nombre == "Alquiler de Vehículos Sostenibles").ToList();
        }

        public IList<Ubicacion> ObtenerUbicacionesPorCiudad(int idCiudad)
        {
            return dbSet.Where(v => v.CiudadId == idCiudad).ToList();
        }

        public IList<Ubicacion> ObtenerUbicacionesPorUsuario(string idUsuario)
        {
            return dbSet.Where(v => v.UsuarioId == idUsuario).ToList();
        }
    }
}