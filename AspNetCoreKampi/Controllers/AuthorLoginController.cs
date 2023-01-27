using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKampi.Controllers
{
    public class AuthorLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
