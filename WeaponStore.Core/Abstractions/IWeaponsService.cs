using WeaponStore.Core.Models;

namespace WeaponStore.Core.Abstractions;

public interface IWeaponsService
{
    public Task<List<Weapon>> GetWeapons();

    public Task<int> CreateWeapon(Weapon weapon);

    public Task<int> UpdateWeapon(int id, string name, string description, decimal price);

    public Task<int> DeleteWeapon(int id);
}