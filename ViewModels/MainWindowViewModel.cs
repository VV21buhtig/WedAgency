using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;
using WeddingAgency.Views.Windows;

namespace WeddingAgency.ViewModels;

public partial class MainWindowViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private BaseViewModel? _currentViewModel;

    public override string Title => CurrentViewModel?.Title ?? "Wedding Agency";

    public MainWindowViewModel(INavigationService navigationService, IServiceProvider serviceProvider)
    {
        _navigationService = navigationService;
        _serviceProvider = serviceProvider;
        _navigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;
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

    [RelayCommand]
    private void Logout()
    {
        // Закрываем главное окно
        var mainWindow = Application.Current.Windows
            .OfType<MainWindow>()
            .FirstOrDefault();
        mainWindow?.Close();

        // Открываем окно логина
        var loginWindow = _serviceProvider.GetRequiredService<LoginWindow>();
        loginWindow.Show();
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModel = _navigationService.CurrentViewModel;
        OnPropertyChanged(nameof(Title));
    }
}