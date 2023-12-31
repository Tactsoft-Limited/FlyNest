using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.Application.ViewModels.RolePermission;

public class UserViewModel : BaseEntity
{
    public string UserName { get; set; }

    public string Email { get; set; }
}
