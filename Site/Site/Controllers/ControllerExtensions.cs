using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Site.Controllers
{
    public static class ControllerExtensions
    {
        public static RssActionResult Rss(this Controller controller, SyndicationFeed feed)
        {
            return new RssActionResult {Feed = feed};
        }
    }
}
