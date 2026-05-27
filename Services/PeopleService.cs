using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class PeopleService : IPeopleService
{
    private readonly WeddingAgencyContext _context;

    public PeopleService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<Person>> GetAllPeopleAsync()
    {
        return await _context.People
            .Where(p => !p.IsDeleted)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }
    public async Task<Person?> GetByIdAsync(int id)
    {
        return await _context.People.FindAsync(id);
    }
    public async Task<List<Person>> GetFilteredAsync(string? search, string? roleFilter)
    {
        var query = _context.People
            .Where(p => !p.IsDeleted);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.ToLower();
            query = query.Where(p =>
                p.FullName.ToLower().Contains(s) ||
                (p.PhonePrimary ?? "").Contains(s));
        }

        if (!string.IsNullOrWhiteSpace(roleFilter) && roleFilter != "Все")
        {
            switch (roleFilter)
            {
                case "Клиенты":
                    query = query.Where(p => _context.ProjectPeople
                        .Any(pp => pp.PersonId == p.Id && pp.Role == ProjectRoles.Client));
                    break;
                case "Сотрудники":
                    query = query.Where(p => _context.Users
                        .Any(u => u.PersonId == p.Id && u.IsActive));
                    break;
                case "Подрядчики":
                    query = query.Where(p => _context.ProjectPeople
                        .Any(pp => pp.PersonId == p.Id && pp.Role == ProjectRoles.Contractor));
                    break;
            }
        }

        return await query
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task<Person> CreatePersonAsync(string fullName, string? phone, string? email)
    {
        var person = new Person
        {
            FullName = fullName,
            PhonePrimary = phone ?? "-",
            Email = email,
            IsDeleted = false,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        _context.People.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task UpdatePersonAsync(Person person)
    {
        person.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
    }

    public async Task DeactivatePersonAsync(int personId)
    {
        var person = await _context.People.FindAsync(personId);
        if (person != null)
        {
            person.IsDeleted = true;
            person.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<string>> GetRolesAsync(int personId)
    {
        var roles = new List<string>();

        if (await _context.ProjectPeople.AnyAsync(pp => pp.PersonId == personId && pp.Role == ProjectRoles.Client))
            roles.Add("Клиент");

        if (await _context.Users.AnyAsync(u => u.PersonId == personId && u.IsActive))
            roles.Add("Сотрудник");

        if (await _context.ProjectPeople.AnyAsync(pp => pp.PersonId == personId && pp.Role == ProjectRoles.Contractor))
            roles.Add("Подрядчик");

        return roles;
    }
}