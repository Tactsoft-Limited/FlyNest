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

    public static class Airport
    {
        public const string View = "Permissions.Airport.View";
        public const string Create = "Permissions.Airport.Create";
        public const string Edit = "Permissions.Airport.Edit";
        public const string Delete = "Permissions.Airport.Delete";
    }

    public static class Airline
    {
        public const string View = "Permissions.Airline.View";
        public const string Create = "Permissions.Airline.Create";
        public const string Edit = "Permissions.Airline.Edit";
        public const string Delete = "Permissions.Airline.Delete";
    }

    public static class Flight
    {
        public const string View = "Permissions.Flight.View";
        public const string Create = "Permissions.Flight.Create";
        public const string Edit = "Permissions.Flight.Edit";
        public const string Delete = "Permissions.Flight.Delete";
    }
}