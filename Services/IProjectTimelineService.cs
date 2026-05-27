using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectTimelineService
{
    Task<List<TimelineEventItem>> GetEventsAsync(int projectId);
    Task AddEventAsync(int projectId, DateTime? start, DateTime? end, string? description, string? location, int? responsibleId, string? notes);
    Task DeleteEventAsync(int eventId);
}