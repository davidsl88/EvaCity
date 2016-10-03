using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public string IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Perfil { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string FechaNacimiento { get; set; }
        public string CiudadUsuario { get; set; }
    }
}