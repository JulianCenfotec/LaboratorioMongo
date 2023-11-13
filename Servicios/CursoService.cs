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

        public CursoService()
        {
            var settings = DatabaseSettings.Instance;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _cursoCollection = database.GetCollection<Curso>("Curso");
        }

        public async Task<List<Curso>> GetAsync() =>
            await _cursoCollection.Find(_ => true).ToListAsync();

        public async Task<Curso?> GetAsync(string Codigo) =>
            await _cursoCollection.Find(x => x.Codigo == Codigo).FirstOrDefaultAsync();
        public async Task CreateAsync(Curso newCurso)
        {
            await _cursoCollection.InsertOneAsync(newCurso);
            newCurso.NotificarObservadores(newCurso.Nombre);
        }
        public async Task UpdateAsync(string id, Curso updatedCurso) =>
            await _cursoCollection.ReplaceOneAsync(x => x.Codigo == id, updatedCurso);

        public async Task RemoveAsync(string id) =>
            await _cursoCollection.DeleteOneAsync(x => x.Codigo == id);
    }
}