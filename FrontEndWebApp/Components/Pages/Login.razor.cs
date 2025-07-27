using Microsoft.AspNetCore.Components;

namespace FrontEndWebApp.Components.Pages
{
    public partial class Login : ComponentBase
    {
        private LoginModel loginModel = new();

        private async Task HandleValidSubmit()
        {
            // Replace this with your login logic (e.g., call an API or service)
            Console.WriteLine($"Logging in: {loginModel.Email}");
            // Example: await AuthService.LoginAsync(loginModel);
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}