using System.Windows;
using System.Windows.Input;
using WeddingAgency.ViewModels;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Views.Windows;

public partial class AddContractorWindow : Window
{
    public AddContractorWindow(SelectPersonViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    public PersonSearchResult? SelectedPerson { get; private set; }
    public string? ContractorService { get; private set; }
    public decimal? ContractorCost { get; private set; }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as SelectPersonViewModel;
        if (vm?.SelectedPerson == null) return;

        SelectedPerson = vm.SelectedPerson;
        ContractorService = vm.ContractorService;
        ContractorCost = vm.ContractorCost;
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