using CommunityToolkit.Mvvm.ComponentModel;

namespace WeddingAgency.ViewModels.ProjectDetails;

public partial class GuestListItem : ObservableObject
{
    public int Id { get; init; }
    public int PersonId { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string? Phone { get; init; }

    [ObservableProperty]
    private string? _invitationStatus;

    [ObservableProperty]
    private string? _dietaryRestrictions;

    [ObservableProperty]
    private bool _transferNeeded;

    [ObservableProperty]
    private bool _accommodationNeeded;

    [ObservableProperty]
    private int? _tableNumber;
}