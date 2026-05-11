using WeddingAgency.Models;

namespace WeddingAgency.Services;

public interface IAuthService
{
    Task<User?> LoginAsync(string login, string password);
    Task ChangePasswordAsync(User user, string newPassword);
    User? CurrentUser { get; }
}