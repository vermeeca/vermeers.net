using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Site.Model;
using Site.Model.Entities;

namespace Site.Controllers
{
    public class BlogController : Controller
    {

        private BlogEntryRepository Repository { get; set; }

        public BlogController(BlogEntryRepository repository)
        {
            Repository = repository;
        }

        public ActionResult Index()
        {
            ViewData["entries"] = Repository.GetRecentEntries();
            return View();
        }

        public ActionResult Entry(int id)
        {
            ViewData["entry"] = Repository.GetEntryById(id);
            return View();
        }

        public ActionResult Author(string name)
        {
            ViewData["entries"] = Repository.GetAll().Where(e => e.Author == name);
            return View();
        }


        public ActionResult Create()
        {
            ViewData["entry"] = Repository.Create();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(BlogEntry entry)
        {
            entry.PublicationDate = DateTime.Now;
            entry.Author = "Craig";
            Repository.Insert(entry);
            return RedirectToAction("Entry", new {id = entry.Id});
        }


    }
}
