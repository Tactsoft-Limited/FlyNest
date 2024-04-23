using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities.Search;

public class VmVisaProcessRequest
{
    public long? CountryId { get; set; }
    public double ProcessingFee { get; set; }
    public double VisaFee { get; set; }

    [DataType(DataType.Date)]
    public DateTime FromDate { get; set; } = DateTime.Now;

    [DataType(DataType.Date)]
    public DateTime ToDate { get; set; } = DateTime.Now;

    public int TotalTraveller { get; set; } = 1;
}
