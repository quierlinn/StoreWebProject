using WeaponStore.Core.Abstractions;
using WeaponStore.Core.Models;

namespace WeaponStore.Application.Services;

public class UserService : IUsersService
{ 
    private IPasswordHasher _passwordHasher;
    private IUsersRepository _usersRepository;
    private IJwtProvider _jwtProvider;

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

    public async Task<string> Login(string login, string password)
    {
        var user = await _usersRepository.GetUserByLoginAsync(login);
        var result = _passwordHasher.VerifyHashedPassword(user.Password, password);
        if (result == false)
        {
            throw new Exception($"Invalid login or password");
        }

        var token = _jwtProvider.GenerateToken(user);
        return token;
    }
}