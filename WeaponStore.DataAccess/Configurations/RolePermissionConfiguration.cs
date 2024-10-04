using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeaponStore.Core.Enums;
using WeaponStore.Core.Models;
using WeaponStore.DataAccess.Entities;

namespace WeaponStore.DataAccess.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissionEntity>
{
    private readonly AuthorizationOptions _authorizationOtpions;

    public RolePermissionConfiguration(AuthorizationOptions authorizationOtpions)
    {
        _authorizationOtpions = authorizationOtpions;
    }
    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
        builder.HasKey(r => new { r.RoleId, r.PermissionId });
        builder.HasData(_authorizationOtpions.RolePermissions.SelectMany<RolePermissions, RolePermissionEntity>(rp => rp.Permission.Select(p => new RolePermissionEntity
        {
            RoleId = (int)Enum.Parse<RoleEnum>(rp.Role),
            PermissionId = (int)Enum.Parse<PermissionEnum>(p)
        })).ToArray());
    }
}