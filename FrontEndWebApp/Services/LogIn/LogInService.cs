namespace FrontEndWebApp.Services.LogIn;
using FrontEndWebApp.Services.dto;

public class LogInService
{
    private readonly UserService userService;
    private readonly PasswordHasher<UserDto> passwordHasher = new();

    public LogInService(UserService userService)
    {
        this.userService = userService;
    }

    public async Task<bool> LogInAsync(string email, string password)
    {
        var user = await userService.GetUserByUsernameOrEmailAsync(null, email);

        if (user == null)
        {
            Console.WriteLine("Login failed: user not found.");
            return false;
        }

        var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);
        if (result == PasswordVerificationResult.Success)
        {
            Console.WriteLine($"User {user.Username} logged in successfully.");
            return true;
        }

        Console.WriteLine("Login failed: Invalid password.");
        return false;
    }
}