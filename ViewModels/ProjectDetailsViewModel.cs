using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.ViewModels;

public partial class ProjectDetailsViewModel : BaseViewModel, INavigationAware
{
    private readonly IProjectOverviewService _overviewService;
    private readonly IProjectPeopleService _peopleService;
    private readonly IProjectFinanceService _financeService;
    private readonly IProjectGuestsService _guestsService;
    private readonly IProjectVenueService _venueService;
    private readonly IProjectTimelineService _timelineService;
    private readonly INavigationService _navigation;

    private int _projectId;

    [ObservableProperty]
    private ProjectHeaderModel? _header;

    // Клиенты
    [ObservableProperty]
    private ObservableCollection<ClientListItem> _clients = new();

    [ObservableProperty]
    private string _clientSearchText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<PersonSearchResult> _clientSearchResults = new();

    // Подрядчики
    [ObservableProperty]
    private ObservableCollection<ContractorListItem> _contractors = new();

    [ObservableProperty]
    private string _contractorSearchText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<PersonSearchResult> _contractorSearchResults = new();

    [ObservableProperty]
    private string? _contractorService;

    [ObservableProperty]
    private decimal? _contractorCost;

    // Гости
    [ObservableProperty]
    private ObservableCollection<GuestListItem> _guests = new();

    [ObservableProperty]
    private string _guestSearchText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<PersonSearchResult> _guestSearchResults = new();

    // Площадка
    [ObservableProperty]
    private ObservableCollection<VenueItemModel> _venues = new();

    // Таймлайн
    [ObservableProperty]
    private ObservableCollection<TimelineEventItem> _timelineEvents = new();

    // Финансы
    [ObservableProperty]
    private FinanceSummaryModel? _financeSummary;

    [ObservableProperty]
    private ObservableCollection<FinanceTransactionModel> _financeTransactions = new();

    [ObservableProperty]
    private bool _isFinanceLoaded;

    public override string Title => $"Проект: {Header?.ProjectNumber ?? ""}";

    public ProjectDetailsViewModel(
        IProjectOverviewService overviewService,
        IProjectPeopleService peopleService,
        IProjectFinanceService financeService,
        IProjectGuestsService guestsService,
        IProjectVenueService venueService,
        IProjectTimelineService timelineService,
        INavigationService navigation)
    {
        _overviewService = overviewService;
        _peopleService = peopleService;
        _financeService = financeService;
        _guestsService = guestsService;
        _venueService = venueService;
        _timelineService = timelineService;
        _navigation = navigation;
    }

    public void OnNavigatedTo(object? parameter)
    {
        if (parameter is int projectId)
        {
            _projectId = projectId;
            _ = LoadHeaderAsync();
        }
    }

    private async Task LoadHeaderAsync()
    {
        Header = await _overviewService.GetHeaderAsync(_projectId);
        OnPropertyChanged(nameof(Title));
    }

    // ========== КЛИЕНТЫ ==========

    [RelayCommand]
    private async Task LoadClientsAsync()
    {
        var list = await _peopleService.GetClientsAsync(_projectId);
        Clients = new ObservableCollection<ClientListItem>(list);
    }

    [RelayCommand]
    private async Task SearchClientsAsync()
    {
        if (string.IsNullOrWhiteSpace(ClientSearchText))
        {
            ClientSearchResults.Clear();
            return;
        }
        var results = await new WeddingAgencyContext()
            .People
            .Where(p => p.FullName.Contains(ClientSearchText) || p.PhonePrimary.Contains(ClientSearchText))
            .Take(10)
            .Select(p => new PersonSearchResult { Id = p.Id, FullName = p.FullName, Phone = p.PhonePrimary })
            .ToListAsync();

        ClientSearchResults = new ObservableCollection<PersonSearchResult>(results);
    }

    [RelayCommand]
    private async Task AddClientAsync(PersonSearchResult? person)
    {
        if (person == null) return;
        await _peopleService.AddClientAsync(_projectId, person.Id);
        ClientSearchText = string.Empty;
        ClientSearchResults.Clear();
        await LoadClientsAsync();
        await LoadHeaderAsync();
    }

    [RelayCommand]
    private async Task RemoveClientAsync(ClientListItem? client)
    {
        if (client == null) return;
        await _peopleService.RemoveClientAsync(_projectId, client.PersonId);
        await LoadClientsAsync();
        await LoadHeaderAsync();
    }

    // ========== ПОДРЯДЧИКИ ==========

    [RelayCommand]
    private async Task LoadContractorsAsync()
    {
        var list = await _peopleService.GetContractorsAsync(_projectId);
        Contractors = new ObservableCollection<ContractorListItem>(list);
    }

    [RelayCommand]
    private async Task SearchContractorsAsync()
    {
        if (string.IsNullOrWhiteSpace(ContractorSearchText))
        {
            ContractorSearchResults.Clear();
            return;
        }
        var results = await new WeddingAgencyContext()
            .People
            .Where(p => p.FullName.Contains(ContractorSearchText) || p.PhonePrimary.Contains(ContractorSearchText))
            .Take(10)
            .Select(p => new PersonSearchResult { Id = p.Id, FullName = p.FullName, Phone = p.PhonePrimary })
            .ToListAsync();

        ContractorSearchResults = new ObservableCollection<PersonSearchResult>(results);
    }

    [RelayCommand]
    private async Task AddContractorAsync(PersonSearchResult? person)
    {
        if (person == null) return;
        await _peopleService.AddContractorAsync(_projectId, person.Id, ContractorService, ContractorCost, null);
        ContractorSearchText = string.Empty;
        ContractorService = null;
        ContractorCost = null;
        ContractorSearchResults.Clear();
        await LoadContractorsAsync();
        await LoadHeaderAsync();
    }

    [RelayCommand]
    private async Task RemoveContractorAsync(ContractorListItem? contractor)
    {
        if (contractor == null) return;
        await _peopleService.RemoveContractorAsync(_projectId, contractor.PersonId);
        await LoadContractorsAsync();
        await LoadHeaderAsync();
    }

    // ========== ГОСТИ ==========

    [RelayCommand]
    private async Task LoadGuestsAsync()
    {
        var list = await _guestsService.GetGuestsAsync(_projectId);
        Guests = new ObservableCollection<GuestListItem>(list);
    }

    [RelayCommand]
    private async Task SearchGuestsAsync()
    {
        if (string.IsNullOrWhiteSpace(GuestSearchText))
        {
            GuestSearchResults.Clear();
            return;
        }
        var results = await new WeddingAgencyContext()
            .People
            .Where(p => p.FullName.Contains(GuestSearchText) || p.PhonePrimary.Contains(GuestSearchText))
            .Take(10)
            .Select(p => new PersonSearchResult { Id = p.Id, FullName = p.FullName, Phone = p.PhonePrimary })
            .ToListAsync();

        GuestSearchResults = new ObservableCollection<PersonSearchResult>(results);
    }

    [RelayCommand]
    private async Task AddGuestAsync(PersonSearchResult? person)
    {
        if (person == null) return;
        await _guestsService.AddGuestAsync(_projectId, person.Id);
        GuestSearchText = string.Empty;
        GuestSearchResults.Clear();
        await LoadGuestsAsync();
        await LoadHeaderAsync();
    }

    [RelayCommand]
    private async Task RemoveGuestAsync(GuestListItem? guest)
    {
        if (guest == null) return;
        await _guestsService.RemoveGuestAsync(_projectId, guest.PersonId);
        await LoadGuestsAsync();
        await LoadHeaderAsync();
    }

    // ========== ПЛОЩАДКА ==========

    [RelayCommand]
    private async Task LoadVenuesAsync()
    {
        var list = await _venueService.GetVenuesAsync(_projectId);
        Venues = new ObservableCollection<VenueItemModel>(list);
    }

    // ========== ТАЙМЛАЙН ==========

    [RelayCommand]
    private async Task LoadTimelineAsync()
    {
        var list = await _timelineService.GetEventsAsync(_projectId);
        TimelineEvents = new ObservableCollection<TimelineEventItem>(list);
    }

    // ========== ФИНАНСЫ ==========

    [RelayCommand]
    private async Task LoadFinanceAsync()
    {
        if (IsFinanceLoaded) return;
        IsBusy = true;
        try
        {
            FinanceSummary = await _financeService.GetSummaryAsync(_projectId);
            var transactions = await _financeService.GetTransactionsAsync(_projectId);
            FinanceTransactions = new ObservableCollection<FinanceTransactionModel>(transactions);
            IsFinanceLoaded = true;
        }
        finally
        {
            IsBusy = false;
        }
    }

    // ========== НАЗАД ==========

    [RelayCommand]
    private void GoBack()
    {
        _navigation.NavigateTo<ProjectsViewModel>();
    }
}