using Fiscamoto_JeefryZamata.Domain.Ports.Dependencies;
using Fiscamoto_JeefryZamata.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiscamoto_JeefryZamata.Infrastructure.Adapters.Repositories.UnitOfWork;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(object id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await Task.CompletedTask; // Update es sincrónico en EF
    }

    public async Task Delete(object id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}