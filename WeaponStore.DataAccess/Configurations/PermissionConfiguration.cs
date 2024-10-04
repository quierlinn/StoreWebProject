using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeaponStore.Core.Enums;
using WeaponStore.Core.Models;
using WeaponStore.DataAccess.Entities;

namespace WeaponStore.DataAccess.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<PermissionEntity>
{
    public void Configure(EntityTypeBuilder<PermissionEntity> builder)
    {
        builder.HasKey(p=> p.Id);
        var permissions = Enum.GetValues<PermissionEnum>().Select(p => new PermissionEntity
        {
            Id = (int)p,
            Name = p.ToString()
        });
        builder.HasData(permissions);
    }
}