using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Site.Model.Entities;

namespace Site.Tests.Controllers.Blog
{
    public class when_creating_new_entry : blogcontroller_test
    {

        protected override void because()
        {
            base.because();
            result = controller.Create();
        }

        [Test]
        public void result_should_be_view()
        {
            result.ShouldBeOfType(typeof(ViewResult));
        }

        [Test]
        public void viewdata_should_contain_entry()
        {
            ViewResult view = result as ViewResult;
            view.ViewData["entry"].ShouldNotBeNull();
        }

        [Test]
        public void viewdata_entry_should_be_blogentry()
        {
            ViewResult view = result as ViewResult;
            view.ViewData["entry"].ShouldBeOfType(typeof (BlogEntry));
        }
    }
}
