using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Application.ViewModels.VmEntities.Search;
using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Application.Interfaces.Entities;

public interface IFlightRepository : IBaseRepository<Flight>
{
    public Task<List<VmFlight>> SearchFlightAsync(VmSearchFlight vmSearch);

    public Task<IEnumerable<SelectListItem>> DropdownAsync();
}
