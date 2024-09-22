using WeaponStore.Core.Abstractions;
using WeaponStore.Core.Models;

namespace WeaponStore.Application.Services;

public class WeaponsService : IWeaponsService
{
    private readonly IWeaponsRepository _weaponsRepository;

    public WeaponsService(IWeaponsRepository weaponsRepository)
    {
        _weaponsRepository = weaponsRepository;
    }


    public async Task<List<Weapon>> GetWeapons()
    {
        return await _weaponsRepository.GetWeapons();
    }

    public async Task<int> CreateWeapon(Weapon weapon)
    {
        return await _weaponsRepository.CreateWeapon(weapon);
    }

    public async Task<int> UpdateWeapon(int id, string name, string description, decimal price)
    {
        return await _weaponsRepository.UpdateWeapons(id, name, description, price);
    }

    public async Task<int> DeleteWeapon(int id)
    {
        return await _weaponsRepository.DeleteWeapons(id);
    }
}