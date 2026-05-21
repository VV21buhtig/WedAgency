using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public class ProjectTimelineService : IProjectTimelineService
{
    private readonly WeddingAgencyContext _context;

    public ProjectTimelineService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<TimelineEventItem>> GetEventsAsync(int projectId)
    {
        return await _context.TimelineEvents
            .Where(te => te.Timeline.ProjectId == projectId)
            .Include(te => te.ResponsiblePerson).ThenInclude(pp => pp.Person)
            .OrderBy(te => te.StartTime)
            .Select(te => new TimelineEventItem
            {
                Id = te.Id,
                StartTime = te.StartTime,
                EndTime = te.EndTime,
                Location = te.Location,
                Description = te.EventDescription,
                ResponsiblePerson = te.ResponsiblePerson != null ? te.ResponsiblePerson.Person.FullName : null,
                Notes = te.Notes
            })
            .ToListAsync();
    }
}