using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Site.Model.Entities;

namespace Site.Tests.Models.BlogRepository
{
    public class when_creating_new_blogentry : blogrepository_test
    {
        private BlogEntry entry;

        protected override void because()
        {
            base.because();
            entry = repo.Create();
        }

        [Test]
        public void entry_should_not_be_null()
        {
            entry.ShouldNotBeNull();
        }

        [Test]
        public void entry_should_not_have_id()
        {
            entry.Id.ShouldEqual(0);
        }
    }
}
