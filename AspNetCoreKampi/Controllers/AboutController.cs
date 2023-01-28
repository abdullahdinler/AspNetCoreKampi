using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace AspNetCoreKampi.Controllers
{
    public class AboutController : Controller
    {
        private readonly AboutManager _abm = new AboutManager(new EfAboutDal());
        public IActionResult Index()
        {
            var values = _abm.GetList().FirstOrDefault();
            return View(values);
        }
    }
}
