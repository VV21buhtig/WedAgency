using System.Windows.Controls;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Finance;

public partial class FinanceView : UserControl
{
    public FinanceView()
    {
        InitializeComponent();
        Loaded += async (_, _) =>
        {
            if (DataContext is FinanceViewModel vm)
                await vm.InitializeAsync();
        };
    }
}