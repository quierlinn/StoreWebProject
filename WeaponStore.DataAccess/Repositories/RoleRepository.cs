using WeaponStore.Core.Abstractions;
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
    
}