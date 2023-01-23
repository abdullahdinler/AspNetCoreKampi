using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace AspNetCoreKampi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var result = _cm.GetList();
            return View(result);
        }
    }
}
