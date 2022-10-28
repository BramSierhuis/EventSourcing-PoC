using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Repositories;

public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : ReadModel, new()
    where TContext : DbContext
{
    private readonly TContext _context;

    protected BaseRepository(TContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression)
    {
        return await _context.Set<TEntity>().Where(expression).ToListAsync();
    }
    
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
    
    public async Task<TEntity> GetById(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }
}