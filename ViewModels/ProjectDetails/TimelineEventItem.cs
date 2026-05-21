namespace WeddingAgency.ViewModels.ProjectDetails;

public class TimelineEventItem
{
    public int Id { get; init; }
    public DateTime? StartTime { get; init; }
    public DateTime? EndTime { get; init; }
    public string? Location { get; init; }
    public string? Description { get; init; }
    public string? ResponsiblePerson { get; init; }
    public string? Notes { get; init; }
}