using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeaponStore.DataAccess.Entities;

namespace WeaponStore.DataAccess.Configurations;

public class WeaponConfiguration
{
    public void Configure(EntityTypeBuilder<WeaponEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Description).IsRequired();
        builder.Property(e => e.Price).IsRequired();
    }
}