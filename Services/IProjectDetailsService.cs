using WeddingAgency.Models;

namespace WeddingAgency.Services;

public interface IProjectDetailsService
{
    Task<Project?> GetFullProjectAsync(int projectId);
}