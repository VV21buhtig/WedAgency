using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectVenueService
{
    Task<List<VenueItemModel>> GetVenuesAsync(int projectId);
    Task<List<VenuesCatalog>> SearchVenuesAsync(string? search);
    Task AddVenueAsync(int projectId, int venueId, decimal? rentalCost, decimal? deposit, DateOnly? eventDate);
    Task RemoveVenueAsync(int bookingId);
}