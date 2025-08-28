using WebApi.Domain;

namespace WebApi.Application;

public interface IUser
{
    public Task<ICollection<User>> GetAllUsers();

    public Task<User> CreateUser(string firstName, string lastName);
}