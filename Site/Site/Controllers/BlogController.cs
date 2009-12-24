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

namespace Site.Controllers
{
    public class BlogController : Controller
    {

        private BlogEntryRepository _repository;

        public BlogController(BlogEntryRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            ViewData["Entries"] = _repository.GetRecentEntries();
            return View();
        }

        public ActionResult Entry(int id)
        {
            ViewData["entry"] = _repository.GetEntryById(id);
            return View();
        }



    }
}
