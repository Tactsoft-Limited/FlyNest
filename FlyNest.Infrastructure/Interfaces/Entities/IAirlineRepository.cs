using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNest.Infrastructure.Interfaces.Entities;

public interface IAirlineRepository : IBaseRepository<Airline>
{
}
