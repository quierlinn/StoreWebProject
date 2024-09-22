using WeaponStore.Core.Models;

namespace WeaponStore.Core.Abstractions;

public interface IWeaponsRepository
{
    public Task<List<Weapon>> GetWeapons();

    public Task<int> CreateWeapon(Weapon weapon);

    public Task<int> UpdateWeapons(int id, string name, string description, decimal price);
    public Task<int> DeleteWeapons(int id);
}