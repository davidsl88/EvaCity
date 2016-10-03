using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Infraestructura.Repositorios
{
    public class PerfilRepositorio : Repositorio<IdentityRole>
    {
        public IList<IdentityRole> ObtenerTodosPerfiles() {
            return GetAll();
        }

        public IdentityRole ObtenerPerfilPorId(string idPerfil)
        {
            return dbSet.Where(x => x.Id == idPerfil).FirstOrDefault();
        }
    }
}