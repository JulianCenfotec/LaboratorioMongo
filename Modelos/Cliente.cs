using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LaboratorioMongo.Modelos
{
    public class Cliente : IObserver<String>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Nombre { get; set; } = null!;

        public int Telefono { get; set; }

        public string Email { get; set; } = null!;

        public string Clave { get; set; }

        [BsonElement("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [BsonElement("Carrera")]
        public string CarreraInscrita { get; set; }


        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(string value)
        {
            Console.WriteLine($"Estimado {this.Nombre}, se ha agregado el curso {value}.");
          
        }
    }

}
