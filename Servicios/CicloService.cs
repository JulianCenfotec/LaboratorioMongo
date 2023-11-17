using LaboratorioMongo.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaboratorioMongo.Servicios
{
    public class CicloService
    {
        private readonly IMongoCollection<Ciclo> _cicloCollection;

        public CicloService(IOptions<UniversidadDatabaseSettings> universidadDatabaseSettings)
        {
            var mongoClient = new MongoClient(universidadDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(universidadDatabaseSettings.Value.DatabaseName);
            _cicloCollection = mongoDatabase.GetCollection<Ciclo>(universidadDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<Ciclo>> GetAsync() =>
            await _cicloCollection.Find(_ => true).ToListAsync();

        public async Task<Ciclo?> GetAsync(string id) =>
            await _cicloCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Ciclo newCiclo) =>
            await _cicloCollection.InsertOneAsync(newCiclo);

        public async Task UpdateAsync(string id, Ciclo updatedCiclo) =>
            await _cicloCollection.ReplaceOneAsync(x => x.Id == id, updatedCiclo);

        public async Task RemoveAsync(string id) =>
            await _cicloCollection.DeleteOneAsync(x => x.Id == id);
    }
}
