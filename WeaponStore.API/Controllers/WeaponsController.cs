using Microsoft.AspNetCore.Mvc;
using WeaponStore.Contracts;
using WeaponStore.Core.Abstractions;

namespace WeaponStore.Controllers;
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
        var weaponsResponse = weapons.Select( w => new WeaponsResponse(w.Id, w.Name, w.Description, w.Price ));
        return Ok(weaponsResponse);
    }
    
}