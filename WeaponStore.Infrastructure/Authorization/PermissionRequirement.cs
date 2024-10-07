using Microsoft.AspNetCore.Authorization;
using WeaponStore.Core.Enums;

namespace WeaponStore.Infrastructure.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionEnum[] Permissions { get; set; }

    public PermissionRequirement(params PermissionEnum[] permissions)
    {
        Permissions = permissions;
    }
}