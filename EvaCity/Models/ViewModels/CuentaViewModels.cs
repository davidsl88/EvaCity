using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EvaCity.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El Email introducido no es válido.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña introducida no es válida.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Recuérdame")]
        public bool RememberMe { get; set; }
    }

    public class RegistroViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "La {0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre de usuario")]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar password")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Administracion Pública")]
        public bool Perfil { get; set; }

        [Required]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Ciudad")]
        public string CiudadSeleccionada { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Ciudades { get; set; }
    }
}
