using System.Windows.Controls;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.People;

public partial class PeopleView : UserControl
{
    public PeopleView()
    {
        InitializeComponent();
        Loaded += async (_, _) =>
        {
            if (DataContext is PeopleViewModel vm)
                await vm.InitializeAsync();
        };
    }
}