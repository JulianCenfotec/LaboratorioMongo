using LaboratorioMongo.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LaboratorioMongo.Servicios
{
    public class CarreraService : 
    {
        private readonly IMongoCollection<Empleados> _carreraCollection;

        public CarreraService()
        {
            var settings = DatabaseSettings.Instance;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _carreraCollection = database.GetCollection<Empleados>("Carrera");
        }

        public async Task<List<Empleados>> GetAsync() =>
            await _carreraCollection.Find(_ => true).ToListAsync();

        public async Task<Empleados?> GetAsync(string id) =>
            await _carreraCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Empleados newCarrera) =>
            await _carreraCollection.InsertOneAsync(newCarrera);

        public async Task UpdateAsync(string id, Empleados updatedCarrera) =>
            await _carreraCollection.ReplaceOneAsync(x => x.Id == id, updatedCarrera);

        public async Task RemoveAsync(string id) =>
            await _carreraCollection.DeleteOneAsync(x => x.Id == id);
    }
}
