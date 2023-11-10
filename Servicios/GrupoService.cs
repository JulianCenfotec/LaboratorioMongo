using LaboratorioMongo.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LaboratorioMongo.Servicios
{
    public class GrupoService
    {
        private readonly IMongoCollection<Grupo> _grupoCollection;

        public GrupoService(
            IOptions<UniversidadDatabaseSettings> universidadDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                universidadDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                universidadDatabaseSettings.Value.DatabaseName);

            _grupoCollection = mongoDatabase.GetCollection<Grupo>(
                universidadDatabaseSettings.Value.GrupoCollectionName);
        }

        public async Task<List<Grupo>> GetAsync() =>
            await _grupoCollection.Find(_ => true).ToListAsync();

        public async Task<Grupo?> GetAsync(string id) =>
            await _grupoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Grupo newGrupo) =>
            await _grupoCollection.InsertOneAsync(newGrupo);

        public async Task UpdateAsync(string id, Grupo updatedGrupo) =>
            await _grupoCollection.ReplaceOneAsync(x => x.Id == id, updatedGrupo);

        public async Task RemoveAsync(string id) =>
            await _grupoCollection.DeleteOneAsync(x => x.Id == id);
    }
}
