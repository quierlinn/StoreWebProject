namespace WeaponStore.Contracts;

public record WeaponsRequest(
    string Name,
    string Description,
    decimal Price
);