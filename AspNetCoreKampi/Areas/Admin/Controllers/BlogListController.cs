using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace AspNetCoreKampi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogListController : Controller
    {
        private readonly BlogManager _blogManager = new BlogManager(new EfBlogDal());
        public IActionResult Index()
        {
            var model = _blogManager.GetBlogWithCategory();
            return View(model);
        }
    }
}
