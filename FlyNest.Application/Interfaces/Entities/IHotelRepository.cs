using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.DbViewModel;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Application.Interfaces.Entities;

public interface IHotelRepository : IBaseRepository<Hotel>
{
    public Task<IEnumerable<SelectListItem>> DropdownAsync();
}
