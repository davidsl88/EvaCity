using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.ViewModels
{
    public class InformacionViewModel
    {
        public IList<ProyectoViewModel> proyectosViewModel { get; set; }
        public IList<UbicacionViewModel> ubicacionesViewModel { get; set; }
        public IList<CiudadViewModel> ciudadesViewModel { get; set; }
        public UsuarioViewModel usuarioViewModel { get; set; }
    }
}