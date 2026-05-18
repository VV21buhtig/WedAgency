using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectClientsService
{
    Task<List<ClientListItem>> GetClientsAsync(int projectId);
}