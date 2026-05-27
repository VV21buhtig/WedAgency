using System.Windows.Controls;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Venues;

public partial class VenuesView : UserControl
{
    public VenuesView()
    {
        InitializeComponent();
        Loaded += async (_, _) =>
        {
            if (DataContext is VenuesViewModel vm)
                await vm.InitializeAsync();
        };
    }
}