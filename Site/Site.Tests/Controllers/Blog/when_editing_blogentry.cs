using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Site.Model.Entities;

namespace Site.Tests.Controllers.Blog
{
    public class when_editing_blogentry : blogcontroller_test
    {

        

        protected override void because()
        {
            result = controller.Edit(expectedEntry.Id);
        }

        [Test]
        public void should_return_view()
        {
            result.ShouldBeOfType(typeof (ViewResult));
        }

        [Test]
        public void viewdata_should_contain_entry()
        {
            var view = result as ViewResult;
            view.ViewData["entry"].ShouldNotBeNull();
        }

        [Test]
        public void entry_should_be_as_expected()
        {
            var view = result as ViewResult;
            var entry = view.ViewData["entry"] as BlogEntry;
            entry.Id.ShouldEqual(expectedEntry.Id);
        }
    }
}
