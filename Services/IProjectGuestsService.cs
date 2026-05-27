using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectGuestsService
{
    Task<List<GuestListItem>> GetGuestsAsync(int projectId);
    Task AddGuestAsync(int projectId, int personId);
    Task RemoveGuestAsync(int projectId, int personId);
    Task UpdateGuestAsync(int projectPersonId, string? invitationStatus, string? dietary, bool transfer, bool accommodation, int? tableNumber);
}