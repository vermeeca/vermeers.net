using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Site.Models;

namespace Site.Tests.Models.Blog
{
    [TestFixture]
    public class when_creating_blogentry : base_test
    {

        private BlogEntry entry = null;

        protected override void because()
        {
            entry = new BlogEntry();
        }

        [Test]
        public void should_create_entry()
        {
            entry.ShouldNotBeNull();
        }
    }
}
