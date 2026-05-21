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
}