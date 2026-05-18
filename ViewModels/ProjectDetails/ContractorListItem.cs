namespace WeddingAgency.ViewModels.ProjectDetails;

public class ContractorListItem
{
    public int PersonId { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string? Service { get; init; }
    public decimal? Cost { get; init; }
}