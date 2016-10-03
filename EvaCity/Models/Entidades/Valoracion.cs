using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Entidades
{
    public class Valoracion
    {
        public int ValoracionId { get; set; }
        public DateTime FechaValoracion { get; set; }
        public int Voto { get; set; }
        public int TipoValoracion { get; set; }

        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}