using Microsoft.EntityFrameworkCore;
using BackEndWebAPI.domain.user;
using BackEndWebAPI.interfaces.users;

namespace BackEndWebAPI.infraestructure.users;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await GetUserAsync(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<User> GetUserByUsernameOrEmailAsync(string? username, string? email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username || u.Email == email);
    }
}
