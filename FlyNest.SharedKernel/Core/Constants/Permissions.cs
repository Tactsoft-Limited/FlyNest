namespace FlyNest.SharedKernel.Core.Constants;

public class Permissions
{
    public static List<string> GeneratePermissionsForModule(string module)
    {
        return new List<string>()
        {
            $"Permissions.{module}.Create",
            $"Permissions.{module}.View",
            $"Permissions.{module}.Edit",
            $"Permissions.{module}.Delete",
        };
    }

    public static class Users
    {
        public const string View = "Permissions.Users.View";
        public const string Create = "Permissions.Users.Create";
        public const string Edit = "Permissions.Users.Edit";
        public const string ManageRoles = "Permissions.Users.ManageRoles";
        public const string ManageClaims = "Permissions.Users.ManageClaims";
        public const string Delete = "Permissions.Users.Delete";
    }


    public static class Roles
    {
        public const string View = "Permissions.Roles.View";
        public const string Create = "Permissions.Roles.Create";
        public const string Edit = "Permissions.Roles.Edit";
        public const string Delete = "Permissions.Roles.Delete";
        public const string ManageClaims = "Permissions.Roles.ManageClaims";
    }
}