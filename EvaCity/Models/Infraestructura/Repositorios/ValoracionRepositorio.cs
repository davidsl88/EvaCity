using EvaCity.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Infraestructura.Repositorios
{
    public class ValoracionRepositorio : Repositorio<Valoracion>
    {
        public List<Valoracion> ObtenerTodasValoraciones()
        {
            return GetAll();
        }

        public IList<Valoracion> ObtenerValoracionesPorProyecto(int idProyecto) {
            return dbSet.Where(v => v.ProyectoId == idProyecto).ToList();
        }

        public IList<Valoracion> ObtenerValoracionesPorUsuario(string idUsuario)
        {
            return dbSet.Where(v => v.UsuarioId == idUsuario).ToList();
        }
    }
}