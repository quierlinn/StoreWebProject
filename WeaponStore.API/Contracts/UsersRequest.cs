namespace WeaponStore.Contracts;

public record UsersRequest(
    string Login,
    string Password,
    string Email
);