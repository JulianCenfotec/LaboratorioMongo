using System;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace LaboratorioMongo.Modelos

{
    using MongoDB.Driver;

    public sealed class DatabaseSettings
    {
        private static readonly object syncLock = new object();
        private static DatabaseSettings instance;

        public string ConnectionString { get; private set; }
        public string DatabaseName { get; private set; }

        private DatabaseSettings()
        {
            // Assign your actual MongoDB connection string and database name here
            ConnectionString = "mongodb+srv://jose:Cenfotec123@cluster0.vp492.mongodb.net/";
            DatabaseName = "Universidad";
        }

        public static DatabaseSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                            instance = new DatabaseSettings();
                    }
                }

                return instance;
            }
        }
    }
}