namespace FrontEndWebApp.Services.LogIn;

public class LogInService
{
    private readonly UserService userService;

    public LogInService(UserService userService)
    {
        this.userService = userService;
    }

    public async Task<bool> LogInAsync(string email, string password)
    {
        // Here you would typically call an API to validate the user's credentials.
        // For now, we will simulate a login check.
        
        var user = await userService.GetUserByUsernameOrEmailAsync(null, email);
        if (user != null && user.Password == password)
        {
            // Simulate successful login
            Console.WriteLine($"User {user.Username} logged in successfully.");
            return true;
        }

        Console.WriteLine("Login failed: Invalid credentials.");
        return false;
    }
}