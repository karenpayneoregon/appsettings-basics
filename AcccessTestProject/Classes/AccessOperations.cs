using System;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;
using AccessConnectionLibrary;

namespace AccessTestProject.Classes
{
    public static class AccessOperations
    {
        public static string ConnectionString = "";
        

        private static void InitializeConnection()
        {
            if (!string.IsNullOrWhiteSpace(ConnectionString)) return;
            Helper.Initializer();
            ConnectionString = Helper.ConnectionString;
        }

        public static (bool success, Exception exception) TestConnection()
        {

            InitializeConnection();
            
            using var cn = new OleDbConnection { ConnectionString = ConnectionString };
            using var cmd = new OleDbCommand { Connection = cn };
            try
            {
                cn.Open();
                return (true, null);
            }
            catch (Exception exception)
            {
                return (false, exception);
            }
        }

        public static (bool success, Exception exception, DataTable table) GetCustomers()
        {
            DataTable dataTable = new DataTable();
            
            InitializeConnection();

            using var cn = new OleDbConnection { ConnectionString = ConnectionString };
            using var cmd = new OleDbCommand
            {
                Connection = cn, 
                CommandText = "SELECT Customers.Identifier, Customers.FirstName, Customers.LastName FROM Customers;"
            };

            try
            {
                cn.Open();
                
                dataTable.Load(cmd.ExecuteReader());

                return (true, null, dataTable);
            }
            catch (Exception exception)
            {

                return (false, exception, null);
            }

        }
    }
}
