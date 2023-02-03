using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreKampi.ViewComponents.Dashboard
{
    public class DashboardBlogList:ViewComponent
    {
        private readonly BlogManager _bm = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke()
        {
            var blogList = _bm.GetBlogWithCategory().Where(x=>x.AuthorId == 3).OrderByDescending(x => x.Id).Take(5).ToList();
            return View(blogList);
        }
    }
}
