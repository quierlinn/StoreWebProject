using WeaponStore.Core.Abstractions;

namespace WeaponStore.Infrastructure;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        BCrypt.Net.BCrypt.HashPassword(password);
        return password;
    }

    public bool VerifyHashedPassword(string hashedPassword, string password)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}