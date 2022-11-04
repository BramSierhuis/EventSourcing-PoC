using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WidgetAndCo.Functions.Extensions;
using WidgetAndCo.Functions.Repositories.Abstract;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Repositories;

public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : ReadModel, new()
    where TContext : DbContext
{
    private readonly TContext _context;

    protected BaseRepository(TContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task<TEntity> AddEntity(TEntity entity)
    {
        var currentEntity = await _context.Set<TEntity>().FindAsync(entity.Id);

        if (currentEntity != null) throw new Exception("Entity already exists");
        
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task GetAndUpdateEntity(Guid id, Action<TEntity> action)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        action.Invoke(entity);

        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}