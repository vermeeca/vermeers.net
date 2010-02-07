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
using Ninject;

namespace Site.Tests.Models.BlogRepository
{
    public abstract class blogrepository_test : base_test
    {

        protected BlogEntryRepository repo = null;

        protected List<BlogEntry> ExpectedEntries = new List<BlogEntry>();

        protected override void establish_context()
        {
            base.establish_context();
            repo = kernel.Get<BlogEntryRepository>();

            ExpectedEntries.Add(new BlogEntry
            {
                Author = "Me",
                Title = "Title",
                PublicationDate = DateTime.Now.AddDays(-1),
                Content = "Content"
            });
            ExpectedEntries.Add(new BlogEntry { Author = "Blah", Content = "Content", PublicationDate = DateTime.Now, Title = "Title" });

            ExpectedEntries.ForEach(b => repo.Save(b));
        }

    }
}
