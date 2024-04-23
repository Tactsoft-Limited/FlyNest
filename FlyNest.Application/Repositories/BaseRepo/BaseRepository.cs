using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Core.Default;
using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FlyNest.Application.Repositories.BaseRepo;

public class BaseRepository<T> : IBaseRepository<T> where T : AuditableEntity
{
    private readonly FlyNestDbContext _context;
    private readonly DbSet<T> entities;

    public BaseRepository(FlyNestDbContext context)
    {
        _context = context;
        entities = _context.Set<T>();
    }

    public IQueryable<T> GetAll() { return _context.Set<T>().Where(x => !x.IsDelete); }


    public async Task<List<T>> GetAllAsync() { return await _context.Set<T>().Where(x => !x.IsDelete).ToListAsync(); }


    public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _context.Set<T>().Where(x => !x.IsDelete);

        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return query;
    }

    public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _context.Set<T>().Where(x => !x.IsDelete);

        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return await query.ToListAsync();
    }

    public T FirstOrDefault(long? id) { return _context.Set<T>().Find(id); }

    public async Task<T> FirstOrDefaultAsync(long? id) { return await _context.Set<T>().FindAsync(id); }

    public T FirstOrDefault(long? id, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _context.Set<T>().Where(x => !x.IsDelete);

        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return query.FirstOrDefault(x => x.Id == id);
    }

    public async Task<T> FirstOrDefaultAsync(long? id, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _context.Set<T>().Where(x => !x.IsDelete);

        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    #region CRUD Operations
    public async Task InsertAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task InsertRangeAsync(List<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(object id, T entity)
    {
        var data = await _context.Set<T>().FindAsync(id);
        if (data != null)
        {
            entity.CopyPropertiesTo(data);
            _context.Set<T>().Update(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateRangeAsync(List<T> entities)
    {
        _context.Set<T>().UpdateRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<T> DeleteAsync(object id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        return entity;
    }

    public async Task DeleteRangeAsync(List<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
    #endregion

    public void Attach(T entity) { _context.Set<T>().Attach(entity); }

    public void Detach(T entity)
    {
        var entry = _context.Entry(entity);
        entry.State = EntityState.Detached;
    }
}
