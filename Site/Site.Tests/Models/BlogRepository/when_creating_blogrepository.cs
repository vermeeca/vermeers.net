using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Site.Model;

namespace Site.Tests.Models.BlogRepository
{
    [TestFixture]
    public class when_creating_blogrepository : base_test
    {
        BlogEntryRepository repo = null;

        protected override void because()
        {
            repo = new BlogEntryRepository(null);
        }

        [Test]
        public void should_be_created()
        {
            repo.ShouldNotBeNull();
        }
    }
}
