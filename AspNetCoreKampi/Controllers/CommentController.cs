using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace AspNetCoreKampi.Controllers
{
    public class CommentController : Controller
    {
        private CommentManager _cm = new(new EfCommentDal());
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        public PartialViewResult ListComment(int id)
        {
            var result = _cm.GetList(id);
            return PartialView(result);
        }
    }
}
