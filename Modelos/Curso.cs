using MongoDB.Bson.Serialization.Attributes;

namespace LaboratorioMongo.Modelos
{
    public class Curso
    {
        [BsonElement("Codigo")]
        public string Codigo { get; set; } = null!;

        [BsonElement("Nombre")]
        public string Nombre { get; set; } = null!;

        [BsonElement("Ciclo")]
        public int Ciclo { get; set; }
    }
}
