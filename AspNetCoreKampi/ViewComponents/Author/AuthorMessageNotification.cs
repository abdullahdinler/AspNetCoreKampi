using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreKampi.ViewComponents.Author
{
    public class AuthorMessageNotification:ViewComponent
    {
        private readonly MessageManager _message = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            const int id = 3;
            var values = _message.GetByAuthorMessage(id);
            return View(values);
        }
    }
}
