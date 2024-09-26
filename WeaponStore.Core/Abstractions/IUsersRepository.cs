using WeaponStore.Core.Models;

namespace WeaponStore.Core.Abstractions;

public interface IUsersRepository
{
    public Task AddUsersAsync(User user);

    public Task<User> GetUserByLoginAsync(string email);
}