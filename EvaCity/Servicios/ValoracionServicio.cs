using EvaCity.Models.Entidades;
using EvaCity.Models.Infraestructura.Repositorios;
using EvaCity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace EvaCity.Servicios
{
    public class ValoracionServicio
    {
        private ValoracionRepositorio valoracionRepositorio = new ValoracionRepositorio();
        private UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

        public List<Valoracion> ObtenerTodasValoraciones()
        {
            return valoracionRepositorio.ObtenerTodasValoraciones();
        }

        public IList<Valoracion> ObtenerValoracionesPorProyecto(int idProyecto)
        {
            return valoracionRepositorio.ObtenerValoracionesPorProyecto(idProyecto);
        }

        public IList<Valoracion> ObtenerValoracionesPorUsuario(string idUsuario)
        {
            return valoracionRepositorio.ObtenerValoracionesPorUsuario(idUsuario);
        }

        public bool ExisteValoracionPorProyectoYUsuario(int idProyecto, string idUsuario)
        {
            var valoraciones = ObtenerValoracionesPorUsuario(idUsuario);
            bool existe = false;

            if (valoraciones != null) {
                for (int i = 0; i < valoraciones.Count() && !existe; i++)
                {
                    if (valoraciones[i].ProyectoId == idProyecto)
                    {
                        existe = true;
                        var valoracion = valoraciones[i];
                    }
                }
            }
            return existe;
        }

        public Valoracion ObtenerValoracionPorProyectoYUsuario(int idProyecto, string idUsuario)
        {
            var valoraciones = ObtenerValoracionesPorUsuario(idUsuario);
            bool existe = false;

            if (valoraciones != null)
            {
                for (int i = 0; i < valoraciones.Count() && !existe; i++)
                {
                    if (valoraciones[i].ProyectoId == idProyecto)
                    {
                        existe = true;
                        return valoraciones[i];
                    }
                }
            }
            return null;
        }

        public int ObtenerVotosPositivosPorProyecto(int idProyecto)
        {
            var positivos = 0;
            var valoraciones = ObtenerValoracionesPorProyecto(idProyecto);
            if (valoraciones != null)
            {
                foreach (var valoracion in valoraciones)
                {
                    if (valoracion.Voto == 1)
                    {
                        positivos++;
                    }
                }
            }

            return positivos;
        }

        public int ObtenerVotosNegativosPorProyecto(int idProyecto)
        {
            var negativos = 0;
            var valoraciones = ObtenerValoracionesPorProyecto(idProyecto);
            if (valoraciones != null)
            {
                foreach (var valoracion in valoraciones)
                {
                    if (valoracion.Voto == 0)
                    {
                        negativos++;
                    }
                }
            }

            return negativos;
        }

        public void CrearValoracion(Valoracion valoracion)
        {
            try
            {
                valoracionRepositorio.Insertar(valoracion);
                valoracionRepositorio.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
        }

        public void ActualizarValoracion(Valoracion valoracion)
        {
            valoracionRepositorio.Actualizar(valoracion);
            valoracionRepositorio.SaveChanges();
        }

        public void ValoracionViewModelToModel(Valoracion valoracion, ValoracionViewModel valoracionVM)
        {
            valoracion.Voto = valoracionVM.Voto;
            valoracion.ProyectoId = valoracionVM.ProyectoId;
            valoracion.UsuarioId = usuarioRepositorio.ObtenerUsuarioPorNombre(valoracionVM.Username).Id;
            valoracion.FechaValoracion = DateTime.Now;
        }
    }
}