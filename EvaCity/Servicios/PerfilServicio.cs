using EvaCity.Models.Infraestructura.Repositorios;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Servicios
{
    public class PerfilServicio
    {
        private PerfilRepositorio perfilRepositorio = new PerfilRepositorio();

        public IList<IdentityRole> ObtenerTodosPerfiles() {
            return perfilRepositorio.ObtenerTodosPerfiles();
        }

        public IdentityRole ObtenerPerfilPorId(string idPerfil)
        {
            return perfilRepositorio.ObtenerPerfilPorId(idPerfil);
        }


    }
}