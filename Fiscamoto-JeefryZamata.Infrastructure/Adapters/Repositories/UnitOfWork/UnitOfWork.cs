using System.Collections;
using Fiscamoto_JeefryZamata.Domain.Ports.Dependencies;
using Fiscamoto_JeefryZamata.Infrastructure.Data.Context;

namespace Fiscamoto_JeefryZamata.Infrastructure.Adapters.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable? _repositories;
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        _repositories = new Hashtable();
    }

    public Task<int> Complete()
    {
        return _context.SaveChangesAsync();
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity).Name;

        // Verificar si el repositorio ya existe en cache
        if (_repositories != null && _repositories.ContainsKey(type))
        {
            return (IRepository<TEntity>)_repositories[type]!;
        }

        // Crear nuevo repositorio usando reflexión
        var repositoryType = typeof(Repository<>);
        var repositoryInstance = Activator.CreateInstance(
            repositoryType.MakeGenericType(typeof(TEntity)),
            _context
        );

        // Agregar al cache
        if (repositoryInstance != null && _repositories != null)
        {
            _repositories.Add(type, repositoryInstance);
            return (IRepository<TEntity>)repositoryInstance;
        }

        throw new Exception("Unable to create repository");
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}