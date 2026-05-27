using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeddingAgency.Models;

namespace WeddingAgency.Views.Windows;

public partial class SelectVenueWindow : Window
{
    private readonly IServiceProvider _serviceProvider;

    public VenuesCatalog? SelectedVenue { get; private set; }

    public SelectVenueWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
        DataContext = this;
    }

    public List<VenuesCatalog> SearchResults { get; set; } = new();
    public string SearchText { get; set; } = string.Empty;

    private async void Search_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(SearchText)) return;

        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();
        var search = SearchText.ToLower().Trim();
        SearchResults = await context.VenuesCatalogs
            .Where(v => v.Name.ToLower().Contains(search) || v.City.ToLower().Contains(search))
            .Take(15)
            .ToListAsync();
        VenueList.ItemsSource = SearchResults;
    }

    private void Select_Click(object sender, RoutedEventArgs e)
    {
        SelectedVenue = VenueList.SelectedItem as VenuesCatalog;
        DialogResult = SelectedVenue != null;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void VenueList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (VenueList.SelectedItem is VenuesCatalog venue)
        {
            SelectedVenue = venue;
            DialogResult = true;
            Close();
        }
    }

    private void SearchBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            Search_Click(sender, e);
    }
}