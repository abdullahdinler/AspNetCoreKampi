using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreKampi.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class MessagesController : Controller
    {
        private readonly MessageManager _manager = new MessageManager(new EfMessageDal());
        private readonly UserManager<AppUser> _userManager;

        public MessagesController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> InBox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            if (user == null) return View();
            var userId = await _userManager.GetUserIdAsync(user);
          var model =  _manager.GetByAuthorMessage(int.Parse(userId));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> NewMessage()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> NewMessage(MessageTwo message)
        {
            return View();
        }
    }
}
