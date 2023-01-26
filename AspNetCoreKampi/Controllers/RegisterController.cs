using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace AspNetCoreKampi.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AuthorManager _ahm = new AuthorManager(new EfAuthorDal());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Author entity)
        {
            return View();
        }
    }
}
