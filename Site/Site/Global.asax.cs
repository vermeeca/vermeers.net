using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

namespace Site
{
    public class Global : HttpApplication
    {
        static readonly Application _application = new Application();

        protected void Application_Start(object sender, EventArgs e)
        {
            _application.RegisterViewEngines(ViewEngines.Engines);
            _application.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // this ensures Default.aspx will be processed
            var context = ((HttpApplication)sender).Context;
            var relativeFilePath = context.Request.AppRelativeCurrentExecutionFilePath;
            if (relativeFilePath == "~/" ||
                string.Equals(relativeFilePath, "~/default.aspx", StringComparison.InvariantCultureIgnoreCase))
            {
                context.RewritePath("~/Home");
            }
        }
    }
}