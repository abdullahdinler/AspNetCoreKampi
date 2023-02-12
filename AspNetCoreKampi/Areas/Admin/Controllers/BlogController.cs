using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreKampi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly BlogManager _blog = new BlogManager(new EfBlogDal());

        public IActionResult ExportListExcelBlogList()
        {
            using var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Blog Listesi");
            workSheet.Cell(1, 1).Value = "Blog ID";
            workSheet.Cell(1, 2).Value = "Blog Adı";

            var blogRowCount = 2;
            foreach (var blog in _blog.GetList().Select(x=>new{x.Id,x.Title}).ToList())
            {
                workSheet.Cell(blogRowCount, 1).Value = blog.Id;
                workSheet.Cell(blogRowCount, 2).Value = blog.Title;
                blogRowCount++;
            }

            using var stream = new MemoryStream();
            workBook.SaveAs(stream);

            var content = stream.ToArray();
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Calişma1.xlsx");
        }

        public IActionResult ExportStaticExcelBlogList()
        {
            return View();
        }
    }
}
