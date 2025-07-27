using Microsoft.AspNetCore.Components;

namespace FrontEndWebApp.Components.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject] private LogInService LogInService { get; set; }
        private LoginModel loginModel = new();
        private string message;

        private async Task HandleValidSubmit()
        {
            var success = await LogInService.LogInAsync(loginModel.Email, loginModel.Password);

            if (success)
            {
                message = "Login successful!";
                // You could redirect or set a token here.
            }
            else
            {
                message = "Invalid email or password.";
            }
        }


        public class LoginModel
        {
            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }
        }
    }
}