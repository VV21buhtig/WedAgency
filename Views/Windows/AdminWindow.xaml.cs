using System.Windows;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Windows;

public partial class AdminWindow : Window
{
    private readonly AdminUsersViewModel _viewModel;

    public AdminWindow(AdminUsersViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;

        _viewModel.InfoMessage += (_, msg) =>
            MessageBox.Show(msg, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

        _viewModel.ErrorMessage += (_, msg) =>
            MessageBox.Show(msg, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        Loaded += async (_, _) => await _viewModel.InitializeAsync();
    }
}