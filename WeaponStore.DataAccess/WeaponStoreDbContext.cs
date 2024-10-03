using Microsoft.EntityFrameworkCore;
using WeaponStore.DataAccess.Entities;

namespace WeaponStore.DataAccess;

public sealed class WeaponStoreDbContext : DbContext
{
    public DbSet<WeaponEntity>Weapons { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public WeaponStoreDbContext(DbContextOptions<WeaponStoreDbContext>options) : base(options)
    {
        
    }

    
}