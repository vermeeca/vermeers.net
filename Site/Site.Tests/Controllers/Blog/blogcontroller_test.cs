using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Site.Controllers;
using Site.Model;
using Site.Model.Entities;

namespace Site.Tests.Controllers.Blog
{
    public class blogcontroller_test : controller_test<BlogController>
    {
        protected BlogEntryRepository repository;
        protected BlogEntry expectedEntry;
        protected ActionResult result;


        protected override void establish_context()
        {
            base.establish_context();
            repository = new BlogEntryRepository(session);
            controller = new BlogController(repository);

            expectedEntry = repository.Create();
            expectedEntry.Author = "test";
            repository.Save(expectedEntry);
            
        }
    }
}
