using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Application.ViewModels.VmEntities.Search;
using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.Entities;

namespace FlyNest.Application.Interfaces.Entities;

public interface IFlightRepository : IBaseRepository<Flight>
{
    public Task<List<VmFlight>> SearchFlightAsync(VmSearchFlight vmSearch);
}
