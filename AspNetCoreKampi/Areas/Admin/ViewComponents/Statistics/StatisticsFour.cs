using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreKampi.Areas.Admin.ViewComponents.Statistics
{
    public class StatisticsFour:ViewComponent
    {
        private readonly AdminManager _admin;

        public StatisticsFour(AdminManager admin)
        {
            _admin = admin;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _admin.GetById(1);
            return View(model);
        }
    }
}
