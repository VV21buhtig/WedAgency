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

    public async Task AddEventAsync(int projectId, DateTime? start, DateTime? end, string? description, string? location, int? responsiblePersonId, string? notes)
    {
        // 1. Убедимся, что у проекта есть таймлайн
        var timeline = await _context.Timelines.FirstOrDefaultAsync(t => t.ProjectId == projectId);
        if (timeline == null)
        {
            timeline = new Timeline
            {
                ProjectId = projectId,
                Status = "Активен"
            };
            _context.Timelines.Add(timeline);
            await _context.SaveChangesAsync();
        }

        // 2. Находим ProjectPerson для ответственного
        // Ответственный должен быть связан с этим проектом.
        // Если responsiblePersonId null, то и ResponsiblePersonId в событии будет null.
        int? projectPersonId = null;

        if (responsiblePersonId.HasValue)
        {
            var projectPerson = await _context.ProjectPeople
                .FirstOrDefaultAsync(pp => pp.ProjectId == projectId && pp.PersonId == responsiblePersonId.Value);

            if (projectPerson != null)
            {
                projectPersonId = projectPerson.Id;
            }
            // Если человек не добавлен в проект ни в какой роли, 
            // мы можем либо добавить его автоматически, либо оставить null.
            // В данном случае оставим null, чтобы не ломать логику ролей, 
            // либо можно добавить его как "Coordinator" или другую роль, если требуется.
        }

        var eventItem = new TimelineEvent
        {
            TimelineId = timeline.Id,
            StartTime = start,
            EndTime = end,
            EventDescription = description,
            Location = location,
            ResponsiblePersonId = projectPersonId, // Используем ID из ProjectPeople
            Notes = notes
        };

        _context.TimelineEvents.Add(eventItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEventAsync(int eventId)
    {
        var eventItem = await _context.TimelineEvents.FindAsync(eventId);
        if (eventItem != null)
        {
            _context.TimelineEvents.Remove(eventItem);
            await _context.SaveChangesAsync();
        }
    }
}