using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WeaponStore.Core.Abstractions;
using WeaponStore.Core.Models;
using WeaponStore.DataAccess.Entities;

namespace WeaponStore.DataAccess.Repositories;

public class WeaponsRepository: IWeaponsRepository
{
    private WeaponStoreDbContext DbContext { get; }

    public WeaponsRepository(WeaponStoreDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<List<Weapon>> GetWeapons()
    {
        var weaponEntities = await DbContext.Weapons.ToListAsync();
        var weapons = weaponEntities.Select(w => Weapon.Create(w.Id, w.Name, w.Description, w.Price).weapon).ToList();
        return weapons;
    }

    public async Task<int> CreateWeapon(Weapon weapon)
    {
        var weaponEntity = new WeaponEntity
        {
            Id = weapon.Id,
            Name = weapon.Name,
            Description = weapon.Description,
            Price = weapon.Price
        };
        await DbContext.Weapons.AddAsync(weaponEntity);
        await DbContext.SaveChangesAsync();
        return weaponEntity.Id;
    }

    public async Task<int> UpdateWeapons(int id, string name, string description, decimal price)
    {
        var weapon = await DbContext.Weapons.FindAsync(id);
        return id;
    }

    public async Task<int> DeleteWeapons(int id)
    {
        await EntityFrameworkQueryableExtensions.ExecuteDeleteAsync(DbContext.Weapons.Where(b => b.Id == id));
                return id;
    }
}