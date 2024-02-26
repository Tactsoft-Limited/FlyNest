namespace FlyNest.Application.ViewModels.VmEntities.Search;

public class VmReservation
{
    public VmHotelReservation HotelReservation { get; set; }

    public VmFlightReservation FlightReservation { get; set; }

    public List<VmImageSlider> ImageSlider { get; set; }
    public List<VmCountry> CountryList { get; set; }
    public List<VmTourPackage> ExploreBDList { get; set; }
}
