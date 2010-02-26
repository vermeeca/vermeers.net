using System;
using System.ServiceModel.Syndication;
using Site.Model.Entities;

namespace Site.Rss
{
    public class BlogEntryToRssConverter
    {
        private BlogEntry _entry;

        public BlogEntryToRssConverter(BlogEntry entry)
        {
            _entry = entry;
        }

        public SyndicationItem ToRssItem()
        {
            return new SyndicationItem(_entry.Title, _entry.Content, null, _entry.Id.ToString(), _entry.PublicationDate);
        }
    }
}