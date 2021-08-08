using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


// ReSharper disable once CheckNamespace - do not change
namespace AccessTestProject
{
    public partial class MainTest
    {

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
