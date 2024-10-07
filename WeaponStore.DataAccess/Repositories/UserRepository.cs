using Microsoft.EntityFrameworkCore;
using WeaponStore.Core.Abstractions;
using WeaponStore.Core.Enums;
using WeaponStore.Core.Models;
using WeaponStore.DataAccess.Entities;
using static WeaponStore.DataAccess.Entities.UserEntity;

namespace WeaponStore.DataAccess.Repositories;

public class UserRepository : IUsersRepository
{
    private WeaponStoreDbContext _dbContext;

    public UserRepository(WeaponStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddUsersAsync(User user)
    {
        var userEntity = new UserEntity()
        {
            Id = user.Id,
            Login = user.Login,
            Password = user.Password,
            Email = user.Email,
        };
        await _dbContext.Users.AddAsync(userEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserByLoginAsync(string login)
    {
        var userEntities = await _dbContext.Users.ToListAsync();
        var userEntity = userEntities.FirstOrDefault(u => u.Login == login);
        return new User(userEntity.Id, userEntity.Login, userEntity.Password, userEntity.Email);
    }

    public async Task<HashSet<PermissionEnum>> GetPermissionsAsync(int userId)
    {
        var roles = await _dbContext.Users
            .AsNoTracking()
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .Where(u => u.Id == userId)
            .Select(u => u.Roles)
            .ToArrayAsync();

        return roles
            .SelectMany(r => r)
            .SelectMany(r => r.Permissions)
            .Select(p => (PermissionEnum)p.Id)
            .ToHashSet();
    }
}