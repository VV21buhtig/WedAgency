using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class DashboardViewModel : BaseViewModel
{
    private readonly IDashboardService _dashboardService;

    [ObservableProperty]
    private DashboardData? _data;

    [ObservableProperty]
    private ObservableCollection<UpcomingWedding> _upcomingWeddings = new();

    public override string Title => "Дашборд";

    public DashboardViewModel(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    public async Task InitializeAsync() => await LoadDashboard();

    [RelayCommand]
    private async Task LoadDashboard()
    {
        IsBusy = true;
        try
        {
            Data = await _dashboardService.GetDashboardDataAsync();
            UpcomingWeddings = new ObservableCollection<UpcomingWedding>(Data?.UpcomingWeddings ?? new List<UpcomingWedding>());
        }
        finally { IsBusy = false; }
    }
}