using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LaboratorioMongo.Modelos
{
    public class Empleados
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Codigo")]
        public string Codigo { get; set; } = null!;

        [BsonElement("Nombre")]
        public string Nombre { get; set; } = null!;

        [BsonElement("Titulo")]
        public string Titulo { get; set; } = null!;

        [BsonElement("Cursos")]
        public List<Curso> Cursos { get; set; } = new List<Curso>();
    }
}
