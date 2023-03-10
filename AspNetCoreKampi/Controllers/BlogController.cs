using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreKampi.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreKampi.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly BlogManager _bm = new BlogManager(new EfBlogDal());
        private readonly CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        private readonly BlogValidator _bv = new BlogValidator();
        private ValidationResult _vr;

        public IActionResult Index()
        {
            var result = _bm.GetBlogWithCategory();
            return View(result);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var result = _bm.GetBlogWithCategory(id);
            return View(result);
        }

        //public PartialViewResult Last3Posts()
        //{
        //    var result = _bm.GetLastList();
        //    return PartialView(result);
        //}
        
        public IActionResult BlogListByAuthor()
        {
            var authorMail = User.Identity?.Name;
            var values = AuthorId.Id(authorMail);
            ViewData["CurrentUser"] = values;
            var blog = _bm.GetBlogWithAuthor(values.Id);
            return View(blog);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            var authorMail = User.Identity?.Name;
            var values = AuthorId.Id(authorMail);
            ViewData["CurrentUser"] = values;


            // Burada kategory listesi cekildi ve cekilen catgory listesi viewbag verildi
            var categoryList = (from item in _cm.GetList()
                select new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                }).ToList();
             
            ViewBag.category = categoryList;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog entity)
        {
            _vr = _bv.Validate(entity);

            var categoryList = (from item in _cm.GetList()
                select new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                }).ToList();

            ViewBag.category = categoryList;

            if (_vr.IsValid)
            {
                var authorMail = User.Identity?.Name;
                var values = AuthorId.Id(authorMail);
                ViewData["CurrentUser"] = values;
                entity.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                entity.AuthorId = values.Id;
                entity.Status = true;

                // Ekleme işlemi yapıldığı zaman Tempdata ya mesaj verildi
                TempData["Alert"] = "Blog başarılı bir şekilde oluşturuldu.";
                _bm.Add(entity);
                return RedirectToAction("BlogListByAuthor", "Blog");
            }
            else
            {
                foreach (var error in _vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult Status(int id)
        {

            var entity = _bm.GetById(id);
            entity.Status = !entity.Status;
            _bm.Update(entity);
            return RedirectToAction("BlogListByAuthor", "Blog");
        }


        public IActionResult Delete(int id)
        {
            var entity = _bm.GetById(id);
            _bm.Delete(entity);
            return RedirectToAction("BlogListByAuthor");
        }


        [HttpGet]
        public IActionResult BlogUpdate(int id)
        {

            var authorMail = User.Identity?.Name;
            var values = AuthorId.Id(authorMail);
            ViewData["CurrentUser"] = values;
            List<SelectListItem> categoryList = (from item in _cm.GetList()
                select new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                }).ToList();
            ViewBag.category = categoryList;

            var entity = _bm.GetById(id);

            return View(entity);
        }

        [HttpPost]
        public IActionResult BlogUpdate(Blog entity)
        {
            List<SelectListItem> categoryList = (from item in _cm.GetList()
                select new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                }).ToList();

            ViewBag.category = categoryList;

            _vr = _bv.Validate(entity);
            if (_vr.IsValid)
            {
                var authorMail = User.Identity?.Name;
                var values = AuthorId.Id(authorMail);
                ViewData["CurrentUser"] = values;
                entity.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                entity.AuthorId =values.Id;
                entity.Status = true;
                TempData["Alert"] = "Blog başarılı bir şekilde güncellendi.";
                _bm.Update(entity);
                return RedirectToAction("BlogListByAuthor", "Blog");
            }
            else
            {
                foreach (var error in _vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
    }
}
