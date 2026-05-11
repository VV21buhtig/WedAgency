using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class MainWindowViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private BaseViewModel? _currentViewModel;

    public override string Title => CurrentViewModel?.Title ?? "Wedding Agency";

    public MainWindowViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        _navigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;

        // Стартовая страница
        _navigationService.NavigateTo<DashboardViewModel>();
    }

    [RelayCommand]
    private void Navigate(string parameter)
    {
        switch (parameter)
        {
            case "Dashboard":
                _navigationService.NavigateTo<DashboardViewModel>();
                break;
            case "People":
                _navigationService.NavigateTo<PeopleViewModel>();
                break;
            case "Projects":
                _navigationService.NavigateTo<ProjectsViewModel>();
                break;
            case "Venues":
                _navigationService.NavigateTo<VenuesViewModel>();
                break;
            case "Finance":
                _navigationService.NavigateTo<FinanceViewModel>();
                break;
            case "Contractors":
                _navigationService.NavigateTo<ContractorsViewModel>();
                break;
        }
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModel = _navigationService.CurrentViewModel;
        OnPropertyChanged(nameof(Title));
    }
}