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
using Rhino.Mocks;
using Site.Model;
using Site.Model.Entities;
using Site.Model;

namespace Site.Tests.Models.BlogRepository
{
    [TestFixture]
    public class when_retrieving_recent_posts : blogrepository_test
    {

       

        private IEnumerable<BlogEntry> entries;


        protected override void because()
        {
            entries = repo.GetRecentEntries();
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
