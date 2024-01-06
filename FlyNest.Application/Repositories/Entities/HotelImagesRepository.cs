using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;

namespace FlyNest.Application.Repositories.Entities;

public class HotelImagesRepository(FlyNestDbContext context) : BaseRepository<HotelImages>(context), IHotelImagesRepository, IApplication
{
}