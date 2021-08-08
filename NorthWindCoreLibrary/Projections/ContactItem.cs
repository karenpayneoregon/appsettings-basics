using System;
using System.Linq.Expressions;
using NorthWindCoreLibrary.Models;

namespace NorthWindCoreLibrary.Projections
{
    public class ContactItem
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int? ContactTypeIdentifier { get; set; }
        public string ContactTitle { get; set; }

        public override string ToString() => $"{ContactTitle} {FirstName} {LastName}";


        public static Expression<Func<Contacts, ContactItem>> Projection
        {
            get
            {
                return (contacts) => new ContactItem()
                {
                    ContactId = contacts.ContactId, 
                    FirstName = contacts.FirstName, 
                    LastName = contacts.LastName, 
                    ContactTypeIdentifier = contacts.ContactTypeIdentifier, 
                    ContactTitle = contacts.ContactTypeIdentifierNavigation.ContactTitle
                    
                };
            }
        }
    }
}
