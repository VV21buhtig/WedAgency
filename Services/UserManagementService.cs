using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class UserManagementService : IUserManagementService
{
    private readonly WeddingAgencyContext _context;

    public UserManagementService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<Models.User>> GetAllUsersAsync()
    {
        return await _context.Users
            .Include(u => u.Person)
            .ToListAsync();
    }

    public async Task CreateUserAsync(string login, string fullName, bool isAdmin = false)
    {
        if (await _context.Users.AnyAsync(u => u.Login == login))
            throw new InvalidOperationException("Пользователь с таким логином уже существует.");

        var person = new Person
        {
            FullName = fullName,
            PhonePrimary = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        _context.People.Add(person);
        await _context.SaveChangesAsync();

        var user = new Models.User
        {
            Login = login,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("1"),
            IsAdmin = isAdmin,
            MustChangePassword = true,
            IsActive = true,
            PersonId = person.Id,
            CreatedAt = DateTime.Now
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task ResetPasswordAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user is null) return;

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword("1");
        user.MustChangePassword = true;
        await _context.SaveChangesAsync();
    }

    public async Task SetActiveStatusAsync(int userId, bool isActive)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user is null) return;

        user.IsActive = isActive;
        await _context.SaveChangesAsync();
    }
}