using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectGuestsService
{
    Task<List<GuestListItem>> GetGuestsAsync(int projectId);
    Task AddGuestAsync(int projectId, int personId);
    Task RemoveGuestAsync(int projectId, int personId);
}