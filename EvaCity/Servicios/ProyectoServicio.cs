using EvaCity.Models.Entidades;
using EvaCity.Models.Infraestructura.Repositorios;
using EvaCity.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace EvaCity.Servicios
{
    public class ProyectoServicio
    {
        private ProyectoRepositorio proyectoRepositorio = new ProyectoRepositorio();
        private SeccionRepositorio seccionRepositorio = new SeccionRepositorio();
        private UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        private CiudadRepositorio ciudadRepositorio = new CiudadRepositorio();
        private ValoracionRepositorio valoracionRepositorio = new ValoracionRepositorio();
        private SeccionServicio seccionServicio = new SeccionServicio();
        private ValoracionServicio valoracionServicio = new ValoracionServicio();

        public List<Proyecto> ObtenerTodosProyectos()
        {
            var listaProyectos = proyectoRepositorio.ObtenerTodosProyectos();
            foreach (var proyecto in listaProyectos)
            {
                proyecto.Ciudad = ciudadRepositorio.ObtenerCiudadPorId(proyecto.CiudadId);
                proyecto.Usuario = usuarioRepositorio.ObtenerUsuarioPorId(proyecto.UsuarioId);
                proyecto.Seccion = seccionRepositorio.ObtenerSeccionPorId(proyecto.SeccionId);
                proyecto.Valoraciones = valoracionRepositorio.ObtenerValoracionesPorProyecto(proyecto.ProyectoId);
            }

            return listaProyectos;
        }

        public IList<Proyecto> ObtenerProyectosPorSeccion(int idSeccion)
        {
            var listadoProyectos = proyectoRepositorio.ObtenerProyectosPorSeccion(idSeccion);
            foreach (var proyecto in listadoProyectos) {
                proyecto.Seccion = seccionRepositorio.ObtenerSeccionPorId(idSeccion);
                proyecto.Usuario = usuarioRepositorio.ObtenerUsuarioPorId(proyecto.UsuarioId);
                proyecto.Ciudad = ciudadRepositorio.ObtenerCiudadPorId(proyecto.CiudadId);
                proyecto.Valoraciones = valoracionRepositorio.ObtenerValoracionesPorProyecto(proyecto.ProyectoId);
            }

            return listadoProyectos;
        }

        public List<Proyecto> ObtenerProyectosPorSeccionYCiudad(int idSeccion, int idCiudad)
        {
            return proyectoRepositorio.ObtenerProyectosPorSeccionYCiudad(idSeccion, idCiudad);
        }

        public List<Proyecto> ObtenerProyectosPorCiudad(int idCiudad)
        {
            return proyectoRepositorio.ObtenerProyectosPorCiudad(idCiudad);
        }

        public Proyecto ObtenerProyectoPorId(int idProyecto) {
            var proyecto = proyectoRepositorio.Get(idProyecto);
            proyecto.Seccion = seccionRepositorio.ObtenerSeccionPorId(proyecto.SeccionId);
            proyecto.Usuario = usuarioRepositorio.ObtenerUsuarioPorId(proyecto.UsuarioId);
            proyecto.Ciudad = ciudadRepositorio.ObtenerCiudadPorId(proyecto.CiudadId);
            proyecto.Valoraciones = valoracionRepositorio.ObtenerValoracionesPorProyecto(proyecto.ProyectoId);

            return proyecto;
        }

        public List<Proyecto> ObtenerProyectosAP()
        {
            return proyectoRepositorio.ObtenerProyectosAP();
        }

        public IList<Proyecto> ObtenerProyectosPorUsuario(string idUsuario)
        {
            var listadoProyectos = proyectoRepositorio.ObtenerProyectosPorUsuario(idUsuario);
            foreach (var proyecto in listadoProyectos)
            {
                proyecto.Seccion = seccionRepositorio.ObtenerSeccionPorId(proyecto.SeccionId);
                proyecto.Usuario = usuarioRepositorio.ObtenerUsuarioPorId(proyecto.UsuarioId);
                proyecto.Ciudad = ciudadRepositorio.ObtenerCiudadPorId(proyecto.CiudadId);
                proyecto.Valoraciones = valoracionRepositorio.ObtenerValoracionesPorProyecto(proyecto.ProyectoId);
            }

            return listadoProyectos;
        }

        public List<Proyecto> ObtenerUltimosProyectos(int numProyectos)
        {
            return proyectoRepositorio.ObtenerUltimosProyectos(numProyectos);
        }

        public void CrearProyecto(Proyecto proyecto)
        {
            proyectoRepositorio.Insertar(proyecto);
            proyectoRepositorio.SaveChanges();
        }

        public void ActualizarProyecto(Proyecto proyecto)
        {
            proyectoRepositorio.Actualizar(proyecto);
            proyectoRepositorio.SaveChanges();
        }

        public void EliminarProyecto(int idProyecto)
        {
            proyectoRepositorio.Eliminar(idProyecto);
            proyectoRepositorio.SaveChanges();
        }

        public void ProyectoModelToViewModel(ProyectoViewModel proyectoVM, Proyecto proyecto)
        {
            proyectoVM.ProyectoId = proyecto.ProyectoId;
            proyectoVM.Descripcion = proyecto.Descripcion;
            proyectoVM.Nombre = proyecto.Nombre;
            proyectoVM.FechaCreacion = proyecto.FechaCreacion;
            proyectoVM.FechaModificacion = proyecto.FechaModificacion;
            proyectoVM.NombreSeccion = seccionRepositorio.ObtenerSeccionPorId(proyecto.SeccionId).Nombre;
            proyectoVM.NombreUsuario = usuarioRepositorio.ObtenerUsuarioPorId(proyecto.UsuarioId).UserName;
            proyectoVM.NombreCiudad = ciudadRepositorio.ObtenerCiudadPorId(proyecto.CiudadId).Nombre;
            proyectoVM.VotosPositivos = valoracionServicio.ObtenerVotosPositivosPorProyecto(proyecto.ProyectoId);
            proyectoVM.VotosNegativos = valoracionServicio.ObtenerVotosNegativosPorProyecto(proyecto.ProyectoId);
        }

        public void ProyectoViewModelToModel(Proyecto proyecto, ProyectoViewModel proyectoVM)
        {
            proyecto.CiudadId = ciudadRepositorio.ObtenerCiudadPorId(Int32.Parse(proyectoVM.CiudadSeleccionada)).CiudadId;
            proyecto.ProyectoId = proyectoVM.ProyectoId;
            proyecto.Descripcion = proyectoVM.Descripcion;
            proyecto.FechaCreacion = DateTime.Now;
            proyecto.FechaModificacion = DateTime.Now;
            proyecto.Nombre = proyectoVM.Nombre;
            proyecto.SeccionId = seccionServicio.ObtenerSeccionPorId(Int32.Parse(proyectoVM.SeccionSeleccionada)).SeccionId;
            proyecto.UsuarioId = usuarioRepositorio.ObtenerUsuarioPorNombre(proyectoVM.NombreUsuario).Id;
        }

        public void Dispose(bool disposing)
        {
            proyectoRepositorio.Dispose();
        }
    }
}