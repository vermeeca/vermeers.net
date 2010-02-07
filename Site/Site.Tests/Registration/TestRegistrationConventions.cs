using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Ninject;
using NUnit.Framework;
using Site.Model;

namespace Site.Tests.Registration
{
    [TestFixture]
    public class TestRegistrationConventions : base_test
    {

        [Test]
        public void TestSession()
        {           
            var session = kernel.Get<ISession>();
            Assert.That(!(session == null));
        }

        [Test]
        public void TestRepositoryRegistration()
        {
            var repo = kernel.Get<BlogEntryRepository>();
            Assert.That(repo.GetType() == typeof(BlogEntryRepository));
        }

    }

    
}
