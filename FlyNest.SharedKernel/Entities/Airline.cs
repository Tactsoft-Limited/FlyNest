using FlyNest.SharedKernel.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNest.SharedKernel.Entities;

public class Airline : AuditableEntity
{
    public string AirlineName { get; set; }
    public string ContactInfo { get; set; }
    public string Website { get; set; }
    public string Logo { get; set; }
    public DateOnly EstablishedDate { get; set; }
}
