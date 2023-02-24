using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKampi.ViewModels
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        public string Password { get; set; }
    }
}
