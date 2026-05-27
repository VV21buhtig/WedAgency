using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public class ProjectVenueService : IProjectVenueService
{
    private readonly WeddingAgencyContext _context;

    public ProjectVenueService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<VenueItemModel>> GetVenuesAsync(int projectId)
    {
        return await _context.VenueBookings
            .Where(vb => vb.ProjectId == projectId)
            .Include(vb => vb.Venue)
            .Select(vb => new VenueItemModel
            {
                BookingId = vb.Id,
                VenueName = vb.Venue.Name,
                Address = vb.Venue.Address,
                City = vb.Venue.City,
                RentalCost = vb.RentalCost,
                DepositAmount = vb.DepositAmount,
                Status = vb.Status,
                EventDate = vb.EventDate
            })
            .ToListAsync();
    }

    public async Task<List<VenuesCatalog>> SearchVenuesAsync(string? search)
    {
        var query = _context.VenuesCatalogs.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(v => v.Name.Contains(search) || v.City.Contains(search));

        return await query.Take(10).ToListAsync();
    }

    public async Task AddVenueAsync(int projectId, int venueId, decimal? rentalCost, decimal? deposit, DateOnly? eventDate)
    {
        var booking = new VenueBooking
        {
            ProjectId = projectId,
            VenueId = venueId,
            RentalCost = rentalCost,
            DepositAmount = deposit,
            EventDate = eventDate,
            Status = "Забронировано"
        };
        _context.VenueBookings.Add(booking);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveVenueAsync(int bookingId)
    {
        var booking = await _context.VenueBookings.FindAsync(bookingId);
        if (booking != null)
        {
            _context.VenueBookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}