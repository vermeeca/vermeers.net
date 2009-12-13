using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Site.Model;
using Site.Model.Entities;
using Site.Model;

namespace Site.Tests.Models.BlogRepository
{
    [TestFixture]
    public class when_retrieving_recent_posts : base_test
    {

        private BlogEntryRepository repo = null;
        private ISession session;

        private IQueryable<BlogEntry> entries;


        protected override void establish_context()
        {
            var mc = new MappingConfig();
            mc.PersistenceConfig = SQLiteConfiguration.Standard.InMemory();

            var config = mc.GetConfiguration();
            session = config.BuildSessionFactory().OpenSession();
            new SchemaExport(config.BuildConfiguration()).Execute(true, true, false, session.Connection, Console.Out);    
          
            repo = new BlogEntryRepository(session);

            repo.Insert(new BlogEntry
            {
                Author = "Me",
                Title = "Title",
                PublicationDate = DateTime.Now.AddDays(-1),
                Content = "Content"
            });
            repo.Insert(new BlogEntry
                            {Author = "Blah", Content = "Content", PublicationDate = DateTime.Now, Title = "Title"});
          
        }


        protected override void because()
        {
            entries = repo.GetRecentEntries();
        }

        public override void after_last()
        {
            session.Close();
        }

        [Test]
        public void should_have_at_least_one_entry()
        {
            entries.Count().ShouldBeGreaterThan(0);
        }

        [Test]
        public void should_order_by_publicationdate_desc()
        {
            var eList = entries.ToList();
            entries.First().PublicationDate.ShouldBeGreaterThan(eList[eList.Count - 1].PublicationDate);
        }


    }
}
