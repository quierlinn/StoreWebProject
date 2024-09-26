using System.ComponentModel.DataAnnotations.Schema;

namespace WeaponStore.DataAccess.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string Login{ get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; }
}