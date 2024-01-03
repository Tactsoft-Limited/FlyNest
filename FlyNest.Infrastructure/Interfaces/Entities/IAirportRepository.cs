using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Infrastructure.Interfaces.Entities;

public interface IAirportRepository : IBaseRepository<Airport>
{
    public IEnumerable<SelectListItem> Dropdown();
}
