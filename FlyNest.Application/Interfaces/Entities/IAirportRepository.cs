using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Application.Interfaces.Entities;

public interface IAirportRepository : IBaseRepository<Airport>
{
    Task<IEnumerable<SelectListItem>> GetDropdownAsync(long? selected = 0);

    Task<IEnumerable<SelectListItem>> DropdownAsync(long? selected = 0);

    Task<bool> IsCodeExists(string code);
}
