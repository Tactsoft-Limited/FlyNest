using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.Entities;
using System.Linq.Expressions;

namespace FlyNest.Infrastructure.Interfaces.Entities;

public interface IRoomImagesRepository:IBaseRepository<RoomImages>
{
    Task<List<RoomImages>> GetAllAsync(Expression<Func<RoomImages, bool>> filter,
        params Expression<Func<RoomImages, object>>[] includes);
}