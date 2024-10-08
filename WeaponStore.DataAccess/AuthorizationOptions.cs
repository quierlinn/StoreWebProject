using WeaponStore.Core.Models;

namespace WeaponStore.DataAccess;

public class AuthorizationOptions
{
    public RolePermissions[] RolePermissions { get; set; }
}