using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Windows;

public partial class LoginWindow : Window
{
    private readonly LoginViewModel _viewModel;
    private readonly IServiceProvider _serviceProvider;

    public LoginWindow(LoginViewModel viewModel, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _viewModel = viewModel;
        _serviceProvider = serviceProvider;
        DataContext = _viewModel;

        _viewModel.LoginSucceeded += OnLoginSucceeded;
        _viewModel.ChangePasswordRequired += OnChangePasswordRequired;

        Closed += (_, _) =>
        {
            _viewModel.LoginSucceeded -= OnLoginSucceeded;
            _viewModel.ChangePasswordRequired -= OnChangePasswordRequired;
        };
    }

    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        await _viewModel.LoginAsync(PasswordBox.Password);
    }

    private void OnLoginSucceeded()
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        Close();
    }

    private void OnChangePasswordRequired()
    {
        var changePasswordWindow = _serviceProvider.GetRequiredService<ChangePasswordWindow>();
        changePasswordWindow.Show();
        Close();
    }
}