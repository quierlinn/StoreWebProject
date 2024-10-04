using WeaponStore.Core.Models;

namespace WeaponStore.Core.Abstractions;

public interface IRoleRepository
{
    public Task<Role> GetRoleByUserIdAsync(int UserID);
}