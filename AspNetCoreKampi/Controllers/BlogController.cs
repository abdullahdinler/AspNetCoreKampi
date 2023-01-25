using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace AspNetCoreKampi.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogManager _bm = new BlogManager(new EfBlogDal());
        public IActionResult Index()
        {
            var result = _bm.GetBlogWithCategory();
            return View(result);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var result = _bm.GetBlogWithCategory(id);
            return View(result);
        }
    }
}
