using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreKampi.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace AspNetCoreKampi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriter = JsonConvert.SerializeObject(Writers);
            return Json(jsonWriter);
        }

        public static List<Writer> Writers = new()
        {
            new Writer {Id = 1, Name = "Abdullah"},
            new Writer {Id = 2, Name = "Furkan"},
            new Writer {Id = 3, Name = "Hakan"},
            new Writer {Id = 4, Name = "Kaan"}
        };

    }
}
