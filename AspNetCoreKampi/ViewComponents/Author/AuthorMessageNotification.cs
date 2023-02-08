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
    public class AuthorMessageNotification:ViewComponent
    {
        private readonly MessageManager _message = new(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            var authorMail = User.Identity?.Name;
            var values = AuthorId.Id(authorMail);
            var message = _message.GetByAuthorMessage(values.Id);
            return View(message);
        }
    }
}
