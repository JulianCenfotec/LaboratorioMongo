using LaboratorioMongo.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaboratorioMongo.Servicios
{
    public class CicloService
    {
        private readonly IMongoCollection<Facturacion> _cicloCollection;

        public CicloService()
        {
            var settings = DatabaseSettings.Instance;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _cicloCollection = database.GetCollection<Facturacion>("Ciclo"); ;
        }

        public async Task<List<Facturacion>> GetAsync() =>
            await _cicloCollection.Find(_ => true).ToListAsync();

        public async Task<Facturacion?> GetAsync(string id) =>
            await _cicloCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Facturacion newCiclo) =>
            await _cicloCollection.InsertOneAsync(newCiclo);

        public async Task UpdateAsync(string id, Facturacion updatedCiclo) =>
            await _cicloCollection.ReplaceOneAsync(x => x.Id == id, updatedCiclo);

        public async Task RemoveAsync(string id) =>
            await _cicloCollection.DeleteOneAsync(x => x.Id == id);
    }
}
