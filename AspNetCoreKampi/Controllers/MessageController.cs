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
    [Authorize]
    public class MessageController : Controller
    {
        private readonly MessageManager _message = new(new EfMessageDal());

        public IActionResult InBox()
        {
            var authorMail = User.Identity?.Name;
            var values = AuthorId.Id(authorMail);
            ViewData["CurrentUser"] = values;
            var message = _message.GetByAuthorMessage(values.Id);
            return View(message);
        }


        public IActionResult MessageDetail(int id)
        {
            var authorMail = User.Identity?.Name;
            var values = AuthorId.Id(authorMail);
            ViewData["CurrentUser"] = values;
            var result = _message.GetById(id);
            return View(result);
        }
    }
}
