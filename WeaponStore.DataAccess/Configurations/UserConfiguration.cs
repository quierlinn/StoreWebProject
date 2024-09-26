using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeaponStore.DataAccess.Entities;

namespace WeaponStore.DataAccess.Configurations;

public class UserConfiguration
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Login);
        builder.Property(u => u.Password);
        builder.Property(u => u.Email);
    }
}