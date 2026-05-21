using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectVenueService
{
    Task<List<VenueItemModel>> GetVenuesAsync(int projectId);
}