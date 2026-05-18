using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class ProjectDetailsService : IProjectDetailsService
{
    private readonly WeddingAgencyContext _context;

    public ProjectDetailsService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<Project?> GetFullProjectAsync(int projectId)
    {
        return await _context.Projects
            .Include(p => p.ResponsibleManager)
            .Include(p => p.ProjectPeople).ThenInclude(pp => pp.Person)
            .Include(p => p.VenueBookings).ThenInclude(v => v.Venue)
            .Include(p => p.Estimates)
            .Include(p => p.ContractsClient)
            .Include(p => p.Timeline)
            .FirstOrDefaultAsync(p => p.Id == projectId);
    }
}