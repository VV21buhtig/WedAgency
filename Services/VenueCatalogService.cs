using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class VenueCatalogService : IVenueCatalogService
{
    private readonly WeddingAgencyContext _context;

    public VenueCatalogService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<VenuesCatalog>> GetAllAsync()
    {
        return await _context.VenuesCatalogs.ToListAsync();
    }

    public async Task<List<VenuesCatalog>> SearchAsync(string? search)
    {
        var query = _context.VenuesCatalogs.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(v => v.Name.Contains(search) || v.City.Contains(search) || v.Address.Contains(search));
        return await query.Take(20).ToListAsync();
    }

    public async Task<VenuesCatalog> CreateAsync(string name, string? address, string? city, decimal? rentalCost, decimal? deposit)
    {
        var venue = new VenuesCatalog
        {
            Name = name,
            Address = address,
            City = city,
            RentalCost = rentalCost,
            FoodDeposit = deposit
        };
        _context.VenuesCatalogs.Add(venue);
        await _context.SaveChangesAsync();
        return venue;
    }

    public async Task UpdateAsync(VenuesCatalog venue)
    {
        _context.VenuesCatalogs.Update(venue);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var venue = await _context.VenuesCatalogs.FindAsync(id);
        if (venue != null)
        {
            _context.VenuesCatalogs.Remove(venue);
            await _context.SaveChangesAsync();
        }
    }
}