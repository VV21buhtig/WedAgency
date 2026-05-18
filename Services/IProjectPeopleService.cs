using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectPeopleService
{
    Task AddClientAsync(int projectId, int personId);
    Task RemoveClientAsync(int projectId, int personId);
    Task<List<ClientListItem>> GetClientsAsync(int projectId);
    Task AddContractorAsync(int projectId, int personId, string? service, decimal? cost, string? notes);
    Task RemoveContractorAsync(int projectId, int personId);
    Task<List<ContractorListItem>> GetContractorsAsync(int projectId);
}