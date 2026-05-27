using System.Windows;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Windows;

public partial class CreateProjectWindow : Window
{
    private readonly CreateProjectViewModel _viewModel;

    public CreateProjectWindow(CreateProjectViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;

        _viewModel.ProjectCreated += () =>
        {
            DialogResult = true;
            Close();
        };

        _viewModel.Cancelled += () =>
        {
            DialogResult = false;
            Close();
        };
    }
}