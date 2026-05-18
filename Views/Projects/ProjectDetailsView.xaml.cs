using System.Windows.Controls;
using System.Windows.Input;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Projects;

public partial class ProjectDetailsView : UserControl
{
    public ProjectDetailsView()
    {
        InitializeComponent();
    }

    private void OnClientsTabSelected(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectDetailsViewModel vm)
            vm.LoadClientsCommand.Execute(null);
    }

    private void OnContractorsTabSelected(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectDetailsViewModel vm)
            vm.LoadContractorsCommand.Execute(null);
    }

    private void OnFinanceTabSelected(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectDetailsViewModel vm)
            vm.LoadFinanceCommand.Execute(null);
    }

    private void OnClientSearchKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && DataContext is ProjectDetailsViewModel vm)
            vm.SearchClientsCommand.Execute(null);
    }

    private void OnContractorSearchKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && DataContext is ProjectDetailsViewModel vm)
            vm.SearchContractorsCommand.Execute(null);
    }
}