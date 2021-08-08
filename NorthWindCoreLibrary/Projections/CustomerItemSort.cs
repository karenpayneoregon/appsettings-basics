using System;
using System.Linq;
using System.Linq.Expressions;
using NorthWindCoreLibrary.Models;

namespace NorthWindCoreLibrary.Projections
{
    /// <summary>
    /// A projection against a specific SELECT statement
    /// </summary>
    public class CustomerItemSort
    {
        public string CompanyName { get; set; }
        public string ContactTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int? CountryIdentifier { get; set; }
        public string Country { get; set; }
        public override string ToString() => CompanyName;

        public static Expression<Func<Customers, CustomerItemSort>> Projection
        {
            get
            {
                return (customers) => new CustomerItemSort()
                {
                    CompanyName = customers.CompanyName,
                    ContactTitle = customers.ContactTypeIdentifierNavigation.ContactTitle,
                    FirstName = customers.Contact.FirstName,
                    LastName = customers.Contact.LastName,
                    Street = customers.Street, 
                    City = customers.City,
                    CountryIdentifier = customers.CountryIdentifier,
                    Country = customers.CountryIdentifierNavigation.Name,
                };
            }
        }

    }
}
