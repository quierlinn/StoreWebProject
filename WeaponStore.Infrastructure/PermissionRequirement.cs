using WeaponStore.Core.Abstractions;
using WeaponStore.Core.Models;

namespace WeaponStore.Infrastructure;

public class PermissionRequirement : IPermissionRequierement
{
    public Permission[] Permissions { get; set; }

    public PermissionRequirement(params Permission[] permissions)
    {
        Permissions = permissions;
    }
}