using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Application.Repositories.Entities;

public class HotelRepository(FlyNestDbContext context) : BaseRepository<Hotel>(context), IHotelRepository, IApplication
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        return context.Set<Hotel>().Where(x => x.IsDelete==true)
            .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
    }
}
