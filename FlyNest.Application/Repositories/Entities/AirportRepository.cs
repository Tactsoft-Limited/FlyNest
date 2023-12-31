using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;

namespace FlyNest.Application.Repositories.Entities;

public class AirportRepository(FlyNestDbContext context) : BaseRepository<Airport>(context), IAirportRepository, IApplication
{
}
