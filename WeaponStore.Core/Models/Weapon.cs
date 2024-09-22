namespace WeaponStore.Core.Models;

public class Weapon
{
    public int Id { get;}
    public string Name{ get;} = string.Empty;
    public string Description { get;} = string.Empty;
    public decimal Price { get;}

    public Weapon(int id, string name, string description, decimal price)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
    }

    public static (Weapon weapon, string error) Create(int id, string name, string description, decimal price)
    {
        var error = string.Empty;
        var weapon = new Weapon(id, name, description, price);
        if (string.IsNullOrWhiteSpace(name))
        {
            error = "Name is required";
        }
        return (weapon, error);
    }
}