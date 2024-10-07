using WeaponStore.Core.Enums;
using WeaponStore.Core.Models;

namespace WeaponStore.Core.Abstractions;

public interface IUsersRepository
{
    public Task AddUsersAsync(User user);

    public Task<User> GetUserByLoginAsync(string username);
    public Task<HashSet<PermissionEnum>> GetPermissionsAsync(int userId);
}