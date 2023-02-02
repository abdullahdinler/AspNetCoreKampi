using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreKampi.ViewComponents.Category
{
    public class DashboardCategoryList:ViewComponent
    {
        private readonly CategoryManager _category = new CategoryManager(new EfCategoryDal());
        public IViewComponentResult Invoke()
        {
            var categoryList = _category.GetList();
            return View(categoryList);
        }
    }
}
