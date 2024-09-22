using Microsoft.EntityFrameworkCore;
using WeaponStore.DataAccess.Entities;

namespace WeaponStore.DataAccess;

public class WeaponStoreDbContext : DbContext
{
    public DbSet<WeaponEntity>Weapons { get; set; }
    public WeaponStoreDbContext(DbContextOptions<WeaponStoreDbContext>options) : base(options)
    {
        Database.EnsureCreated();
    }

    
}