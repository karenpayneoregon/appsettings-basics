# Appsetting connection library for .NET Core projects

Provides samples for using appsettings.json for .NET Core/C# 9 instead of using app.config

- Currently there is only one example for working with SQL-Server, later other examples will following.
- Proper usage is to keep, in this case SqlServerConnectionLibrary project in this solution, when needed for your solution reference this project's DLL

## Addendum

For SQL-Server we have three environments

```json
{
  "ConnectionStrings": {
    "DevelopmentConnection": "Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2020;Integrated Security=True",
    "ProductionConnection": "Data Source=ProductionServer;Initial Catalog=NorthWind2020;Integrated Security=True",
    "TestConnection": "Data Source=TestServer;Initial Catalog=NorthWind2020;Integrated Security=True",
    "Environment": 2
  }
}
```

To get the default connection, in this case `Development`

```csharp
public static bool ConnectionTest()
{
    Helper.Initializer();
    
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
```

How are environments known

```csharp
public enum Environments
{
    Production,
    Test,
    Development
}
```

An enum is used rather than a string as a string can be mistyped and cause a runtime error.

Note that Helper.Initializer(); need only be called once in an application, not for each call.

Example

```csharp
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
```