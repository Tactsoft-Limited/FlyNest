using AutoMapper;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Http.HttpResults;


namespace FlyNest.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Airport, VmAirport>().ReverseMap();
        CreateMap<Airline, VmAirline>().ReverseMap();
        CreateMap<VmStoppies,Stoppies>().ReverseMap().ForMember(x=>x.AirportName,x=>x.MapFrom(x=>x.Airport!=null?x.Airport.Name:""));

        CreateMap<HotelImages, VmHotelImages>().ReverseMap();
        CreateMap<VmHotel, Hotel>().ReverseMap();
        CreateMap<RoomImages, VmRoomImages>().ReverseMap();
        CreateMap<VmRoom, Room >().ReverseMap().ForMember(x=>x.HotelName,x=>x.MapFrom(x=>x.Hotel!=null?x.Hotel.Name:""));
        AllowNullCollections = true;
    }
}
