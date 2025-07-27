namespace FrontEndWebApp.Services.Users
{
    using System;
    using System.Threading.Tasks;
    using FrontEndWebApp.Dto;
    using FrontEndWebApp.services;

    public class UserService
    {
        private readonly ApiClient apiClient;

        public string BaseUrl = "/users";


        public UserService(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            return await apiClient.GetFromJsonAsync<UserDto>($"users/{id}");
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var response = await apiClient.PostAsJsonAsync("users", userDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserDto>();
        }
    }
}