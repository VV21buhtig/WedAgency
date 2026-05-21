using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectTimelineService
{
    Task<List<TimelineEventItem>> GetEventsAsync(int projectId);
}