namespace FlyNest.Application.ViewModels.RolePermission;

public class ManageClaimViewModel
{
    public ManageClaimViewModel()
    {
    }

    public ManageClaimViewModel(string type, string value, bool @checked)
    {
        Type = type;
        Value = value;
        Checked = @checked;
    }

    public string Type { get; set; }

    public string Value { get; set; }

    public bool Checked { get; set; }
}
