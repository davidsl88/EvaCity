using EvaCity.Models.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace EvaCity.Models.Infraestructura.Repositorios
{
    public class ProyectoRepositorio : Repositorio<Proyecto>
    {
        public List<Proyecto> ObtenerTodosProyectos()
        {
            return GetAll();
        }

        public List<Proyecto> ObtenerProyectosPorSeccion(int idSeccion)
        {
            return dbSet.Where(a => a.Seccion.SeccionId.Equals(idSeccion)).ToList();
        }

        public List<Proyecto> ObtenerProyectosPorSeccionYCiudad(int idSeccion, int idCiudad)
        {
            return dbSet.Where(a => a.SeccionId == idSeccion && a.CiudadId == idCiudad).ToList();
        }

        public List<Proyecto> ObtenerProyectosPorCiudad(int idCiudad)
        {
            return dbSet.Where(a => a.CiudadId == idCiudad).ToList();
        }

        public List<Proyecto> ObtenerProyectosPorUsuario(string idUsuario)
        {
            return dbSet.Where(a => a.UsuarioId == idUsuario).ToList();
        }

        public List<Proyecto> ObtenerProyectosPorNombre(string nombre)
        {
            return dbSet.Where(a => a.Nombre.Contains(nombre)).ToList();
        }

        public List<Proyecto> ObtenerUltimosProyectos(int numProyectos)
        {
            int maxProyectos = dbSet.Count();

            if (numProyectos > maxProyectos)
                numProyectos = maxProyectos;

            return dbSet.OrderByDescending(p => p.ProyectoId).Take(numProyectos).ToList();
        }

        public List<Proyecto> ObtenerProyectosAP()
        {
            return dbSet.Where(a => a.Usuario.Perfil == "Administracion Publica").ToList();
        }
    }
}