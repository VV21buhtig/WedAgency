using CommunityToolkit.Mvvm.ComponentModel;

namespace WeddingAgency.ViewModels;

public partial class ProjectListItem : ObservableObject
{
    public int Id { get; init; }
    public string ProjectNumber { get; init; } = string.Empty;
    public DateOnly? WeddingDate { get; init; }
    public string? LocationCity { get; init; }
    public decimal? BudgetTotal { get; init; }
    public int? GuestCountMin { get; init; }
    public string Status { get; init; } = string.Empty;
    public string? ManagerName { get; init; }
    public string ClientsDisplay { get; init; } = "Нет клиентов";
}