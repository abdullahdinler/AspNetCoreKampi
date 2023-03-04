using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKampi.ViewModels
{
    public class AppRoleUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen role ismini giriniz.")]
        public string Name { get; set; }
    }
}
