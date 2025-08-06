namespace GamesBox.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public User() { }
    
    public User(String name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}