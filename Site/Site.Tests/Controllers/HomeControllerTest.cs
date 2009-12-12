using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using Site;
using Site.Controllers;

namespace Site.Tests.Controllers
{
    /// <summary>
    /// Summary description for HomeControllerTest
    /// </summary>
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Setup
            HomeController controller = new HomeController();

            // Execute
            RedirectToRouteResult result = controller.Index() as RedirectToRouteResult;

            Assert.AreEqual("Blog", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);

           
        }
    }
}
