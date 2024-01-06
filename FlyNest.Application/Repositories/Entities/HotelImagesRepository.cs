using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;

namespace FlyNest.Application.Repositories.Entities;

public class HotelImagesRepository(FlyNestDbContext context)
    : BaseRepository<HotelImages>(context), IHotelImagesRepository, IApplication
{
    

}