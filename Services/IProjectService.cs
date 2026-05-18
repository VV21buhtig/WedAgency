using WeddingAgency.Models;

namespace WeddingAgency.Services;

public interface IProjectService
{
    Task<List<Project>> GetAllProjectsAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<Project> CreateProjectAsync(string projectNumber, DateOnly? weddingDate, int? guestCount, decimal? budget, string? city, int? managerId);
    Task UpdateProjectAsync(Project project);
    Task DeactivateProjectAsync(int projectId);
    Task<string> GetClientNamesAsync(int projectId);
}