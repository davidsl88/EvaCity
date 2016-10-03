using EvaCity.Models.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EvaCity.Models.ViewModels
{
    public class CiudadViewModel
    {
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Pais")]
        public string Pais { get; set; }
        public int VotosTotales { get; set; }
        public int VotosPositivos { get; set; }
        public int VotosNegativos { get; set; }
        public double Valoracion { get; set; }

        public IList<Proyecto> Proyectos { get; set; }
    }
}