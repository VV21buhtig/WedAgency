namespace WeddingAgency.ViewModels.ProjectDetails;

public class ProjectDetailsModel
{
    public int Id { get; init; }
    public string ProjectNumber { get; init; } = string.Empty;
    public DateOnly? WeddingDate { get; init; }
    public string Status { get; init; } = string.Empty;
    public decimal? BudgetTotal { get; init; }
    public int? GuestCountMin { get; init; }
    public string? LocationCity { get; init; }
    public string? ManagerName { get; init; }
}