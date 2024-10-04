using WeaponStore.Core.Abstractions;
using WeaponStore.Core.Models;
using WeaponStore.DataAccess.Repositories;

namespace WeaponStore.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
    }
}