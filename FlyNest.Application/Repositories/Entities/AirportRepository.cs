using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Application.Repositories.Entities;

public class AirportRepository(FlyNestDbContext context) : BaseRepository<Airport>(context: context), IAirportRepository, IApplication
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        return context.Set<Airport>().Where(x=>!x.IsDelete).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
    }
}
