namespace WeddingAgency.ViewModels.ProjectDetails;

public class VenueItemModel
{
    public int BookingId { get; init; }
    public string? VenueName { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
    public decimal? RentalCost { get; init; }
    public decimal? DepositAmount { get; init; }
    public string? Status { get; init; }
    public DateOnly? EventDate { get; init; }
}