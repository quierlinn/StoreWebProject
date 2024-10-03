namespace WeaponStore.Contracts;

public record UsersResponse(
    int UserId,
    string Name,
    string Description,
    decimal Price
);