using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Site.Controllers;
using Site.Model;
using Site.Model.Entities;

namespace Site.Tests.Controllers.Blog
{
    public class blogcontroller_test : controller_test<BlogController>
    {
        protected override void establish_context()
        {
            base.establish_context();
            var repository = new BlogEntryRepository(session);
            controller = new BlogController(repository);
            
        }
    }
}
