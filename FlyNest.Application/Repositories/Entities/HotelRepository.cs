using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.DbViewModel;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FlyNest.Application.Repositories.Entities;

public class HotelRepository(FlyNestDbContext context) : BaseRepository<Hotel>(context), IHotelRepository, IApplication
{
    public async Task<IEnumerable<HotelViewModel>> GetAllHotelsAsync(long id)
    {
        var query = from hotel in context.Set<Hotel>()
            join image in context.Set<HotelImages>() on hotel.Id equals image.HotelId
            select new HotelViewModel
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                CountryName = hotel.CountryName,
                CityName = hotel.CityName,
                PriceStartFrom = hotel.PriceStartFrom,
                Discount = hotel.Discount,
                HotelImage = image.HotelImage,
                LocationMap = hotel.LocationMap
            };

        var result = await query.ToListAsync();

        return result;
    }



    public async Task<IEnumerable<SelectListItem>> DropdownAsync()
    {
        var list = await GetAllAsync();
        return list.Select(x=> new SelectListItem
        {
            Text = x.Name, Value = x.Id.ToString()
        });
    }
}
