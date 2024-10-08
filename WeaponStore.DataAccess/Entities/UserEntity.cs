﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WeaponStore.DataAccess.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string Login{ get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public ICollection<RoleEntity> Roles { get; set; } = [];
}