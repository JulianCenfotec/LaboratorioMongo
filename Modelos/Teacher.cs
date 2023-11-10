using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LaboratorioMongo.Modelos
{
    public class Teacher
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Nombre { get; set; } = null!;

        public int Telefono { get; set; }

        public string Email { get; set; } = null!;

        public string Clave { get; set; }
    }
}
