using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaCity.Models.ViewModels
{
    public class TipoUbicacionViewModel
    {
        public string TipoUbicacionSeleccionada { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> TiposUbicaciones { get; set; }
    }
}