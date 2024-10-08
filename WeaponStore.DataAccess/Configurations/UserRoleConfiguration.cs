using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeaponStore.DataAccess.Entities;

namespace WeaponStore.DataAccess.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
{
    public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
    {
        builder.HasKey(u => new { u.UserId, u.RoleId});
        builder.HasData(
            new UserRoleEntity
            {
                UserId = 1,
                RoleId = 1,
            });
    }
}