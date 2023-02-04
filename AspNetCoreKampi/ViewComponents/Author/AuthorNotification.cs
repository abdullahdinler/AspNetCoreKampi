using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreKampi.ViewComponents.Author
{
    public class AuthorNotification:ViewComponent
    {
        private readonly NotificationManager _notification = new NotificationManager(new EfNotificationDal());
        public IViewComponentResult Invoke()
        {
            var values = _notification.GetList().OrderByDescending(x=>x.Id).Take(3);
            return View(values);
        }
    }
}
