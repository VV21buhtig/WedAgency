using CommunityToolkit.Mvvm.ComponentModel;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly IAuthService _authService;

    [ObservableProperty]
    private string _login = string.Empty;

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    public override string Title => "Авторизация";

    public event Action? LoginSucceeded;
    public event Action? ChangePasswordRequired;

    public LoginViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task LoginAsync(string password)
    {
        ErrorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(password))
        {
            ErrorMessage = "Введите логин и пароль";
            return;
        }

        IsBusy = true;

        try
        {
            var user = await _authService.LoginAsync(Login, password);

            if (user == null)
            {
                ErrorMessage = "Неверный логин или пароль";
                return;
            }

            if (!user.IsActive)
            {
                ErrorMessage = "Учётная запись заблокирована";
                return;
            }

            if (user.MustChangePassword)
            {
                ChangePasswordRequired?.Invoke();
            }
            else
            {
                LoginSucceeded?.Invoke();
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
}