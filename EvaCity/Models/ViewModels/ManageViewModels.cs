using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using EvaCity.Models.Entidades;
using EvaCity.Models.ViewModels;

namespace EvaCity.Models
{
    public class MenuViewModel
    {
        public ApplicationUser Usuario { get; set; }
        public Proyecto Proyecto { get; set; }
        public Seccion Seccion { get; set; }
        public Ciudad Ciudad { get; set; }
    }

    public class IndexViewModel
    {
        public bool TienePassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string Telefono { get; set; }
        public string Perfil { get; set; }
        public string PerfilSeleccionado { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Perfiles { get; set; }
        public bool TwoFactor { get; set; }
        public bool RecordarNavegador { get; set; }
        public IList<ApplicationUser> Usuarios { get; set; }
        public ApplicationUser DatosPersonales { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }
        public ICollection<Seccion> Secciones { get; set; }
        public ICollection<Ciudad> Ciudades { get; set; }
        public ICollection<UbicacionViewModel> Ubicaciones { get; set; }

        public CambiarPasswordViewModel CambiarPassword { get; set; }
    }

    public class CambiarPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string ActualPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NuevaPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nueva contraseña")]
        [System.ComponentModel.DataAnnotations.Compare("NuevaPassword", ErrorMessage = "La nueva contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmarPassword { get; set; }
    }
}