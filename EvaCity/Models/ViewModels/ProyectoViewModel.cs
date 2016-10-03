using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EvaCity.Models.ViewModels
{
    public class ProyectoViewModel
    {
        [Required(ErrorMessage = "Introduce un nombre para el proyecto.")]
        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Introduce una descripción para el proyecto.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Fecha de modificación")]
        public DateTime FechaModificacion { get; set; }

        //[Required(ErrorMessage = "Introduce un usuario.")]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Sección")]
        public string NombreSeccion { get; set; }

        [Display(Name = "Sección")]
        public string SeccionSeleccionada { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Secciones { get; set; }

        public int ProyectoId { get; set; }

        [Display(Name = "Ciudad")]
        public string NombreCiudad { get; set; }

        [Display(Name = "Ciudad")]
        public string CiudadSeleccionada { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Ciudades { get; set; }

        public int VotosPositivos { get; set; }

        public int VotosNegativos { get; set; }

        public bool Editable { get; set; }
        public bool EsAP { get; set; }
    }
}