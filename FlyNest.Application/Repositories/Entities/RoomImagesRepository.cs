using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FlyNest.Application.Repositories.Entities;

public class RoomImagesRepository(FlyNestDbContext context) : BaseRepository<RoomImages>(context), IRoomImagesRepository, IApplication
{
}