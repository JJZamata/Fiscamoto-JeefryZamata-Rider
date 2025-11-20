namespace Fiscamoto_JeefryZamata.Domain.Ports.Dependencies;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(object id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(object id);
}