﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace AspNetCoreKampi.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentManager _cm = new(new EfCommentDal());
        public IActionResult Index()
        {
            return View();
        }

    }
}
