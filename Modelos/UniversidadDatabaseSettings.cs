using System;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace LaboratorioMongo.Modelos
{
    public sealed class MongoDBInstance
    {
        //volatile: ensure that assignment to the instance variable
        //is completed before the instance variable can be accessed
        private static volatile MongoDBInstance instance;
        private static object syncLock = new Object();

        const string connectionString = "mongodb://localhost";
        private static MongoDatabase db = null;

        private MongoDBInstance()
        {
            var client = new MongoClient();
            MongoServer server = client.GetServer();
            server.Connect();

            db = server.GetDatabase("SchoolDB");
        }

        public static MongoDatabase GetMongoDatabase
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                            instance = new MongoDBInstance();
                    }
                }

                return db;
            }
        }
    }
}