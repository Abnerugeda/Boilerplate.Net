using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class BaseRepository<T>(AppDbContext context) : IBaseRepository<T>
    where T : BaseEntity
{
    private readonly AppDbContext _context = context;

    public void Create(T entity)
    {
        entity.CreatedAt = DateTimeOffset.UtcNow;
        _context.Add(entity);
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.DeletedAt = DateTimeOffset.UtcNow;
        _context.Remove(entity);
    }

    public async Task<T> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FirstOrDefaultAsync((x) => x.Id == id, cancellationToken); 
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }
}