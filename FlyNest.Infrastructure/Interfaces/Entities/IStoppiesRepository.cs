using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Infrastructure.Interfaces.Entities;

public interface IStoppiesRepository:IBaseRepository<Stoppies>
{
    public IEnumerable<SelectListItem> Dropdown();
}
