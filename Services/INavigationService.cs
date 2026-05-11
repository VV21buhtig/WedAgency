using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.Services;

public interface INavigationService
{
    BaseViewModel? CurrentViewModel { get; }
    event Action? CurrentViewModelChanged;
    void NavigateTo<T>() where T : BaseViewModel;
}