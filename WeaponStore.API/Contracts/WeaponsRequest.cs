namespace WeaponStore.Contracts;

public record WeaponsRequest(
    int Id,
    string Name,
    string Description,
    decimal Price
);