using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Application.Interfaces.Entities;

public interface IAirlineRepository : IBaseRepository<Airline>
{
    Task<IEnumerable<SelectListItem>> GetDropdownAsync(long? selected = 0);
}
