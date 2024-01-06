using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FlyNest.Application.Repositories.Entities;

public class AirportRepository(FlyNestDbContext context) : BaseRepository<Airport>(context), IAirportRepository, IApplication
{
    public async Task<IEnumerable<SelectListItem>> DropdownAsync(long? selected = 0)
    {
        var list = await GetAll().ToListAsync();
        return list.Select(
            x => new SelectListItem
            {
                Text = $"{x.Code}-{x.CityName}-{x.CountryName}-{x.Name}",
                Value = x.Id.ToString(),
                Selected = x.Id == selected
            });
    }

    public async Task<IEnumerable<SelectListItem>> GetDropdownAsync(long? selected = 0)
    {
        var list = await GetAll().ToListAsync();
        return list.Select(
            x => new SelectListItem { Text = x.Name, Value = x.Id.ToString(), Selected = x.Id == selected });
    }

    public async Task<bool> IsCodeExists(string code) { return !await GetAll().AnyAsync(x => x.Code == code); }
}
