using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.DbViewModel;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FlyNest.Application.Repositories.Entities;

public class HotelRepository(FlyNestDbContext context) : BaseRepository<Hotel>(context), IHotelRepository, IApplication
{
    public async Task<IEnumerable<SelectListItem>> DropdownAsync()
    {
        var list = await GetAllAsync();
        return list.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
    }
}
