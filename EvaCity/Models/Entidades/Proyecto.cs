using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Entidades
{
    public class Proyecto
    {
        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
        
        public int SeccionId { get; set; }
        public virtual Seccion Seccion { get; set; }

        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }

        //public int EstadoId { get; set; }
        //public virtual Estado Estado { get; set; }

        public virtual IList<Valoracion> Valoraciones { get; set; }
    }
}