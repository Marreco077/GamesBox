using GamesBox.Entities;

namespace GamesBox.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();
    User GetUserById(Guid userId);
    void InsertUser(User user);
    void DeleteUser(Guid userId);
    void UpdateUser(User user);
    void Save();
}