namespace WeaponStore.Contracts;

public record WeaponsResponse(
    int id,
    string name,
    string description,
    decimal Price);