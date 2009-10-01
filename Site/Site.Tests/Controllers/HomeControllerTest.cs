using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gallio.Framework;
using MbUnit.Framework;
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
            ViewResult result = controller.Index() as ViewResult;

            // Verify
            ViewDataDictionary viewData = result.ViewData;

            Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
        }
    }
}
