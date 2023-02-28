using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKampi.ViewModels
{
    public class ProfileUpdateViewModel
    {
        public string userName { get; set; }
        public string nameSurname { get; set; }
        public string mail { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }

    }
}
