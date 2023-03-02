using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreKampi.ViewModels;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreKampi.Controllers
{
    
    public class LoginUserController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
       

        public LoginUserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            
        }

        
        public async Task<IActionResult> LoginGirisSayfasi()
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            ViewBag.User = user;
            ViewBag.Name = user.NameSurname;
            ViewBag.Password = user.PasswordHash;
            var userId = await _userManager.GetUserIdAsync(user);
            ViewBag.UserId = userId;
            return View();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel entity)
        {
          
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(entity.UserName, entity.Password, false, true);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("InBox", "Messages");
                }
                else
                {
                    return RedirectToAction("Index", "AuthorLogin");
                }
            }
            
            return View(entity);
        }
    }
}
