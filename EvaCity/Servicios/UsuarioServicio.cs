using EvaCity.Models;
using EvaCity.Models.Entidades;
using EvaCity.Models.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;

namespace EvaCity.Servicios
{
    public class UsuarioServicio
    {
        private UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

        public IList<ApplicationUser> ObtenerTodosUsuarios()
        {
            return usuarioRepositorio.ObtenerTodosUsuarios();
        }

        public ApplicationUser ObtenerUsuarioPorId(string idUsuario)
        {
            return usuarioRepositorio.ObtenerUsuarioPorId(idUsuario);
        }

        public ApplicationUser ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            return usuarioRepositorio.ObtenerUsuarioPorNombre(nombreUsuario);
        }

        public int ObtenerIdCiudadUsuario(string idUsuario)
        {
            return usuarioRepositorio.ObtenerIdCiudadUsuario(idUsuario);
        }

        public void EliminarUsuario(string idUsuario)
        {
            usuarioRepositorio.Eliminar(idUsuario);
            usuarioRepositorio.SaveChanges();
        }

        public void ActualizarUsuario(ApplicationUser usuario)
        {
            usuarioRepositorio.Actualizar(usuario);
            usuarioRepositorio.SaveChanges();
        }
    }
}