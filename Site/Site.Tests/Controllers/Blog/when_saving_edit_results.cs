using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;

namespace Site.Tests.Controllers.Blog
{
    public class when_saving_edit_results : blogcontroller_test
    {
        private const string NEWCONTENT = "new content";

        protected override void because()
        {
            base.because();
            var formData = new FormCollection()
                               {
                                   {"Author", expectedEntry.Author},
                                   {"Content", NEWCONTENT}
                               };
            
            result = controller.Edit(expectedEntry.Id, formData);
        }

        [Test]
        public void should_persist_entry_changes()
        {
            var entry = repository.GetEntryById(expectedEntry.Id);
            entry.Content.ShouldEqual(NEWCONTENT);
        }

        
        [Test]
        public void should_redirect()
        {
            result.ShouldBeOfType<RedirectToRouteResult>();
        }

        [Test]
        public void should_redirect_to_entry_view()
        {
            var redirect = result as RedirectToRouteResult;
            redirect.RouteValues["action"].ShouldEqual("Entry");
        }

        [Test]
        public void should_be_viewing_edited_entry()
        {
            var redirect = result as RedirectToRouteResult;
            redirect.RouteValues["id"].ShouldEqual(expectedEntry.Id);
        }
    }
}
