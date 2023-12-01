using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LaboratorioMongo.Modelos
{
    public class Grupo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Ciclo")]
        public string Ciclo { get; set; }

        [BsonElement("Curso")]
        public Curso Curso { get; set; }

        [BsonElement("NumeroGrupo")]
        public string NumeroGrupo { get; set; }

        [BsonElement("Horario")]
        public Horario Horario { get; set; }

        [BsonElement("Profesor")]
        public Teacher Profesor { get; set; }

        [BsonElement("EstudiantesMatriculados")]
        public List<Cliente> EstudiantesMatriculados { get; set; }

        [BsonElement("notas")]
        public List<Nota> Notas { get; set; }
    }
    public class Horario
    {
        [BsonElement("Dias")]
        public List<string> Dias { get; set; }

        [BsonElement("HoraInicio")]
        public string HoraInicio { get; set; }

        [BsonElement("HoraFin")]
        public string HoraFin { get; set; }
    }
    public class Nota
    {
        public string valor { get; set; }
    }

}
