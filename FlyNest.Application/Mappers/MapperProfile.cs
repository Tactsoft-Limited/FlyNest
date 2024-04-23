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
            .ForMember(d => d.Baggages, opts => opts.Ignore())
            .ForMember(d => d.DepatureAirportName, opts => opts.MapFrom(src => src.DepatureFlight.Name))
            .ForMember(d => d.DepatureAirportCode, opts => opts.MapFrom(src => src.DepatureFlight.Code))
            .ForMember(d => d.ArrivalAirportName, opts => opts.MapFrom(src => src.ArrivalFlight.Name))
            .ForMember(d => d.ArrivalAirportCode, opts => opts.MapFrom(src => src.ArrivalFlight.Code))
            .ForMember(d => d.BaggageWeight, opts => opts.MapFrom(src => src.Baggage.LuggageWeight))
            .ForMember(d => d.AirlineName, opts => opts.MapFrom(src => src.Airline.AirlineName))
            .ForMember(d => d.AirlineLogo, opts => opts.MapFrom(src => src.Airline.Logo));

        CreateMap<Stopover, VmStopover>().ReverseMap();

        CreateMap<VmBaggage, Baggage>().ReverseMap();

        CreateMap<HotelImages, VmHotelImages>().ReverseMap();
        CreateMap<VmHotel, Hotel>().ReverseMap();
        CreateMap<RoomImages, VmRoomImages>().ReverseMap();
        CreateMap<VmRoom, Room>()
            .ReverseMap()
            .ForMember(x => x.HotelName, x => x.MapFrom(x => x.Hotel != null ? x.Hotel.Name : string.Empty));

        CreateMap<VmFlightReservation, FlightReservation>().ReverseMap();


        CreateMap<HotelReservation, VmHotelReservation>();
        CreateMap<VmHotelReservation, HotelReservation>();

        CreateMap<VmTourPackage, TourPackage>()
            .ForMember(d => d.Country, opt => opt.Ignore());

        CreateMap<TourPackage, VmTourPackage>()
            .ForMember(d => d.CountryDropdown, opt => opt.Ignore())
            .ForMember(d => d.CountryName, opt => opt.MapFrom(src => src.Country.Name))
            .ForMember(d => d.CountryImage, opt => opt.MapFrom(src => src.Country.Image));

        CreateMap<VmImageSlider, ImageSlider>().ReverseMap();
        CreateMap<VmCountry, Country>().ReverseMap();

        CreateMap<VmConfirmBooking, ConfirmBooking>().ReverseMap();
        CreateMap<VmVisaRequirement, VisaRequirement>().ReverseMap();
        CreateMap<VmVisaRequest, VisaRequest>().ReverseMap();

        CreateMap<ImageGallery, VmImageGallery>().ReverseMap();
        CreateMap<Faq, VmFaq>().ReverseMap();

        AllowNullCollections = true;
    }
}
