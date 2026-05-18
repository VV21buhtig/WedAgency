using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectOverviewService
{
    Task<ProjectHeaderModel?> GetHeaderAsync(int projectId);
}