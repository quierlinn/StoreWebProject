namespace WeaponStore.Core.Models;

public class Permission
{
    public int Id { get; }
    public ICollection<Role> Roles { get; }
}