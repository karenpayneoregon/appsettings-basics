using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWindCoreLibrary.Projections;


// ReSharper disable once CheckNamespace - do not change
namespace NorthWindCoreTestProject
{
    public partial class MainTest
    {
        /// <summary>
        /// Perform initialization before test runs using assertion on current test name.
        /// </summary>
        [TestInitialize]
        public void Initialization()
        {
            if (TestContext.TestName == nameof(TestConnectionTask))
            {
                // TODO
            }
        }

        public static ContactItem contact => new()
        {
            ContactId = 1,
            ContactTitle = "Accounting Manager",
            FirstName = "Maria",
            LastName = "Anders",
            ContactTypeIdentifier = 1
        };
        /// <summary>
        /// Perform any initialize for the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }
    }
}
