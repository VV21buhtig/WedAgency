using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeddingAgency.Models;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class VenuesViewModel : BaseViewModel
{
    private readonly IVenueCatalogService _venueService;

    [ObservableProperty]
    private ObservableCollection<VenuesCatalog> _venues = new();

    [ObservableProperty]
    private VenuesCatalog? _selectedVenue;

    [ObservableProperty]
    private string _searchText = string.Empty;

    // Поля добавления
    [ObservableProperty]
    private string _newName = string.Empty;

    [ObservableProperty]
    private string? _newAddress;

    [ObservableProperty]
    private string? _newCity;

    [ObservableProperty]
    private decimal? _newRentalCost;

    [ObservableProperty]
    private decimal? _newDeposit;

    public override string Title => "Площадки";

    public VenuesViewModel(IVenueCatalogService venueService)
    {
        _venueService = venueService;
    }

    public async Task InitializeAsync() => await LoadVenues();

    [RelayCommand]
    private async Task LoadVenues()
    {
        IsBusy = true;
        try
        {
            var list = string.IsNullOrWhiteSpace(SearchText)
                ? await _venueService.GetAllAsync()
                : await _venueService.SearchAsync(SearchText);
            Venues = new ObservableCollection<VenuesCatalog>(list);
        }
        finally { IsBusy = false; }
    }

    [RelayCommand]
    private async Task AddVenue()
    {
        if (string.IsNullOrWhiteSpace(NewName)) return;
        await _venueService.CreateAsync(NewName.Trim(), NewAddress, NewCity, NewRentalCost, NewDeposit);
        NewName = string.Empty; NewAddress = null; NewCity = null; NewRentalCost = null; NewDeposit = null;
        await LoadVenues();
    }

    [RelayCommand]
    private async Task UpdateVenue()
    {
        if (SelectedVenue == null) return;
        SelectedVenue.Name = NewName;
        SelectedVenue.Address = NewAddress;
        SelectedVenue.City = NewCity;
        SelectedVenue.RentalCost = NewRentalCost;
        SelectedVenue.FoodDeposit = NewDeposit;
        await _venueService.UpdateAsync(SelectedVenue);
        await LoadVenues();
    }

    [RelayCommand]
    private async Task DeleteVenue()
    {
        if (SelectedVenue == null) return;
        await _venueService.DeleteAsync(SelectedVenue.Id);
        await LoadVenues();
    }

    partial void OnSearchTextChanged(string value) => LoadVenuesCommand.Execute(null);

    partial void OnSelectedVenueChanged(VenuesCatalog? value)
    {
        if (value != null)
        {
            NewName = value.Name;
            NewAddress = value.Address;
            NewCity = value.City;
            NewRentalCost = value.RentalCost;
            NewDeposit = value.FoodDeposit;
        }
    }
}