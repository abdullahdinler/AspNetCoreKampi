using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreKampi.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreKampi.Controllers
{
    
    public class DashboardController : Controller
    {
        private readonly BlogManager _blog = new BlogManager(new EfBlogDal());
        private readonly CategoryManager _category = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var authorMail = User.Identity?.Name;
            var values = AuthorId.Id(authorMail);
            ViewBag.BlogCount = _blog.TotalBlog().ToString();
            ViewBag.AuthorBlogTotal = _blog.AuthorTotalBlog(values.Id).ToString();
            ViewBag.CategoryCount = _category.TotalCategory().ToString();
            ViewData["CurrentUser"] = values;
            return View();
        }
    }
}
