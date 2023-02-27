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
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreKampi.Controllers
{
    [AllowAnonymous]
    public class NewsLatterController : Controller
    {
        private readonly NewsLatterManager _nlm = new(new EfNewsLatterDal());
        private readonly NewsLatterValidator _nlv = new();
        private ValidationResult _vr;


        [HttpPost]
        public IActionResult Index(NewsLetter entity)
        {
            _vr = _nlv.Validate(entity);
            if (_vr.IsValid)
            {
                _nlm.Add(entity);
                return Json(new { isValid = true });
            }
            else
            {
                var errorMessage = "";
                foreach (var error in _vr.Errors)
                {
                    errorMessage += error.ErrorMessage + " ";
                }
                return Json(new { isValid = false, errorMessage });
            }
        }
    }
}
