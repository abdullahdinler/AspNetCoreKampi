using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreKampi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
