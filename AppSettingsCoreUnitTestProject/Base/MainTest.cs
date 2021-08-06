using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerConnectionLibrary;


// ReSharper disable once CheckNamespace - do not change
namespace AppSettingsCoreUnitTestProject
{
    public partial class MainTest
    {
        public static string ConnectionString;
        public static string DevelopmentConnectionString;
        public static string TestConnectionString;
        public static string ProductionConnectionString;
        
        
        [TestInitialize]
        public void Initialization()
        {
            Helper.Initializer();
            
            // default connection string
            ConnectionString = Helper.ConnectionString;
            
            DevelopmentConnectionString = Helper.DevelopmentConnectionString;
            TestConnectionString = Helper.TestConnectionString;
            ProductionConnectionString = Helper.ProductionConnectionString;
            
            

        }

        public static bool DefaultConnectionTest()
        {
           
            using var cn = new SqlConnection() { ConnectionString = Helper.ConnectionString };

            try
            {
                cn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }
    }
}
