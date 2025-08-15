using GamesBox.Data;
using GamesBox.Entities;
using GamesBox.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamesBox.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly GamesBoxDbContext _context;

    public UserRepository(GamesBoxDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IEnumerable<User> GetUsers()
    {
        return _context.Users.AsNoTracking().ToList();
    }

    public User GetUserById(Guid userId)
    {
        var user = _context.Users.Find(userId);

        if (user == null)
        {
            throw new KeyNotFoundException($"Entity of type User with key {userId} not found");
        }

        return user;
    }

    public void InsertUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        _context.Users.Add(user);
    }

    public void DeleteUser(Guid userId)
    {   
        var user = _context.Users.Find(userId);
        
        if (user == null)
        {
            throw new KeyNotFoundException($"Entity of type User with key {userId} not found");
        }

        _context.Users.Remove(user);
    }

    public void UpdateUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var existingUser = _context.Users.Find(user.Id);

        if (existingUser == null)
        {
            throw new KeyNotFoundException($"Entity of type User with key {user.Id} not found");
        }

        _context.Entry(user).State = EntityState.Modified;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}