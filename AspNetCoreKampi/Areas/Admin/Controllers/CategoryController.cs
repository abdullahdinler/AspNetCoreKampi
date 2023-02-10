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
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace AspNetCoreKampi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly CategoryManager _cm = new(new EfCategoryDal());
        private readonly CategoryValidator _validator = new CategoryValidator();
        private ValidationResult _validation;

        public IActionResult Index(int page = 1)
        {
            var categoryList = _cm.GetList().ToPagedList(page , 3);
            return View(categoryList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category entity)
        {
            try
            {
                _validation = _validator.Validate(entity);
                if (_validation.IsValid)
                {
                    entity.Status = true;
                    _cm.Add(entity);
                    TempData["Alert"] = "Kategori başarılı bir şekilde eklendi.";
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    foreach (var error in _validation.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
            }
            catch (Exception e)
            {
                TempData["Alert"] = "Eklenme işlemi başarısız. Lütfen daha sonra tekrar deneyin.";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var entity = _cm.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Update(Category entity)
        {
            try
            {
                _validation = _validator.Validate(entity);
                if (_validation.IsValid)
                {
                    entity.Status = true;
                    _cm.Update(entity);
                    TempData["Alert"] = "Kategori başarılı bir şekilde güncellendi.";
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    foreach (var error in _validation.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
            }
            catch (Exception e)
            {
                TempData["Alert"] = "Güncelleme işlemi başarısız. Lütfen daha sonra tekrar deneyin.";
            }
            var model = _cm.GetById(entity.Id);
            return View(model);
        }


        public IActionResult Status(int id)
        {
            var entity = _cm.GetById(id);
            entity.Status = !entity.Status;
            _cm.Update(entity);
            return RedirectToAction("Index", "Category");
        }
    }
}
