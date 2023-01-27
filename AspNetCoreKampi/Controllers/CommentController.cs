using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace AspNetCoreKampi.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentManager _cm = new(new EfCommentDal());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CommentAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CommentAdd(Comment entity)
        {
            entity.Status = true;
            entity.BlogId = 1;
            entity.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _cm.Add(entity);
            return RedirectToAction("Index", "Blog");
        }
    }
}
