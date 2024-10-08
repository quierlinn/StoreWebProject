using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeaponStore.Application.Services;
using WeaponStore.Contracts;
using WeaponStore.Core.Abstractions;
using System.Web;

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
    [AllowAnonymous]
    [Route("register")]
    [HttpPost]
    public async Task<IResult> Registration(UsersRequest usersRequest)
    {
        await _usersService.RegisterUser(usersRequest.Login, usersRequest.Password, usersRequest.Email);
        return Results.Ok();
    }
    [AllowAnonymous]
    [Route("login")]
    [HttpPost]
    public async Task<IResult> Login (UsersRequest usersRequest)
    {
        var token = await _usersService.LoginUser(usersRequest.Login, usersRequest.Password);
        HttpContext.Response.Cookies.Append("token", token);
        return Results.Ok(token);
    }
}