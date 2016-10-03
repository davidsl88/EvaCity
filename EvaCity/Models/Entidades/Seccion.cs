using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Entidades
{
    public class Seccion
    {
        public int SeccionId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}