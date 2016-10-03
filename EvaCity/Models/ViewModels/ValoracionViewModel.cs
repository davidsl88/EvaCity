using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.ViewModels
{
    public class ValoracionViewModel
    {
        public int Voto { get; set; }
        public int TipoValoracion { get; set; }
        public int VotosTotalesPositivos { get; set; }
        public int VotosTotalesNegativos { get; set; }
        public bool Votado { get; set; }
        public int ProyectoId { get; set; }
        public string Username { get; set; }
    }
}