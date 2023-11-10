using LaboratorioMongo.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LaboratorioMongo.Servicios
{
    public class AlumnoService
    {
        private readonly IMongoCollection<Alumno> _alumnoCollection;

        public AlumnoService(
            IOptions<UniversidadDatabaseSettings> universidadDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                universidadDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                universidadDatabaseSettings.Value.DatabaseName);

            _alumnoCollection = mongoDatabase.GetCollection<Alumno>(
                universidadDatabaseSettings.Value.AlumnoCollectionName);
        }

        public async Task<List<Alumno>> GetAsync() =>
            await _alumnoCollection.Find(_ => true).ToListAsync();

        public async Task<Alumno?> GetAsync(string id) =>
            await _alumnoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Alumno newAlumno) =>
            await _alumnoCollection.InsertOneAsync(newAlumno);

        public async Task UpdateAsync(string id, Alumno updatedAlumno) =>
            await _alumnoCollection.ReplaceOneAsync(x => x.Id == id, updatedAlumno);

        public async Task RemoveAsync(string id) =>
            await _alumnoCollection.DeleteOneAsync(x => x.Id == id);
    }
}
