using System.Windows;
using System.Windows.Input;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Windows;

public partial class SelectPersonWindow : Window
{
    private readonly SelectPersonViewModel _viewModel;

    public SelectPersonWindow(SelectPersonViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;

        _viewModel.PersonSelected += (person) =>
        {
            Tag = person;
            DialogResult = person != null;
            Close();
        };
    }

    private void SearchBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            _viewModel.SearchCommand.Execute(null);
    }

    private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (_viewModel.SelectedPerson != null)
            _viewModel.SelectCommand.Execute(_viewModel.SelectedPerson);
    }
}