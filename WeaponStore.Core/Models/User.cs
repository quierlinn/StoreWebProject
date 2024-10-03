namespace WeaponStore.Core.Models;

public class User
{
    public int Id { get; }
    public string Login { get; }
    public string Password { get; set; }
    public string Email { get; }

    public User(int id, string login, string password, string email)
    {
        Id = id;
        Login = login;
        Password = password;
        Email = email;
    }
    public User(string login, string password, string email)
    {
        Login = login;
        Password = password;
        Email = email;
    }


    public static User Create(string login, string password, string email)
    {
        return new User(login, password, email);
    }
}