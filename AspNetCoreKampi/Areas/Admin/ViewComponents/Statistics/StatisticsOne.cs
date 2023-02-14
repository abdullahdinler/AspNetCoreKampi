using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreKampi.Areas.Admin.ViewComponents.Statistics
{
    public class StatisticsOne:ViewComponent
    {
        private readonly BlogManager _blog = new BlogManager(new EfBlogDal());
        private readonly ContactManager _contact = new ContactManager(new EfContactDal());
        private CommentManager _comment = new(new EfCommentDal()); 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.BlogCount = _blog.GetList().Count;
            ViewBag.ContactCount = _contact.GetList().Count;
            ViewBag.CommentCount = _comment.GetList().Count;
            return View();
        }
    }
}
