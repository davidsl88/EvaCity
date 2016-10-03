using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvaCity.Models.ViewModels
{
    public class SeccionViewModel
    {
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }
    }
}