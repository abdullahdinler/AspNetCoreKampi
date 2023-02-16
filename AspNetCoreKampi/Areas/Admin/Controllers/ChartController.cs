using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreKampi.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreKampi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            var list = new List<Category>
            {
                new Category {name  = "Teknoloji", count = 5},
                new Category {name = "Yazılım", count = 7},
                new Category{name = "Seyhat", count = 2},
                new Category{name = "Film", count = 11}
            };

            return Json(new {jsonList = list});

        }

    }
}
