using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreKampi.Controllers
{
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        private readonly BlogManager _blog = new BlogManager(new EfBlogDal());
        private readonly CategoryManager _category = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            ViewBag.BlogCount = _blog.TotalBlog().ToString();
            ViewBag.AuthorBlogTotal = _blog.AuthorTotalBlog(3).ToString();
            ViewBag.CategoryCount = _category.TotalCategory().ToString();
            return View();
        }
    }
}
