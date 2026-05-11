using WeddingAgency.Models;

namespace WeddingAgency.Services;

public interface IUserManagementService
{
    Task<List<User>> GetAllUsersAsync();
    Task CreateUserAsync(string login, string fullName, bool isAdmin = false);
    Task ResetPasswordAsync(int userId);
    Task SetActiveStatusAsync(int userId, bool isActive);
}