namespace WeddingAgency.ViewModels.ProjectDetails;

public class GuestListItem
{
    public int Id { get; init; }
    public int PersonId { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string? Phone { get; init; }
    public string? InvitationStatus { get; init; }
    public string? DietaryRestrictions { get; init; }
    public bool TransferNeeded { get; init; }
    public bool AccommodationNeeded { get; init; }
    public int? TableNumber { get; init; }
}