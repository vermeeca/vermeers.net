using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Rhino.Mocks;
using Site.Model;
using Site.Model.Entities;

namespace Site.Tests.Models.BlogRepository
{
    public abstract class blogrepository_test : base_test
    {

        protected BlogEntryRepository repo = null;
        protected ISession session;

        protected List<BlogEntry> ExpectedEntries = new List<BlogEntry>();

        protected override void establish_context()
        {
            var settings = MockRepository.GenerateStub<IConfigurationSettings>();
            settings.Stub(s => s.PersistenceConfig).Return(SQLiteConfiguration.Standard.InMemory());
            settings.Stub(s => s.Mapping).Return(ConfigurationSettings.Map);

            var config = new Configuration(settings).Configure();
            session = config.OpenSession();
            new SchemaExport(config.FluentConfiguration.BuildConfiguration()).Execute(true, true, false, session.Connection, Console.Out);

            repo = new BlogEntryRepository(session);

            

            ExpectedEntries.Add(new BlogEntry
            {
                Author = "Me",
                Title = "Title",
                PublicationDate = DateTime.Now.AddDays(-1),
                Content = "Content"
            });
            ExpectedEntries.Add(new BlogEntry { Author = "Blah", Content = "Content", PublicationDate = DateTime.Now, Title = "Title" });

            ExpectedEntries.ForEach(b => repo.Insert(b));
        }

    }
}
