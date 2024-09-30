namespace WeaponStore.Core.Abstractions;

public interface IUsersService
{
    public Task RegisterUser(string username, string password, string email);
    public Task<string> LoginUser(string username, string password);
}