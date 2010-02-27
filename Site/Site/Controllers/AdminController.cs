using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Site.Model;

namespace Site.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private Configuration Config { get; set; }

        public AdminController(Configuration config)
        {
            Config = config;
        }


        [Authorize]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult ReBuildDatabase()
        {
            Config.EnsureDatabaseCreated();
            return RedirectToAction("Index", "Home");
        }

    }
}
