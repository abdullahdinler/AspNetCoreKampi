using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreKampi.Controllers
{
    [AllowAnonymous]
    public class AuthorLoginController : Controller
    {
        readonly AuthorManager _author = new AuthorManager(new EfAuthorDal());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Author entity)
        {
            var value = _author.AuthorLogin(entity.Mail, entity.Password);
            if (value != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, entity.Mail)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
               return View(); 
            }
            
        }
    }
}
//var value = _author.AuthorLogin(entity.Mail, entity.Password);
//if (value != null)
//{
//    HttpContext.Session.SetString("username", entity.Mail);
//    return RedirectToAction("Index", "Blog");
//}
//else
//{
//    return View();
//}