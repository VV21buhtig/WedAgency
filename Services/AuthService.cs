using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class AuthService : IAuthService
{
    private readonly WeddingAgencyContext _context;

    public User? CurrentUser { get; private set; }

    public AuthService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<User?> LoginAsync(string login, string password)
    {
        var user = await _context.Users
            .Include(u => u.Person)
            .FirstOrDefaultAsync(u => u.Login == login);

        if (user == null)
            return null;

        if (!user.IsActive)
            return null;

        if (user.PasswordHash != password)
            return null;

        CurrentUser = user;
        user.LastLogin = DateTime.Now;
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task ChangePasswordAsync(User user, string newPassword)
    {
        user.PasswordHash = newPassword; 
        user.MustChangePassword = false;
        user.LastLogin = DateTime.Now;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}