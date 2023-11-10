using MongoDB.Driver;

namespace LaboratorioMongo.Modelos
{
    public class UniversidadDatabaseSettings
    {
            public string ConnectionString { get; set; } = null!;

            public string DatabaseName { get; set; } = null!;
            public string CollectionName { get; set; } = null!;
        
    }
}
