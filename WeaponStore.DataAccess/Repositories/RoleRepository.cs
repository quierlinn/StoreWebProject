using Microsoft.EntityFrameworkCore;
using WeaponStore.Core.Abstractions;
using WeaponStore.Core.Enums;
using WeaponStore.Core.Models;
using WeaponStore.DataAccess.Entities;

namespace WeaponStore.DataAccess.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly WeaponStoreDbContext _context;

    public RoleRepository(WeaponStoreDbContext dbContext)
    {
        _context = dbContext;
    }
    

    public async Task<Role> GetRoleByUserIdAsync(int userID)
    {
        var role = await _context.UserRoles
            .Where(ur => ur.UserId == userID)
            .Select(ur => (RoleEnum)ur.RoleId)
            .FirstOrDefaultAsync(); 
        return new Role((int)role, role.ToString());
    }
}