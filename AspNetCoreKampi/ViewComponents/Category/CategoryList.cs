using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreKampi.ViewComponents.Category
{
    public class CategoryList:ViewComponent
    {
        private readonly CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        public IViewComponentResult Invoke()
        {
            var result = _cm.GetList();
            return View(result);
        }
    }
}
