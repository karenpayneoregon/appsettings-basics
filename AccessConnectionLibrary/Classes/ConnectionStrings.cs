using AccessConnectionLibrary.Interfaces;
using ConnectionLibrary;

namespace AccessConnectionLibrary.Classes
{
    /// <summary>
    /// Application connection strings
    /// </summary>
    public class ConnectionStrings : IConnection
    {
        /// <summary>
        /// Development environment connection string
        /// </summary>
        public string DevelopmentConnection { get; set; }
        /// <summary>
        /// Production environment connection string
        /// </summary>        
        public string ProductionConnection { get; set; }
        /// <summary>
        /// Test environment connection string
        /// </summary>
        public string TestConnection { get; set; }

        public Environments Environment { get; set; }


        public override string ToString() => Environment.ToString();

    }
}