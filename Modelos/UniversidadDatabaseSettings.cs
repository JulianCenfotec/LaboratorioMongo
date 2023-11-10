using MongoDB.Driver;

namespace LaboratorioMongo.Modelos
{
    public class UniversidadDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;
        public string AlumnoCollectionName { get; set; } = null!;
        public string GrupoCollectionName { get; set; } = null!;
        public string CarreraCollectionName { get; set; } = null!;
        public string CursoCollectionName { get; set; } = null!;
        public string TeacherCollectionName { get; set; } = null!;
        public string UserCollectionName { get; set; } = null!;

    }
}