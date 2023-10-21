using Application.Common.Interfaces.Common;
using Domain.Common;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Common;

public sealed class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
{
    private readonly DotnetstoreIntranetContext _context;

    public GenericRepository(DotnetstoreIntranetContext context)
    {
        _context = context;
    }

    public IQueryable<T> Entities => _context.Set<T>();
    
    async Task<T?> IGenericRepository<T>.GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    async Task<List<T>> IGenericRepository<T>.GetAllAsync()
    {
        return await _context
            .Set<T>()
            .ToListAsync();
    }

    void IGenericRepository<T>.Create(T entity)
    {
        _context.Entry(entity).State = EntityState.Added;
    }

    void IGenericRepository<T>.Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    void IGenericRepository<T>.Delete(T entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
    }
}