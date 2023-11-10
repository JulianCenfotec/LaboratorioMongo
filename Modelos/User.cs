using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LaboratorioMongo.Modelos
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Nombre { get; set; } = null!;

        public int Telefono { get; set; }

        public string Emali { get; set; } = null!;

        public string Fecha_Macimineto { get; set; } = null!;

        public string Rol { get; set; } = null!;

        public string Clave { get; set; } = null!;
    }
}
