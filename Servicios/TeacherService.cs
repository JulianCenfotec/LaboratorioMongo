﻿using LaboratorioMongo.Fabrica;
using LaboratorioMongo.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LaboratorioMongo.Servicios
{
    public class TeacherService : IPersonaService<Teacher>
    {
        private readonly IMongoCollection<Teacher> _teachersCollection;

        public TeacherService()
        {
            var settings = DatabaseSettings.Instance;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
        }

        public async Task<List<Teacher>> GetAsync() =>
            await _teachersCollection.Find(_ => true).ToListAsync();

        public async Task<Teacher?> GetAsync(string id) =>
            await _teachersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Teacher newTeacher) =>
            await _teachersCollection.InsertOneAsync(newTeacher);

        public async Task UpdateAsync(string id, Teacher updatedTeacher) =>
            await _teachersCollection.ReplaceOneAsync(x => x.Id == id, updatedTeacher);

        public async Task RemoveAsync(string id) =>
            await _teachersCollection.DeleteOneAsync(x => x.Id == id);
    }
}