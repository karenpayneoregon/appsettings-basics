using System.Data.SqlClient;
using SqlServerConnectionLibrary;

namespace AppSettingsCoreUnitTestProject.Classes
{
    public class SqlOperations
    {
        public static string ConnectionString = "";

        public static CustomerRelation GetCustomers()
        {

            InitializeConnection();
            
            CustomerRelation customer = new();

            var selectStatement = "TODO";

            using var cn = new SqlConnection() { ConnectionString = ConnectionString };
            using var cmd = new SqlCommand() { Connection = cn, CommandText = selectStatement };

            cn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                customer.CustomerIdentifier = reader.GetInt32(0);
                customer.CompanyName = reader.GetString(1);
                customer.City = reader.GetString(2);
                customer.PostalCode = reader.GetString(3);
                customer.ContactId = reader.GetInt32(4);
                customer.CountryIdentifier = reader.GetInt32(5);
                customer.Country = reader.GetString(6);
                customer.Phone = reader.GetString(7);
                customer.PhoneTypeIdentifier = reader.GetInt32(8);
                customer.ContactPhoneNumber = reader.GetString(9);
                customer.ModifiedDate = reader.GetDateTime(10);
                customer.FirstName = reader.GetString(11);
                customer.LastName = reader.GetString(12);
            }

            return customer;

        }

        private static void InitializeConnection()
        {
            if (!string.IsNullOrWhiteSpace(ConnectionString)) return;
            Helper.Initializer();
            ConnectionString = Helper.ConnectionString;
        }
    }
}
