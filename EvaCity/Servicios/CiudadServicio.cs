using EvaCity.Models.Entidades;
using EvaCity.Models.Infraestructura.Repositorios;
using EvaCity.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace EvaCity.Servicios
{
    public class CiudadServicio
    {
        private CiudadRepositorio ciudadRepositorio = new CiudadRepositorio();
        private ValoracionServicio valoracionServicio = new ValoracionServicio();

        public Ciudad ObtenerCiudadPorNombre(string nombreCiudad) {
            return ciudadRepositorio.ObtenerCiudadPorNombre(nombreCiudad);
        }

        public Ciudad ObtenerCiudadPorId(int idCiudad)
        {
            return ciudadRepositorio.ObtenerCiudadPorId(idCiudad);
        }

        public IList<Ciudad> ObtenerTodasCiudades()
        {
            return ciudadRepositorio.ObtenerTodasCiudades();
        }

        public void CiudadModelToViewModel(CiudadViewModel ciudadVM, Ciudad ciudad)
        {
            ciudadVM.Nombre = ciudad.Nombre;
            ciudadVM.Pais = ciudad.Pais;
            ciudadVM.VotosTotales = 0;
            ciudadVM.VotosPositivos = 0;
            ciudadVM.VotosNegativos = 0;

            foreach (var proyecto in ciudadVM.Proyectos)
            {
                ciudadVM.VotosPositivos += valoracionServicio.ObtenerVotosPositivosPorProyecto(proyecto.ProyectoId);
                ciudadVM.VotosNegativos += valoracionServicio.ObtenerVotosNegativosPorProyecto(proyecto.ProyectoId);
                ciudadVM.VotosTotales += ciudadVM.VotosPositivos + ciudadVM.VotosNegativos;
            }
            try
            {
                ciudadVM.Valoracion = ciudadVM.VotosPositivos * 100 / ciudadVM.VotosTotales;
            }
            catch (Exception ex)
            {
                ciudadVM.Valoracion = 0;
            }
        }
    }
}