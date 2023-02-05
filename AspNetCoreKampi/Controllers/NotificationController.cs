using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreKampi.Controllers
{
    [AllowAnonymous]
    public class NotificationController : Controller
    {
        private readonly NotificationManager _notification = new NotificationManager(new EfNotificationDal());
        public IActionResult Index()
        {
            var values = _notification.GetList();
            return View(values);
        }
    }
}
