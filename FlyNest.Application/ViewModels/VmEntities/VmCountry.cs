using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.AspNetCore.Http;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmCountry : BaseEntity
{
    public string Name { get; set; }
    public string Image { get; set; }
    public IFormFile ImageFile { get; set; }
}
