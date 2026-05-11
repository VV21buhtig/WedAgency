using System.Windows;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}