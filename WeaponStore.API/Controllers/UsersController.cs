using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeaponStore.Application.Services;
using WeaponStore.Contracts;
using WeaponStore.Core.Abstractions;

namespace WeaponStore.Controllers;
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    [Route("register")]
    [HttpPost]
    public async Task<IResult> Registration(UsersRequest usersRequest)
    {
        _usersService.RegisterUser(usersRequest.Login, usersRequest.Password, usersRequest.Email);
        return Results.Ok();
    }
    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login (UsersRequest usersRequest)
    {
        var token = await _usersService.LoginUser(usersRequest.Login, usersRequest.Password);
        return (IActionResult)Results.Ok(token);
    }
}