using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlyNest.Application.Interfaces.Entities;

public interface ICountryRepository : IBaseRepository<Country>
{
    IEnumerable<SelectListItem> Dropdown();
    string GetCountryNameById(long id);
}
