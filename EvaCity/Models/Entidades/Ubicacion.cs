using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Entidades
{
    public class Ubicacion
    {
        public int UbicacionId { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Direccion { get; set; }
        public string Url { get; set; }
        public string NombreEmpresa { get; set; }

        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }

        public int TipoUbicacionId { get; set; }
        public virtual TipoUbicacion TipoUbicacion { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }

        //public int EstadoId { get; set; }
        //public virtual Estado Estado { get; set; }
    }
}