using AutoMapper;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Entities;


namespace FlyNest.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Airport, VmAirport>().ReverseMap();
        CreateMap<Airline, VmAirline>().ReverseMap();

        CreateMap<VmFlight, Flight>()
            .ForMember(d => d.DepatureFlight, opts => opts.Ignore())
            .ForMember(d => d.ArrivalFlight, opts => opts.Ignore())
            .ForMember(d => d.Airline, opts => opts.Ignore())
            .ForMember(d => d.Stopovers, opts => opts.Ignore());
        CreateMap<Flight, VmFlight>()
            .ForMember(d => d.AirlineDropdown, opts => opts.Ignore())
            .ForMember(d => d.AirportDropdown, opts => opts.Ignore())
            .ForMember(d => d.Stopovers, opts => opts.Ignore())
            .ForMember(d => d.DepatureAirportName, opts => opts.MapFrom(src => src.DepatureFlight.Name))
            .ForMember(d => d.DepatureAirportCode, opts => opts.MapFrom(src => src.DepatureFlight.Code))
            .ForMember(d => d.ArrivalAirportName, opts => opts.MapFrom(src => src.ArrivalFlight.Name))
            .ForMember(d => d.ArrivalAirportCode, opts => opts.MapFrom(src => src.ArrivalFlight.Code))
            .ForMember(d => d.AirlineName, opts => opts.MapFrom(src => src.Airline.AirlineName))
            .ForMember(d => d.AirlineLogo, opts => opts.MapFrom(src => src.Airline.Logo));

        CreateMap<Stopover, VmStopover>().ReverseMap();

        CreateMap<VmBaggage, Baggage>().ReverseMap().ForMember(x=>x.AirlineName,x=>x.MapFrom(x=>x.Flight.Airline!=null?x.Flight.Airline.AirlineName:""));

        CreateMap<HotelImages, VmHotelImages>().ReverseMap();
        CreateMap<VmHotel, Hotel>().ReverseMap();
        CreateMap<RoomImages, VmRoomImages>().ReverseMap();
        CreateMap<VmRoom, Room >().ReverseMap().ForMember(x=>x.HotelName,x=>x.MapFrom(x=>x.Hotel!=null?x.Hotel.Name:""));
        AllowNullCollections = true;
    }
}
