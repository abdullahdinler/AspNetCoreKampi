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
            var model = _manager.GetByAuthorMessage(user.Id);
            return View(model);
        }

        [HttpGet]
        public IActionResult NewMessage()
        {
            // Burada tuple kullanarak hem mesaj sınıfını hemde appuser sınıfını model olarak gonderdik
            var model = Tuple.Create<MessageTwo, AppUser>(new MessageTwo(), new AppUser());
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> NewMessage([Bind(Prefix = "item1")] MessageTwo message,
            [Bind(Prefix = "item2")] AppUser appUser)
        {
            if (User.Identity == null) return View();
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiver = await _userManager.FindByNameAsync(appUser.Email);
            message.SenderId = sender.Id;
            message.ReceiverId = receiver.Id;
            message.MessageDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.Status = true;
            _manager.Add(message);
            return RedirectToAction("InBox");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int[] ids)
        {
            foreach (var id in ids)
            {
                var message = _manager.GetById(id);
                _manager.Delete(message);
            }
            return RedirectToAction(nameof(InBox));
        }

        
    }
}
