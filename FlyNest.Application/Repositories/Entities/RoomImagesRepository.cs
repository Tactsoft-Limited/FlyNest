using System.Linq.Expressions;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlyNest.Application.Repositories.Entities;

public class RoomImagesRepository(FlyNestDbContext context) : BaseRepository<RoomImages>(context),IRoomImagesRepository,IApplication
{
    public async Task<List<RoomImages>> GetAllAsync(Expression<Func<RoomImages, bool>> filter, params Expression<Func<RoomImages, object>>[] includes)
    {
        var query = context.Set<RoomImages>().AsQueryable();

        if (filter != null)
            query = query.Where(filter);

        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.ToListAsync();
    }
}