using WeddingAgency.Models;

namespace WeddingAgency.Services;

public interface IPeopleService
{
    Task<List<Person>> GetAllPeopleAsync();
    Task<List<Person>> GetFilteredAsync(string? search, string? roleFilter);
    Task<Person?> GetByIdAsync(int id);
    Task UpdatePersonAsync(Person person);
    Task DeactivatePersonAsync(int personId);
    Task<Person> CreatePersonAsync(string fullName, string? phone, string? email);
    Task<List<string>> GetRolesAsync(int personId);
}