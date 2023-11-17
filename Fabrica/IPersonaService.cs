namespace LaboratorioMongo.Fabrica
{
    public interface IPersonaService<T>
    {
        Task<List<T>> GetAsync();
        Task<T?> GetAsync(string id);
        Task CreateAsync(T newEntity);
        Task UpdateAsync(string id, T updatedEntity);
        Task RemoveAsync(string id);
    }
}
