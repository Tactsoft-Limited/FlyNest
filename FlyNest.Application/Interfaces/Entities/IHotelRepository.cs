using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Application.ViewModels.VmEntities.Search;
using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Application.Interfaces.Entities;

public interface IHotelRepository : IBaseRepository<Hotel>
{
    public Task<IEnumerable<SelectListItem>> GetDropdownAsync();

    public Task<IEnumerable<SelectListItem>> DropdownAsync(long? selected = 0);

    public Task<IList<VmHotel>> SearchHotelAsync(VmSearchFlight vmSearch);
}
