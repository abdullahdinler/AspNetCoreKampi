using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace AspNetCoreKampi.ViewModels
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lütfen role adını giriniz.")]
        public string Name { get; set; }
    }
}
