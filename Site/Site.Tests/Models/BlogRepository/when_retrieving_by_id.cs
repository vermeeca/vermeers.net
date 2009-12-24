using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Site.Model.Entities;

namespace Site.Tests.Models.BlogRepository
{
    public class when_retrieving_by_id : blogrepository_test
    {

        private BlogEntry entry;
        private BlogEntry expected;

        protected override void because()
        {
            base.because();
            expected = ExpectedEntries[0];
            entry = repo.GetEntryById(expected.Id);
        }

        [Test]
        public void Should_Retrieve_Author()
        {
            entry.Author.ShouldEqual(expected.Author);
        }

        [Test]
        public void Should_Retrieve_Title()
        {
            entry.Title.ShouldEqual(expected.Title);
        }

        [Test]
        public void Should_Retrieve_PublicationDate()
        {
            entry.PublicationDate.ShouldEqual(expected.PublicationDate);
        }

        [Test]
        public void Should_Retrieve_Content()
        {
            entry.Content.ShouldEqual(expected.Content);
        }
    }
}
