using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvaCity.Models.ViewModels
{
    public class UbicacionViewModel
    {
        public string Direccion { get; set; }
        public string TipoUbicacionSeleccionada { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> TiposUbicaciones { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        public string NombreCiudad { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string TipoUbicacion { get; set; }
        public string NombreEmpresa { get; set; }
        public string Url { get; set; }
        public int UbicacionId { get; set; }
    }
}