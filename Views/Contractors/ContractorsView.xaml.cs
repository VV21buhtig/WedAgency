using System.Windows.Controls;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Contractors;

public partial class ContractorsView : UserControl
{
    public ContractorsView()
    {
        InitializeComponent();
        Loaded += async (_, _) =>
        {
            if (DataContext is ContractorsViewModel vm)
                await vm.InitializeAsync();
        };
    }
}