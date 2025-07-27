namespace BackEndWebAPI.interfaces.users;

using BackEndWebAPI.domain.user;

    
public interface IUserRepository
{
    Task<User> GetUserAsync(int id);
    Task<User> CreateUserAsync(User user);
    Task<bool> DeleteUserAsync(int id);
    Task<User> GetUserByUsernameOrEmailAsync(string? username, string? email);
}

