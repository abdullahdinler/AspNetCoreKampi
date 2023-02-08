using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreKampi.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreKampi.ViewComponents.Author
{
    public class AuthorWithBlogList : ViewComponent
    {
        private readonly BlogManager _bm = new BlogManager(new EfBlogDal());

        public IViewComponentResult Invoke()
        {
            var authorMail = User.Identity?.Name;
            var values = AuthorId.Id(authorMail);
            var result = _bm.GetBlogWithAuthor(values.Id);
            return View(result);
        }
    }
}
