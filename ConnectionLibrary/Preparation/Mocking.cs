using SqlServerConnectionLibrary.Classes;
using Environments = ConnectionLibrary.Environments;

namespace SqlServerConnectionLibrary.Preparation
{
    public class Mocking
    {
        /// <summary>
        /// Create the appsettings.json file. Note Environment is saved as
        /// an integer, some may like a string, personal choice
        /// </summary>
        public static void CreateAppSettings()
        {
            var fileName = "appsettings.json";
            
            ConnectionStrings connectionStrings = new ()
            {
                DevelopmentConnection = "Server=.\\SQLEXPRESS;Database=ocs;Integrated Security=true", 
                TestConnection = "Server=.\\TEST;Database=ocs;Integrated Security=true", 
                ProductionConnection = "Server=.\\PROD;Database=ocs;Integrated Security=true", 
                Environment = Environments.Development
            };


            var setting = new Settings() {ConnectionStrings = connectionStrings};

            JSonHelper.JsonToFormatted(setting, fileName, true);

        }
    }
}
