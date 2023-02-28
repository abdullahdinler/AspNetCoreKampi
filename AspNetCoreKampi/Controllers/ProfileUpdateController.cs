using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreKampi.ViewModels;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp;

namespace AspNetCoreKampi.Controllers
{
    public class ProfileUpdateController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ProfileUpdateViewModel _model = new();

        public ProfileUpdateController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity!.Name);
            _model.userName = values.UserName;
            _model.nameSurname = values.NameSurname;
            _model.mail = values.Email;

            return View(_model);
        }


        //  Bir view model oluşturuldu bu view model üzerinden yazar veya admin bilgileri guncellendi (kullanıcıadı, Email, şifre vb.)
        [HttpPost]
        public async Task<IActionResult> Index(ProfileUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity!.Name);
            values.UserName = model.userName;
            values.NameSurname = model.nameSurname;
            values.Email = model.mail;

            // Eski şifre doğru ise şifre degişikliği yap
            var passwordAsync = await _userManager.ChangePasswordAsync(values, model.Password,model.PasswordAgain);
            if (passwordAsync.Succeeded)
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);
            }

            var result = await _userManager.UpdateAsync(values);
            if (result != null)
            {
              
                return RedirectToAction("LoginGirisSayfasi", "LoginUser");
            }

            return View(model);
        }


        // Identity cıkış kodu yazıldı. Kullanıcı cıkış yapmak isterse veya şifre değişikliği yaptığı zamanda kullanılacak. 
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "LoginUser");
        }

    }
}
