using System.Collections.Generic;
using System.Linq;

namespace EvaCity.Models.Infraestructura.Repositorios
{
    public class UsuarioRepositorio : Repositorio<ApplicationUser>
    {
        public IList<ApplicationUser> ObtenerTodosUsuarios() {
            return GetAll();
        }

        public ApplicationUser ObtenerUsuarioPorId(string idUsuario)
        {
            return dbSet.Where(a => a.Id == idUsuario).FirstOrDefault();
        }

        public ApplicationUser ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            return dbSet.Where(a => a.UserName.Contains(nombreUsuario)).FirstOrDefault();
        }

        public int ObtenerIdCiudadUsuario(string idUsuario)
        {
            return dbSet.Where(a => a.Id == idUsuario).FirstOrDefault().CiudadId;
        }
    }
}