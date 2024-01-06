using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FlyNest.Application.Repositories.Entities;

public class AirlineRepository(FlyNestDbContext context) : BaseRepository<Airline>(context), IAirlineRepository, IApplication
{
    public async Task<IEnumerable<SelectListItem>> GetDropdownAsync(long? selected = 0)
    {
        var list = await GetAll().ToListAsync();
        return list.Select(
            x => new SelectListItem { Text = x.AirlineName, Value = x.Id.ToString(), Selected = x.Id == selected });
    }
}
