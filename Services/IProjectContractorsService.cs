using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectContractorsService
{
    Task<List<ContractorListItem>> GetContractorsAsync(int projectId);
}