using WeaponStore.Core.Enums;
using WeaponStore.Core.Models;

namespace WeaponStore.Core.Abstractions;

public interface IPermissionService
{
    public Task<HashSet<PermissionEnum>> GetAllPermissionsAsync(int userId);
}