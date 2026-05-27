using System.Windows.Controls;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Dashboard;

public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();
        Loaded += async (_, _) =>
        {
            if (DataContext is DashboardViewModel vm)
                await vm.InitializeAsync();
        };
    }
}