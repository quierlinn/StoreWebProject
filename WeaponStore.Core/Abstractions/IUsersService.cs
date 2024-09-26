namespace WeaponStore.Core.Abstractions;

public interface IUsersService
{
    public Task RegisterUser(string username, string password, string email);
}