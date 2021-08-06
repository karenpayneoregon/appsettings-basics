using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSettingsCoreUnitTestProject.Classes
{
    public class CustomerRelation
    {
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int ContactId { get; set; }
        public int CountryIdentifier { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public int PhoneTypeIdentifier { get; set; }
        public string ContactPhoneNumber { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString() => CompanyName;

    }
}
