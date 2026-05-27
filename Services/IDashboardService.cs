namespace WeddingAgency.Services;

public interface IDashboardService
{
    Task<DashboardData> GetDashboardDataAsync();
}

public class DashboardData
{
    public int ActiveProjects { get; init; }
    public int TotalClients { get; init; }
    public int TotalGuests { get; init; }
    public int TotalContractors { get; init; }
    public decimal? TotalBudget { get; init; }
    public decimal? TotalPaid { get; init; }
    public List<UpcomingWedding> UpcomingWeddings { get; init; } = new();
}

public class UpcomingWedding
{
    public string? ProjectNumber { get; init; }
    public DateOnly? WeddingDate { get; init; }
    public string? ClientNames { get; init; }
    public string? City { get; init; }
    public int? GuestCount { get; init; }
    public int DaysLeft => WeddingDate.HasValue ? (WeddingDate.Value.ToDateTime(TimeOnly.MinValue) - DateTime.Today).Days : 0;
}