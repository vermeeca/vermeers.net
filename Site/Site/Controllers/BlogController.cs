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

        [Authorize]
        public ActionResult Create()
        {
            ViewData["entry"] = Repository.Create();
            return View();
        }



        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(BlogEntry entry)
        {
            entry.PublicationDate = DateTime.Now;
            entry.Author = "Craig";
            Repository.Save(entry);
            return RedirectToAction("Entry", new {id = entry.Id});
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewData["entry"] = Repository.GetEntryById(id);
            return View();
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection formData)
        {
            var entry = Repository.GetEntryById(id);
            this.UpdateModel(entry, formData.ToValueProvider());
            
            return RedirectToAction("Entry", new {id = entry.Id});
        }

        public ActionResult Rss()
        {
            var entries = Repository.GetRecentEntries();
            return null;
            
        }



    }
}
