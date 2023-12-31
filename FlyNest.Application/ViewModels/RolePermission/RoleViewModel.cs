using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.Application.ViewModels.RolePermission;

public class RoleViewModel : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }
}
