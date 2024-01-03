using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmStoppies: BaseEntity
{
    [Required]
    public string Duration { get; set; }
    [Required]
    [DisplayName("Airport Name")]
    public long AirportId { get; set; }
    [NotMapped]
    [DisplayName("Airport Name")]
    public string AirportName { get; set; }
}
