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
    [HttpPost]
    public static async Task<IResult> RegisterUser(UserService userService, UsersRequest usersRequest)
    {
        userService.RegisterUser(usersRequest.Login, usersRequest.Password, usersRequest.Email);
        return Results.Ok();
    }
    [HttpPost]
    public static async Task<IResult> LoginUser(UserService userService, UsersRequest usersRequest)
    {
        var token = await userService.Login(usersRequest.Login, usersRequest.Password);
        return Results.Ok(token);
    }
}