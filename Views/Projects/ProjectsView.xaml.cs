using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Projects;

public partial class ProjectsView : UserControl
{
    public ProjectsView()
    {
        InitializeComponent();
        Loaded += async (_, _) =>
        {
            if (DataContext is ProjectsViewModel vm)
                await vm.InitializeAsync();
        };
    }

    private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectsViewModel vm && vm.SelectedProject != null)
        {
            MessageBox.Show($"Открыть проект {vm.SelectedProject.ProjectNumber}", "Проект");
        }
    }
}