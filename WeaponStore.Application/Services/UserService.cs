using WeaponStore.Core.Abstractions;
using WeaponStore.Core.Models;

namespace WeaponStore.Application.Services;

public class UserService : IUsersService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUsersRepository _usersRepository;
    private readonly IJwtProvider _jwtProvider;

    public UserService(IPasswordHasher passwordHasher, IUsersRepository usersRepository, IJwtProvider jwtProvider)
    {
        _passwordHasher = passwordHasher;
        _usersRepository = usersRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task RegisterUser(string login, string password, string email)
    {
        var hashedPassword = _passwordHasher.HashPassword(password);
        var user = User.Create(login, hashedPassword, email);
        await _usersRepository.AddUsersAsync(user);
    }

    public async Task<string> LoginUser(string username, string password)
    {
        var user = await _usersRepository.GetUserByLoginAsync(username);
        var result = _passwordHasher.VerifyHashedPassword(password, user.Password);
        if (result == false)
        {
            throw new Exception("Invalid login or password");
        }
        var token = _jwtProvider.GenerateToken(user);
        return token;
    }
}