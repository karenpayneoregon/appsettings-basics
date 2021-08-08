using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWindCoreLibrary.Data;
using NorthWindCoreLibrary.Projections;

namespace NorthWindCoreLibrary.Classes
{
    public class ContactOperations
    {
        public static async Task<List<ContactItem>> GetContactsWithProjection()
        {
            List<ContactItem> contactList = new();

            await Task.Run(async () =>
            {
                await using var context = new NorthwindContext();
                contactList = await context.Contacts.Select(ContactItem.Projection).ToListAsync();
            });

            return contactList;
        }
    }
}
