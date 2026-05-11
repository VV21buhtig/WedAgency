using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WeddingAgency.Services;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Windows;

public partial class ChangePasswordWindow : Window
{
    private readonly ChangePasswordViewModel _viewModel;
    private readonly IServiceProvider _serviceProvider;

    public ChangePasswordWindow(ChangePasswordViewModel viewModel, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _viewModel = viewModel;
        _serviceProvider = serviceProvider;
        DataContext = _viewModel;

        _viewModel.PasswordChanged += OnPasswordChanged;

        Closed += (_, _) =>
        {
            _viewModel.PasswordChanged -= OnPasswordChanged;
        };
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.NewPassword = NewPasswordBox.Password;
        _viewModel.ConfirmPassword = ConfirmPasswordBox.Password;
        await _viewModel.ChangePasswordCommand.ExecuteAsync(null);
    }

    private void OnPasswordChanged()
    {
        var authService = _serviceProvider.GetRequiredService<IAuthService>();
        if (authService.CurrentUser?.IsAdmin == true)
        {
            var adminWindow = _serviceProvider.GetRequiredService<AdminWindow>();
            adminWindow.Show();
        }
        else
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
        Close();
    }
}