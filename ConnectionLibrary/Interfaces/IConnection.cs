using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionLibrary;

namespace SqlServerConnectionLibrary.Interfaces
{
    public interface IConnection
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
        /// <summary>
        /// Current environment
        /// </summary>
        public Environments Environment { get; set; }

    }
}
