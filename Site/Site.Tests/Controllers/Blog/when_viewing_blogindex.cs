using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Site.Controllers;
using Site.Model.Entities;

namespace Site.Tests.Controllers.Blog
{
    public class when_viewing_blogindex : blogcontroller_test
    {
        protected ActionResult result;

        protected override void because()
        {
            result = controller.Index();
        }

        [Test]
        public void ViewData_Should_Contain_Entries()
        {
            var view = result as ViewResult;
            view.ViewData["entries"].ShouldNotBeNull();
        }

        [Test]
        public void Entries_Should_Be_BlogEntries()
        {
            var view = result as ViewResult;
            view.ViewData["entries"].ShouldBeOfType(typeof (IQueryable<BlogEntry>));
        }




    }
}
