using MongoDB.Bson.Serialization.Attributes;

namespace LaboratorioMongo.Modelos
{
    public class Curso : Observador
    {
        [BsonElement("Codigo")]
        public string Codigo { get; set; } = null!;

        [BsonElement("Nombre")]
        public string Nombre { get; set; } = null!;

        [BsonElement("Ciclo")]
        public int Ciclo { get; set; }

        public void AgregarAlumno(Cliente alumno)
        {
            this.Subscribe(alumno);
            this.NotificarObservadores(this.Nombre);
        }
    }
}
