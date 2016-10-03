using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Entidades
{
    public class TipoUbicacion
    {
        public int TipoUbicacionId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Ubicacion> Ubicaciones { get; set; }
    }
}