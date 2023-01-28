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

namespace AspNetCoreKampi.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactManager _cm = new ContactManager(new EfContactDal());
        private readonly ContactValidator _cv = new ContactValidator();
        private ValidationResult vr;
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Gonderidi = TempData["Gonderidi"];
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact entity)
        {
            vr = _cv.Validate(entity);
            if (vr.IsValid)
            {
                TempData["Gonderidi"] = "True";
                entity.Status = true;
                entity.Date= DateTime.Parse(DateTime.Now.ToShortDateString());
                _cm.Add(entity);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
            }

            return View();
        }
    }
}
