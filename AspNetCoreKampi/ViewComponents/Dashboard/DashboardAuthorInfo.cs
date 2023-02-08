using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreKampi.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreKampi.ViewComponents.Dashboard
{
    public class DashboardAuthorInfo:ViewComponent
    {
        private readonly AuthorManager _author = new AuthorManager(new EfAuthorDal());
        public IViewComponentResult Invoke()
        {
            var authorMail = User.Identity?.Name;
            var values = AuthorId.Id(authorMail);
            var result = _author.GetList(values.Id);
            return View(result);
        }

    }
}
