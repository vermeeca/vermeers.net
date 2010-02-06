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
    public class TestRegistrationConventions 
    {
        [Test]
        public void TestConfigurationRegistration()
        {
            using(var kernel = new StandardKernel(new ServiceModule()))
            {
                var config = kernel.Get<IConfigurationSettings>();
                Assert.That(config.GetType() == typeof (ConfigurationSettings));
            }
        }

        [Test]
        public void TestSession()
        {
            using (var kernel = new StandardKernel(new ServiceModule()))
            {
                var session = kernel.Get<ISession>();
                Assert.That(!(session == null));
            }
        }

        [Test]
        public void TestRepositoryRegistration()
        {
            using (var kernel = new StandardKernel(new ServiceModule()))
            {
                var repo = kernel.Get<BlogEntryRepository>();
                Assert.That(repo.GetType() == typeof(BlogEntryRepository));
            }
        }

    }

    
}
