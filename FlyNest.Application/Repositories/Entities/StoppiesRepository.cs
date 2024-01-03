using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Application.Repositories.Entities;

public class StoppiesRepository(FlyNestDbContext context) : BaseRepository<Stoppies>(context), IStoppiesRepository, IApplication
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        return context.Set<Stoppies>().Where(x => !x.IsDelete).Select(x => new SelectListItem { Text = x.Airport.Name, Value = x.AirportId
            .ToString() });
    }
}
