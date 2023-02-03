using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreKampi.Controllers
{
    [AllowAnonymous]
    public class AuthorController : Controller
    {
        private readonly AuthorManager _author = new AuthorManager(new EfAuthorDal());
        private readonly AuthorValidator _validator = new AuthorValidator();
        private ValidationResult _vr;
        public IActionResult Index()
        {
            var values = _author.GetById(3);
            return View(values);
        }

        [HttpGet]
        public IActionResult ProfileEdit()
        {
            var values = _author.GetById(3);
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> ProfileEdit(Author entity, IFormFile image)
        {
            // Formdan pass1 ve pass2 adındaki veriler alınır 
            var pas1 = Request.Form["pass1"];
            var pas2 = Request.Form["pass2"];

            // Formdan alınan veriler eşleliyorsa kaydetme işlemine geçsin
            if (pas1 == pas2)
            {
                entity.Password = pas2;
                if (image != null)
                {
                    // ismin benzersiz olması için guid kullanıldı
                    var uniqueId = Guid.NewGuid();
                    var fileName = uniqueId + "_" + image.FileName;


                    // Dosyanın kaydedilecek yolu belirliyoruz
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "WriterImageFiles", fileName);
                    
                    // Stream adında FileStream nesnesi oluşturduk burada alınan yol ve oluştuma modu ile dosya resim ekleme işlemi yapıldı.
                    await using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }


                    // Veri tabanına kaydedilecek yol verildi.
                    entity.Image = "/WriterImageFiles/" + fileName;
                }

                // Validation kontrolü yapıldı köntrolden gecerse kayıt işlemi yapılacak.
                _vr = await _validator.ValidateAsync(entity);
                if (_vr.IsValid)
                {
                    entity.Status = true;
                    _author.Update(entity);
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    foreach (var error in _vr.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
            }
            else
            {
                ViewBag.hata = "Girdiğiniz Parolalar Uyuşmuyor!";
            }
            return View();
        }

    }
}
