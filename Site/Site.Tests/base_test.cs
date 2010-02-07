using System;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Ninject;
using NUnit.Framework;
using Rhino.Mocks;
using Site.Model;

namespace Site.Tests
{
    /// <summary>
    /// Taken from Leonard Smith: http://github.com/ignu/specish/tree/master/Specish/
    /// </summary>
    [TestFixture]
    public class base_test
    {

        protected IConfigurationSettings configSettings;
        protected Configuration config;
        protected ISession session;
        protected IKernel kernel;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            establish_context();
            because();
        }


        /// <summary>
        /// Set up infrastructure.
        /// In AAA syntax, this is Arrange
        /// </summary>
        protected virtual void establish_context()
        {

            configSettings = MockRepository.GenerateStub<IConfigurationSettings>();
            //settings.Stub(s => s.PersistenceConfig).Return(SQLiteConfiguration.Standard.UsingFile("site.db"));
            configSettings.Stub(s => s.PersistenceConfig).Return(SQLiteConfiguration.Standard.InMemory());
            configSettings.Stub(s => s.Mapping).Return(ConfigurationSettings.Map);
            //TODO: Fix
            configSettings.Stub(s => s.Membership).Return(null);

            kernel = new StandardKernel(new ServiceModule());
            kernel.Unbind<IConfigurationSettings>();
            kernel.Bind<IConfigurationSettings>().ToConstant(configSettings);


            config = new Configuration(configSettings).Configure();

            session = config.OpenSession();

            //just get a new session each time
            configSettings.Stub(s => s.CurrentSession).Return(config.OpenSession());

            new SchemaExport(config.FluentConfiguration.BuildConfiguration()).Execute(true, true, false, session.Connection, Console.Out);

        }

        /// <summary>
        /// This is why we the asserts are true.  
        /// In AAA syntax, this is the Act.
        /// </summary>
        protected virtual void because()
        {
        }


        /// <summary>
        /// Perform an action before each test
        /// </summary>
        [SetUp]
        public virtual void before_each()
        {
        }

        /// <summary>
        /// Perform an action after the last test.
        /// </summary>
        [TestFixtureTearDown]
        public virtual void after_last()
        {

        }

        /// <summary>
        /// Perform an action after the last test.
        /// </summary>
        [TearDown]
        public virtual void after_each()
        {
        }
    }
}