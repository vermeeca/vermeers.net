using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NUnit.Framework;
using Site.Model;
using Site.Model.Entities;

namespace Site.Tests.Models.BlogRepository
{
    public class when_updating_blogentry : blogrepository_test
    {
        BlogEntry entry = null;

        protected override void because()
        {
            base.because();
            entry = repo.GetEntryById(ExpectedEntries[0].Id);
            entry.Content += "Edited";
        }

        [Test]
        public void edited_entry_should_have_new_content()
        {
            var saved = repo.GetEntryById(entry.Id);
            saved.Content.ShouldEqual(entry.Content);
            
        }

        
    }
}
