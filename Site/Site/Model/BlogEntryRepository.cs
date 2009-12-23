
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using Site.Model.Entities;
using NHibernate.Linq;


namespace Site.Model
{
    public class BlogEntryRepository : RepositoryBase
    {
        
        public BlogEntryRepository(ISession session) : base(session)
        {

        }

        public IEnumerable<BlogEntry> GetRecentEntries()
        {
            return (from b in new[]{new BlogEntry{Author="Blah", Content="Blah", PublicationDate=DateTime.Now, Title="Title"}}
                    orderby b.PublicationDate descending
                    select b).Take(10);
        }

        public void Insert(BlogEntry entry)
        {
            Session.Save(entry);
        }



    }
}