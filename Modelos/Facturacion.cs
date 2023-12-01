using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LaboratorioMongo.Modelos
{
    public class Facturacion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Anio")]
        public int Anio { get; set; }

        [BsonElement("Estado")]
        public bool Estado { get; set; }

        [BsonElement("Numero")]
        public int Numero { get; set; }

        [BsonElement("FechaInicio")]
        public DateTime FechaInicio { get; set; }

        [BsonElement("FechaFinal")]
        public DateTime FechaFinal { get; set; }
    }
}
