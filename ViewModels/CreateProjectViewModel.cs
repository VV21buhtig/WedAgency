using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using WeddingAgency.Models;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class CreateProjectViewModel : BaseViewModel
{
    private readonly IProjectService _projectService;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private string _projectNumber = string.Empty;

    [ObservableProperty]
    private DateOnly? _weddingDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(3));

    [ObservableProperty]
    private string? _locationCity;

    [ObservableProperty]
    private decimal? _budgetTotal;

    [ObservableProperty]
    private int? _guestCount = 50;

    [ObservableProperty]
    private string _status = "Новый";

    [ObservableProperty]
    private ObservableCollection<User> _managers = new();

    [ObservableProperty]
    private User? _selectedManager;

    public event Action? ProjectCreated;
    public event Action? Cancelled;

    public override string Title => "Новый проект";

    public CreateProjectViewModel(IProjectService projectService, IServiceProvider serviceProvider)
    {
        _projectService = projectService;
        _serviceProvider = serviceProvider;
        ProjectNumber = "PRJ-" + DateTime.Now.ToString("yyyyMMdd-HHmm");
        _ = LoadManagersAsync();
    }

    private async Task LoadManagersAsync()
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();
        var users = await context.Users
            .Include(u => u.Person)
            .Where(u => u.IsActive)
            .ToListAsync();
        Managers = new ObservableCollection<User>(users);
    }

    [RelayCommand]
    private async Task CreateAsync()
    {
        if (string.IsNullOrWhiteSpace(ProjectNumber))
            return;

        await _projectService.CreateProjectAsync(
            ProjectNumber,
            WeddingDate,
            GuestCount,
            BudgetTotal,
            LocationCity,
            SelectedManager?.PersonId);

        ProjectCreated?.Invoke();
    }

    [RelayCommand]
    private void Cancel()
    {
        Cancelled?.Invoke();
    }
}