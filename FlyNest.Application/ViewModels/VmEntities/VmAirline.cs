using FlyNest.SharedKernel.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmAirline: BaseEntity
{
    [Required]
    public string AirlineName { get; set; }
    [Required]
    public string ContactInfo { get; set; }
    [Required]
    public string Website { get; set; }
    public string Logo { get; set; }
    public DateOnly EstablishedDate { get; set; }
}
