using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
namespace AspNetCoreKampi.ViewComponents.Comment
{
    public class AddComment:ViewComponent
    {
        [HttpGet]
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
