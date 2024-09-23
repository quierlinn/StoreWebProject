namespace WeaponStore.Contracts;

public record WeaponsResponse(
    int Id,
    string Name,
    string Description,
    decimal Price);