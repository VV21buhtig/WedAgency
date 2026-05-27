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

  

   
    private void OnGuestsTabSelected(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectDetailsViewModel vm)
            vm.LoadGuestsCommand.Execute(null);
    }

    
    private void OnVenuesTabSelected(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectDetailsViewModel vm)
            vm.LoadVenuesCommand.Execute(null);
    }

    private void OnTimelineTabSelected(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectDetailsViewModel vm)
            vm.LoadTimelineCommand.Execute(null);
    }

    private void OnVenueSearchKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && DataContext is ProjectDetailsViewModel vm)
            vm.SearchVenuesCommand.Execute(null);
    }
}