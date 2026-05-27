using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.Base;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.ViewModels;

public partial class SelectPersonViewModel : BaseViewModel
{
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<PersonSearchResult> _searchResults = new();

    [ObservableProperty]
    private PersonSearchResult? _selectedPerson;

    // Поля для гостя
    [ObservableProperty]
    private string? _invitationStatus;

    [ObservableProperty]
    private string? _dietaryRestrictions;

    [ObservableProperty]
    private bool _transferNeeded;

    [ObservableProperty]
    private bool _accommodationNeeded;

    [ObservableProperty]
    private int? _tableNumber;

    // Поля для подрядчика
    [ObservableProperty]
    private string? _contractorService;

    [ObservableProperty]
    private decimal? _contractorCost;

    public event Action<PersonSearchResult>? PersonSelected;

    public override string Title => "Выберите человека";

    public SelectPersonViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            SearchResults.Clear();
            return;
        }

        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();

        var search = SearchText.ToLower().Trim();
        var results = await context.People
            .Where(p => !p.IsDeleted &&
                (p.FullName.ToLower().Contains(search) || (p.PhonePrimary ?? "").Contains(search)))
            .Take(15)
            .Select(p => new PersonSearchResult { Id = p.Id, FullName = p.FullName, Phone = p.PhonePrimary })
            .ToListAsync();

        SearchResults = new ObservableCollection<PersonSearchResult>(results);
    }

    [RelayCommand]
    private void Select(PersonSearchResult? person)
    {
        if (person != null)
        {
            PersonSelected?.Invoke(person);
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        PersonSelected?.Invoke(null);
    }

    public void FillForGuest(string? invitationStatus, string? dietary, bool transfer, bool accommodation, int? table)
    {
        InvitationStatus = invitationStatus;
        DietaryRestrictions = dietary;
        TransferNeeded = transfer;
        AccommodationNeeded = accommodation;
        TableNumber = table;
    }

    public void FillForContractor(string? service, decimal? cost)
    {
        ContractorService = service;
        ContractorCost = cost;
    }
}