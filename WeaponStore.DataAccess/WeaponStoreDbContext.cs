using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WeaponStore.DataAccess.Configurations;
using WeaponStore.DataAccess.Entities;

namespace WeaponStore.DataAccess;

public class WeaponStoreDbContext : DbContext
{
    private readonly IOptions<AuthorizationOptions> _authOptions;
    public DbSet<WeaponEntity> Weapons { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UserRoleEntity> UserRoles { get; set; }

    public WeaponStoreDbContext(DbContextOptions<WeaponStoreDbContext> options,
        IOptions<AuthorizationOptions> authOptions) : base(options)
    {
        _authOptions = authOptions;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(_authOptions.Value));
    }
}