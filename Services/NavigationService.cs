using Microsoft.Extensions.DependencyInjection;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private BaseViewModel? _currentViewModel;

    public BaseViewModel? CurrentViewModel
    {
        get => _currentViewModel;
        private set
        {
            _currentViewModel = value;
            CurrentViewModelChanged?.Invoke();
        }
    }

    public event Action? CurrentViewModelChanged;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void NavigateTo<T>() where T : BaseViewModel
    {
        var viewModel = _serviceProvider.GetRequiredService<T>();
        CurrentViewModel = viewModel;
    }

    public void NavigateTo<T>(object? parameter) where T : BaseViewModel
    {
        var viewModel = _serviceProvider.GetRequiredService<T>();

        if (viewModel is INavigationAware aware)
            aware.OnNavigatedTo(parameter);

        CurrentViewModel = viewModel;
    }
}