using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var values = _author.GetList(3);
            return View(values);
        }

    }
}
