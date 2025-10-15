using WebApplicationLogin.Models;
namespace WebApplicationLogin.Repositories;

public class UserRepository
{
    private static readonly List<User> _users = new()
    {
        new User {Id = "1", UserName = "admin", Password = "1234"},
        new User {Id = "2", UserName = "erfan", Password = "password"}
    };

    public User? GetUser(string username, string password)
    {
        return _users.FirstOrDefault(u => u.UserName == username && u.Password == password);
    }
}