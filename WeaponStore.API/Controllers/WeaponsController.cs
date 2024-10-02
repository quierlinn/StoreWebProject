using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeaponStore.Contracts;
using WeaponStore.Core.Abstractions;
using WeaponStore.Core.Models;

namespace WeaponStore.Controllers;
[Authorize]
[ApiController]
[Route("[Controller]")]
public class WeaponsController : ControllerBase
{
    private readonly IWeaponsService _weaponsService;

    public WeaponsController(IWeaponsService weaponsService)
    {
        _weaponsService = weaponsService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var weapons = await _weaponsService.GetWeapons();
        var weaponsResponse = weapons.Select(w => new WeaponsResponse(w.Id, w.Name, w.Description, w.Price));
        return Ok(weaponsResponse);
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] WeaponsRequest request)
    {
        var (weapon, error) = Weapon.Create(
            request.Name,
            request.Description,
            request.Price);
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var weaponId = await _weaponsService.CreateWeapon(weapon);

        return Ok(weaponId);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] WeaponsRequest request)
    {
        var weaponId = await _weaponsService.UpdateWeapon(id, request.Name, request.Description, request.Price);
        return Ok(weaponId);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _weaponsService.DeleteWeapon(id));
    }
}