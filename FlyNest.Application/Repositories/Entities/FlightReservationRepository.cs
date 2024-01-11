using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;

namespace FlyNest.Application.Repositories.Entities;

public class FlightReservationRepository(FlyNestDbContext context) : BaseRepository<FlightReservation>(context), IFlightReservationRepository
{
}
