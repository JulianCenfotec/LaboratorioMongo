using Microsoft.AspNetCore.Mvc;
using LaboratorioMongo.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace LaboratorioMongo.Servicios
{
    public class CursoService
    {
        private readonly IMongoCollection<Curso> _cursoCollection;

        public CursoService(
            IOptions<UniversidadDatabaseSettings> universidadDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                universidadDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                universidadDatabaseSettings.Value.DatabaseName);

            _cursoCollection = mongoDatabase.GetCollection<Curso>(
                universidadDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<Curso>> GetAsync() =>
            await _cursoCollection.Find(_ => true).ToListAsync();

        public async Task<Curso?> GetAsync(string Codigo) =>
            await _cursoCollection.Find(x => x.Codigo == Codigo).FirstOrDefaultAsync();

        public async Task CreateAsync(Curso newCurso) =>
            await _cursoCollection.InsertOneAsync(newCurso);

        public async Task UpdateAsync(string id, Curso updatedCurso) =>
            await _cursoCollection.ReplaceOneAsync(x => x.Codigo == id, updatedCurso);

        public async Task RemoveAsync(string id) =>
            await _cursoCollection.DeleteOneAsync(x => x.Codigo == id);
    }
}