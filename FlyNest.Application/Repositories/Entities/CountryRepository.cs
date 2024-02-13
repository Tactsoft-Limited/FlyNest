using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Application.Repositories.Entities;

public class CountryRepository(FlyNestDbContext context) : BaseRepository<Country>(context), ICountryRepository
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        return GetAll().Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString(),
        });
    }
}
