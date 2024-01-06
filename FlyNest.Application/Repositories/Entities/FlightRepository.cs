using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Application.ViewModels.VmEntities.Search;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlyNest.Application.Repositories.Entities;

public class FlightRepository(FlyNestDbContext context, IMapper mapper) : BaseRepository<Flight>(context), IFlightRepository, IApplication
{
    private readonly IMapper _mapper = mapper;

    public async Task<List<VmFlight>> SearchFlightAsync(VmSearchFlight vmSearch)
    {
        var results = await GetAll()
            .Where(
                x => x.DepatureAirportId == vmSearch.DepatureAirportId &&
                    x.ArrivalAirportId == vmSearch.ArrivalAirportId &&
                    x.DepatureDate == vmSearch.DepatureDate)
            .ToListAsync();

        return _mapper.Map<List<VmFlight>>(results);
    }
}
