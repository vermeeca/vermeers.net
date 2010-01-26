
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

        public IQueryable<BlogEntry> GetRecentEntries()
        {
            return (from b in Session.Linq<BlogEntry>()
                    orderby b.PublicationDate descending
                    select b).Take(10);
        }

        public IQueryable<BlogEntry> GetAll()
        {
            return Session.Linq<BlogEntry>();
        }

        public BlogEntry Create()
        {
            return new BlogEntry();
        }

        public void Save(BlogEntry entry)
        {
            Session.Save(entry);
        }


        public BlogEntry GetEntryById(int id)
        {
            return Session.Get<BlogEntry>(id);
        }
    }
}