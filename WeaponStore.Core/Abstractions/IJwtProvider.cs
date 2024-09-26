using WeaponStore.Core.Models;

namespace WeaponStore.Core.Abstractions;

public interface IJwtProvider
{
    public string GenerateToken(User user);
}