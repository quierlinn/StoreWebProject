using Microsoft.EntityFrameworkCore;
using WeaponStore.Core.Abstractions;
using WeaponStore.Core.Enums;
using WeaponStore.Core.Models;
using WeaponStore.DataAccess;
using WeaponStore.DataAccess.Configurations;

namespace WeaponStore.Application.Services;

public class PermissionService : IPermissionService
{
    private readonly IUsersRepository _usersRepository;

    public PermissionService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public Task<HashSet<PermissionEnum>> GetAllPermissionsAsync(int userId)
    {
        return _usersRepository.GetPermissionsAsync(userId);
    }
    
}