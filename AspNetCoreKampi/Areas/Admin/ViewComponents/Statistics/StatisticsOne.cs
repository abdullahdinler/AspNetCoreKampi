using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreKampi.Areas.Admin.ViewComponents.Statistics
{
    public class StatisticsOne:ViewComponent
    {
        private readonly BlogManager _blog = new(new EfBlogDal());
        private readonly ContactManager _contact = new (new EfContactDal());
        private readonly CommentManager _comment = new(new EfCommentDal()); 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.BlogCount = _blog.GetList().Count;
            ViewBag.ContactCount = _contact.GetList().Count;
            ViewBag.CommentCount = _comment.GetList().Count;


            //Api üzerinden hava durumu verisini aldık.
            const string apiKey = "84eb7fc6881752e7634af0cd8857625a";
            var connection =
                $"https://api.openweathermap.org/data/2.5/weather?q=Mardin&mode=xml&lang=tr&units=metric&appid={apiKey}";
            var document = XDocument.Load(connection);
            ViewBag.Heat = document.Descendants("temperature").ElementAt(0).Attribute("value")!.Value;
            return View();
        }
    }
}
