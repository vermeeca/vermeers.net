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

        private string content = "content";
        private string author = "author";
        private DateTime publicationDate = DateTime.Now;
        private string title = "titie";


        protected override void because()
        {
            entry = new BlogEntry{Content=content, Author=author, PublicationDate=publicationDate, Title=title};
        }

        [Test]
        public void should_create_entry()
        {
            entry.ShouldNotBeNull();
        }

        [Test]
        public void should_have_content()
        {
            Assert.AreEqual(content, entry.Content);
        }

        [Test]
        public void should_have_author()
        {
            Assert.AreEqual(author, entry.Author);
        }

        [Test]
        public void should_have_title()
        {
            Assert.AreEqual(title, entry.Title);
        }

        [Test]
        public void should_have_publicationdate()
        {
            entry.PublicationDate.ShouldEqual(publicationDate);
        }
    }
}
