using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class ChangePasswordViewModel : BaseViewModel
{
    private readonly IAuthService _authService;

    [ObservableProperty]
    private string _newPassword = string.Empty;

    [ObservableProperty]
    private string _confirmPassword = string.Empty;

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    public override string Title => "Смена пароля";

    public event Action? PasswordChanged;

    public ChangePasswordViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [RelayCommand]
    private async Task ChangePasswordAsync()
    {
        ErrorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(NewPassword) || string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            ErrorMessage = "Заполните все поля";
            return;
        }

        if (NewPassword.Length < 4)
        {
            ErrorMessage = "Пароль должен быть не менее 4 символов";
            return;
        }

        if (NewPassword != ConfirmPassword)
        {
            ErrorMessage = "Пароли не совпадают";
            return;
        }

        var user = _authService.CurrentUser;
        if (user == null)
        {
            ErrorMessage = "Ошибка сессии";
            return;
        }

        IsBusy = true;

        try
        {
            await _authService.ChangePasswordAsync(user, NewPassword);
            PasswordChanged?.Invoke();
        }
        finally
        {
            IsBusy = false;
        }
    }
}