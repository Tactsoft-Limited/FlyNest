using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Infrastructure.Interfaces.Entities;

public interface IAirlineRepository : IBaseRepository<Airline>
{
    public IEnumerable<SelectListItem> Dropdown();
}
