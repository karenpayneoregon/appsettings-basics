using System.Diagnostics;
using AppSettingsCoreUnitTestProject.Base;
using ConnectionLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlServerConnectionLibrary;

namespace AppSettingsCoreUnitTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        [TestMethod]
        [TestTraits(Trait.AppSettingsTest)]
        public void ReadConnections()
        {
            Assert.AreEqual(ConnectionString, "Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2020;Integrated Security=True");
            Assert.AreEqual(DevelopmentConnectionString, "Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2020;Integrated Security=True");
            Assert.AreEqual(TestConnectionString, "Data Source=TestServer;Initial Catalog=NorthWind2020;Integrated Security=True");
            Assert.AreEqual(ProductionConnectionString, "Data Source=ProductionServer;Initial Catalog=NorthWind2020;Integrated Security=True");
            
        }

        [TestMethod]
        [TestTraits(Trait.ConnectionsTest)]
        public void TestDefaultConnection()
        {
            Assert.IsTrue(DefaultConnectionTest());
        }

        [TestMethod]
        [TestTraits(Trait.AppSettingsTest)]
        public void IsDevelopmentEnvironment()
        {
            Assert.IsTrue(Helper.Environment == Environments.Development);
        }

    }
}
