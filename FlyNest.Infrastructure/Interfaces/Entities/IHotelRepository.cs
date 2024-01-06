using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.DbViewModel;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Infrastructure.Interfaces.Entities;

public interface IHotelRepository:IBaseRepository<Hotel>
{
    Task<IEnumerable<HotelViewModel>> GetAllHotelsAsync(long id);
    public Task<IEnumerable<SelectListItem>> DropdownAsync();
}
