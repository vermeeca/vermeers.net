
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
            return (from b in Session.Linq<BlogEntry>()
                    orderby b.PublicationDate descending
                    select b).Take(10);
        }

        

        public void Insert(BlogEntry entry)
        {
            Session.Save(entry);
        }


        public BlogEntry GetEntryById(int id)
        {
            return Session.Get<BlogEntry>(id);
        }
    }
}