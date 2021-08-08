using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWindCoreLibrary.Models;

namespace NorthWindCoreLibrary.LanguageExtensions
{
    public static class QueryExtensions
    {

        /// <summary>
        /// Include <see cref="Countries"/> <see cref="Contacts"/> and <see cref="ContactDevices"/> navigations
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable<Customers> IncludeContactsDevicesCountry(this IQueryable<Customers> query) => query
            .Include(customer => customer.CountryIdentifierNavigation)
            .Include(customer => customer.Contact)
            .ThenInclude(contact => contact.ContactDevices);


        public static IQueryable<Customers> IncludeTheKitchenSink(this IQueryable<Customers> query) => query
            .Include(customer => customer.Contact)
            .ThenInclude(contact => contact.ContactDevices)
            .ThenInclude(contactDevices => contactDevices.PhoneTypeIdentifierNavigation)
            .Include(customer => customer.ContactTypeIdentifierNavigation)
            .Include(customer => customer.CountryIdentifierNavigation);

        /// <summary>
        /// Fred - More examples for includes and filters
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable<Customers> IncludeTheKitchenSinkForOffice(this IQueryable<Customers> query) => query
            .Include(customer => customer.Contact)
            .ThenInclude(contact => contact.ContactDevices)
            .ThenInclude(contactDevices => contactDevices.PhoneTypeIdentifierNavigation)
            .Include(customer => customer.ContactTypeIdentifierNavigation)
            .Include(customer => customer.CountryIdentifierNavigation);

        public static IQueryable<Contacts> IncludeNavigations(this IQueryable<Contacts> query) => query
            .Include(contact => contact.ContactTypeIdentifierNavigation)
            .Include(contact => contact.ContactDevices);





    }
}
