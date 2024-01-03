using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNest.Application.Repositories.Entities;

public class AirlineRepository(FlyNestDbContext context) : BaseRepository<Airline>(context: context), IAirlineRepository, IApplication
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        return context.Set<Airline>().Where(x => !x.IsDelete).Select(x => new SelectListItem { Text = x.AirlineName, Value = x.Id.ToString() });
    }
}
