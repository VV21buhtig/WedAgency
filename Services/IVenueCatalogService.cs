using WeddingAgency.Models;

namespace WeddingAgency.Services;

public interface IVenueCatalogService
{
    Task<List<VenuesCatalog>> GetAllAsync();
    Task<List<VenuesCatalog>> SearchAsync(string? search);
    Task<VenuesCatalog> CreateAsync(string name, string? address, string? city, decimal? rentalCost, decimal? deposit);
    Task UpdateAsync(VenuesCatalog venue);
    Task DeleteAsync(int id);
}