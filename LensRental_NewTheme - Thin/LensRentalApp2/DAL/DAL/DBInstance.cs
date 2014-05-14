using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;

namespace DAL
{
    

    /// <summary>
    /// Singleton class for DB Instance
    /// </summary>
    public sealed class DBInstance
    {
        //Private instance of the singleton class

        //Object to lock the Singleton Instance to avoid the duplicate instance
        //   private static readonly string CONNECTIONSTRINGTEMPLATE = ConfigurationManager.AppSettings["SiteConnection"].ToString();
        static string connectionString = "CentalDbConnectionString";
        private static readonly Database CentalDatabaseInstance =
            DatabaseFactory.CreateDatabase(connectionString);

        private static readonly IDictionary<Guid, Database> SiteDatabases = new Dictionary<Guid, Database>();


        //private static int SlidingCacheExpiration = int.Parse(ConfigurationManager.AppSettings["CacheSlidingExpiration"].ToString());

        /// <summary>
        /// Gets the get central server instance.
        /// Singleton instance of Database
        /// </summary>
        /// <value>The get central server instance.</value>
        public static Database GetCentralServerInstance
        {
            get { return CentalDatabaseInstance; }
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <param name="serverName">Name of the server.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <returns>connection string</returns>
        private static string GetConnectionString(string serverName, string databaseName)
        {
            // return string.Format(CONNECTIONSTRINGTEMPLATE, serverName, databaseName);
            return "";
        }




        /// <summary>
        /// Creates the database.
        /// </summary>
        /// <param name="serverName">Name of the server.</param>
        /// <param name="databaseName">Name of the db.</param>
        /// <returns>Enterprize library database object</returns>
        public static Database CreateDatabase(string serverName, string databaseName)
        {
            // Extension Method
            string connection = GetConnectionString(serverName, databaseName);

            return CreateDatebase(connection);
        }

        /// <summary>
        /// CreateCentralServerInstance
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>Database</returns>
        public static Database CreateCentralServerInstance(string connectionString)
        {
            connectionString = ConfigurationManager.ConnectionStrings[connectionString].ToString();
            return CreateDatebase(connectionString);//DatabaseFactory.CreateDatabase(connectionString);


        }


        private static Database CreateDatebase(string connection)
        {
            IConfigurationSourceBuilder builder = new ConfigurationSourceBuilder();

            builder.ConfigureData()
                .ForDatabaseNamed("NamedDB")
                .ThatIs.ASqlDatabase()
                .WithConnectionString(connection)
                .AsDefault()
                .ForDatabaseNamed("DyanmicDB")
                .ThatIs.ASqlDatabase()
                .WithConnectionString(connection);

            // Create ConfigurationSource
            DictionaryConfigurationSource configSource = new DictionaryConfigurationSource();

            builder.UpdateConfigurationWithReplace(configSource);

            // Set Container
            EnterpriseLibraryContainer.Current
                = EnterpriseLibraryContainer.CreateDefaultContainer(configSource);

            // Get Named Instance of Database
            Database database = EnterpriseLibraryContainer.Current.GetInstance<Database>("DyanmicDB");

            return database;
        }
    }
}
