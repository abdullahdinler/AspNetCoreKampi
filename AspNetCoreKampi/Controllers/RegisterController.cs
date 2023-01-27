using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreKampi.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AuthorManager _ahm = new AuthorManager(new EfAuthorDal());
        private readonly AuthorValidator _av = new AuthorValidator();
        private ValidationResult _vr;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Basarili = TempData["Basarili"] as string;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Author entity)
        {
            _vr = _av.Validate(entity);
            if (_vr.IsValid)
            {
                TempData["Basarili"] = "True";
                entity.Status = false;
                _ahm.Add(entity);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var error in _vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
            }

            return View();
        }
    }
}
