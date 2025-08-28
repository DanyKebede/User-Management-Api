using Microsoft.EntityFrameworkCore;
using WebApi.Application;
using WebApi.Data;
using WebApi.Domain;

namespace WebApi.Infrastructure;

public class UserService : IUser
{
    private readonly UserDbContext _context;

    public UserService(UserDbContext userDbContext)
    {
        _context = userDbContext;
    }
    
    public async Task<ICollection<User>> GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }

    public async Task<User> CreateUser(string firstName, string lastName)
    {
        var newUser = new User()
        {
            FirstName = firstName,
            LastName = lastName
        };

        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();

        return newUser;
    }
}