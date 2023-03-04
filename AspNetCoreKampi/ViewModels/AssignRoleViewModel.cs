using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKampi.ViewModels
{
    public class AssignRoleViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Exists { get; set; }    
    }
}
