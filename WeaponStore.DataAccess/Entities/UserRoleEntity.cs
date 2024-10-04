using Microsoft.EntityFrameworkCore;

namespace WeaponStore.DataAccess.Entities;

[Keyless]
public class UserRoleEntity
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}