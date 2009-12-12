﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.RedirectToAction("Index", "Blog");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
