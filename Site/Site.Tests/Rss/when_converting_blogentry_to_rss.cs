using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using NUnit.Framework;
using Site.Model.Entities;
using Site.Rss;

namespace Site.Tests.Rss
{
    [TestFixture]
    public class when_converting_blogentry_to_rss_item : base_test
    {

        private SyndicationItem item;
        private BlogEntry entry;

        protected override void because()
        {
            base.because();
            entry = new BlogEntry
                        {Author = "Me", Content = "Content", PublicationDate = DateTime.Now, Title = "Title"};
            item = new BlogEntryToRssConverter(entry).ToRssItem();
        }

        [Test]
        public void item_id_should_match_entry_id()
        {
            item.Id.ShouldEqual(entry.Id.ToString());
        }

        [Test]
        public void item_title_should_match_entry_title()
        {
            item.Title.ShouldEqual(entry.Title);
        }

        [Test]
        public void item_content_should_match_entry_content()
        {
            item.Content.ShouldEqual(entry.Content);
        }

        [Test]
        public void item_date_should_match_entry_date()
        {
            item.PublishDate.ShouldEqual(entry.PublicationDate);
        }
    }
}
