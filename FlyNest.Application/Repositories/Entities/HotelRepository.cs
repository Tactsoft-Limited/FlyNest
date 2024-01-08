using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Application.ViewModels.VmEntities.Search;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FlyNest.Application.Repositories.Entities;

public class HotelRepository(FlyNestDbContext context, IMapper mapper) : BaseRepository<Hotel>(context), IHotelRepository, IApplication
{
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<SelectListItem>> GetDropdownAsync()
    {
        var list = await GetAllAsync();
        return list.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
    }

    public async Task<IEnumerable<SelectListItem>> DropdownAsync(long? selected = 0)
    {
        var list = await GetAll().ToListAsync();
        return list.Select(
            x => new SelectListItem
            {
                Text = $"{x.Name}-{x.CityName}-{x.CountryName}",
                Value = x.Id.ToString(),
                Selected = x.Id == selected
            });
    }

    public async Task<IList<VmHotel>> SearchHotelAsync(VmSearchFlight vmSearch)
    {
        var results = await GetAll().Where(x => x.Id == vmSearch.HotelId).Include(x => x.HotelImages).ToListAsync();

        return _mapper.Map<List<VmHotel>>(results);
    }
}
