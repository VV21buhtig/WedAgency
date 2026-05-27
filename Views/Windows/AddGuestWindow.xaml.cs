using System.Windows;
using System.Windows.Input;
using WeddingAgency.ViewModels;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Views.Windows;

public partial class AddGuestWindow : Window
{
    public AddGuestWindow(SelectPersonViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    public PersonSearchResult? SelectedPerson { get; private set; }
    public string? InvitationStatus { get; private set; }
    public string? DietaryRestrictions { get; private set; }
    public bool TransferNeeded { get; private set; }
    public bool AccommodationNeeded { get; private set; }
    public int? TableNumber { get; private set; }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as SelectPersonViewModel;
        if (vm?.SelectedPerson == null) return;

        SelectedPerson = vm.SelectedPerson;
        InvitationStatus = vm.InvitationStatus;
        DietaryRestrictions = vm.DietaryRestrictions;
        TransferNeeded = vm.TransferNeeded;
        AccommodationNeeded = vm.AccommodationNeeded;
        TableNumber = vm.TableNumber;
        DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void SearchBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && DataContext is SelectPersonViewModel vm)
            vm.SearchCommand.Execute(null);
    }
}