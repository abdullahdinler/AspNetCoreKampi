using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreKampi.ViewComponents.Author
{
    public class AuthorNotification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
