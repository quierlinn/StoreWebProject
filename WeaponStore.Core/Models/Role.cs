namespace WeaponStore.Core.Models;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Permission> Permissions { get; }
    public ICollection<User> Users { get; }

    public Role(int id, string name)
    {
        Id = id;
        Name = name;
    }
}