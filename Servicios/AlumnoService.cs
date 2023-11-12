using LaboratorioMongo.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LaboratorioMongo.Servicios
{
    public class AlumnoService
    {
        private readonly IMongoCollection<Alumno> _alumnoCollection;

        public AlumnoService()
        {
            var settings = DatabaseSettings.Instance;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _alumnoCollection = database.GetCollection<Alumno>("Alumno");
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
