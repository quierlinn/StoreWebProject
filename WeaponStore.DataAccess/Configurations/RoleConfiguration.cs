using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeaponStore.Core.Enums;
using WeaponStore.DataAccess.Entities;
using Role = WeaponStore.Core.Models.Role;
using RoleEntity = WeaponStore.DataAccess.Entities.RoleEntity;

namespace WeaponStore.DataAccess.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{

    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasKey(re => re.Id);
                builder.HasMany(r => r.Permissions).WithMany(p => p.Roles).UsingEntity<RolePermissionEntity>(
                    l => l.HasOne<PermissionEntity>().WithMany().HasForeignKey(e => e.PermissionId),
                    r => r.HasOne<RoleEntity>().WithMany().HasForeignKey(e => e.RoleId));
                var roles = Enum.GetValues<RoleEnum>().Select(r => new RoleEntity
                { 
                    Id = (int)r,
                    Name = r.ToString()
                });
                builder.HasData(roles);
    }
}