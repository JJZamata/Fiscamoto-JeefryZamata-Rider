namespace Fiscamoto_JeefryZamata.Domain.Ports.Dependencies;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> Complete();
}