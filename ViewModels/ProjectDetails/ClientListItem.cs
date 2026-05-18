namespace WeddingAgency.ViewModels.ProjectDetails;

public class ClientListItem
{
    public int PersonId { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string? Phone { get; init; }
    public string? Email { get; init; }
}