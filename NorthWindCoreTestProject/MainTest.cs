using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthWindCoreLibrary.Classes;
using NorthWindCoreLibrary.Data;
using NorthWindCoreLibrary.LanguageExtensions;
using NorthWindCoreLibrary.Projections;
using NorthWindCoreTestProject.Base;

namespace NorthWindCoreTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        [TestMethod]
        [TestTraits(Trait.ConnectionsTest)]
        public async Task TestConnectionTask()
        {
            await using var context = new NorthwindContext();
            Assert.IsTrue(await context.TestConnection());
        }

        [TestMethod]
        [TestTraits(Trait.Reading)]
        public async Task GetContactsWithProjection()
        {
            
            await using var context = new NorthwindContext();
            
            List<ContactItem> contacts = await ContactOperations.GetContactsWithProjection();

            var firstContact = contacts.FirstOrDefault();
            var expected = contact;
            
           

            firstContact.ShouldDeepEqual(expected);


        }
    }
}
