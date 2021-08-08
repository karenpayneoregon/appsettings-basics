using System.Threading.Tasks;
using AccessTestProject.Base;
using AccessTestProject.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AccessTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {

        [TestMethod]
        [TestTraits(Trait.ConnectionsTest)]
        public void TestDefaultConnection()
        {
            var (success, _ ) = AccessOperations.TestConnection();
            Assert.IsTrue(success);
        }
        [TestMethod]
        [TestTraits(Trait.Reading)]
        public void GetCustomers()
        {
            var (success, _, table) = AccessOperations.GetCustomers();
            
            Assert.AreEqual(table.Rows.Count,2);
        }
    }
}
