using System.Collections.Generic;

namespace EvaCity.Models.Entidades
{
    public class Ciudad
    {
        public int CiudadId { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
        public virtual ICollection<Ubicacion> Ubicaciones { get; set; }
    }
}