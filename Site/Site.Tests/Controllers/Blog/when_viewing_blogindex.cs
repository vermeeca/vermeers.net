using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Site.Controllers;

namespace Site.Tests.Controllers.Blog
{
    public class when_viewing_blogindex : blogcontroller_test
    {
        protected ActionResult result;

        protected override void because()
        {
            result = controller.Index();
        }



        
    }
}
