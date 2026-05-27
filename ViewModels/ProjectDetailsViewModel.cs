using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    private readonly IServiceProvider _serviceProvider;

    private int _projectId;
    private bool _isLoading;

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

    // Поиск площадок
    [ObservableProperty]
    private string _venueSearchText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<VenuesCatalog> _venueSearchResults = new();

    [ObservableProperty]
    private decimal? _newVenueRentalCost;

    [ObservableProperty]
    private decimal? _newVenueDeposit;

    [ObservableProperty]
    private DateOnly? _newVenueEventDate;

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

    // Edit mode
    [ObservableProperty]
    private bool _isEditMode;

    [ObservableProperty]
    private string? _editProjectNumber;

    [ObservableProperty]
    private DateOnly? _editWeddingDate;

    [ObservableProperty]
    private string? _editLocationCity;

    [ObservableProperty]
    private decimal? _editBudgetTotal;

    [ObservableProperty]
    private int? _editGuestCount;

    [ObservableProperty]
    private string? _editStatus;

    // Менеджеры для выбора
    [ObservableProperty]
    private ObservableCollection<User> _managers = new();

    [ObservableProperty]
    private User? _selectedManager;

    public override string Title => $"Проект: {Header?.ProjectNumber ?? ""}";

    public ProjectDetailsViewModel(
        IProjectOverviewService overviewService,
        IProjectPeopleService peopleService,
        IProjectFinanceService financeService,
        IProjectGuestsService guestsService,
        IProjectVenueService venueService,
        IProjectTimelineService timelineService,
        INavigationService navigation,
        IServiceProvider serviceProvider)
    {
        _overviewService = overviewService;
        _peopleService = peopleService;
        _financeService = financeService;
        _guestsService = guestsService;
        _venueService = venueService;
        _timelineService = timelineService;
        _navigation = navigation;
        _serviceProvider = serviceProvider;
    }

    public async void OnNavigatedTo(object? parameter)
    {
        if (parameter is int projectId)
        {
            // Если уже загружен этот же проект — ничего не делаем
            if (_projectId == projectId && Header != null)
                return;

            if (_isLoading) return;

            _projectId = projectId;
            _isLoading = true;

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();
                var p = await context.Projects
                    .Include(p => p.ResponsibleManager)
                    .Include(p => p.ProjectPeople)
                    .FirstOrDefaultAsync(p => p.Id == projectId);

                if (p != null)
                {
                    Header = new ProjectHeaderModel
                    {
                        Id = p.Id,
                        ProjectNumber = p.ProjectNumber,
                        WeddingDate = p.WeddingDate,
                        Status = p.Status ?? "",
                        BudgetTotal = p.BudgetTotal,
                        GuestCountMin = p.GuestCountMin,
                        LocationCity = p.LocationCity,
                        ManagerName = p.ResponsibleManager?.FullName ?? "Не назначен",
                        ClientCount = p.ProjectPeople.Count(pp => pp.Role == "Client"),
                        ContractorCount = p.ProjectPeople.Count(pp => pp.Role == "Contractor"),
                        GuestCount = p.ProjectPeople.Count(pp => pp.Role == "Guest")
                    };
                    OnPropertyChanged(nameof(Title));
                }
            }
            finally
            {
                _isLoading = false;
            }
        }
    }
    // ========== EDIT MODE ==========

    [RelayCommand]
    private async Task EnableEditMode()
    {
        if (Header == null) return;

        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();
        var project = await context.Projects.FindAsync(_projectId);

        if (project == null) return;

        EditProjectNumber = project.ProjectNumber;
        EditWeddingDate = project.WeddingDate;
        EditLocationCity = project.LocationCity;
        EditBudgetTotal = project.BudgetTotal;
        EditGuestCount = project.GuestCountMin;
        EditStatus = project.Status;

        var users = await context.Users
            .Include(u => u.Person)
            .Where(u => u.IsActive)
            .ToListAsync();
        Managers = new ObservableCollection<User>(users);
        SelectedManager = users.FirstOrDefault(u => u.Id == project.ResponsibleManagerId);

        IsEditMode = true;
    }

    [RelayCommand]
    private void CancelEdit()
    {
        IsEditMode = false;
    }

    [RelayCommand]
    private async Task SaveEditAsync()
    {
        if (Header == null) return;

        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();

        var project = await context.Projects.FindAsync(_projectId);
        if (project == null) return;

        project.ProjectNumber = EditProjectNumber ?? Header.ProjectNumber;
        project.WeddingDate = EditWeddingDate;
        project.LocationCity = EditLocationCity;
        project.BudgetTotal = EditBudgetTotal;
        project.GuestCountMin = EditGuestCount;
        project.Status = EditStatus ?? Header.Status;
        project.ResponsibleManagerId = SelectedManager?.PersonId;

        await context.SaveChangesAsync();

        Header = new ProjectHeaderModel
        {
            Id = Header.Id,
            ProjectNumber = project.ProjectNumber,
            WeddingDate = project.WeddingDate,
            Status = project.Status ?? "",
            BudgetTotal = project.BudgetTotal,
            GuestCountMin = project.GuestCountMin,
            LocationCity = project.LocationCity,
            ManagerName = SelectedManager?.Person?.FullName ?? "Не назначен",
            ClientCount = Header.ClientCount,
            ContractorCount = Header.ContractorCount,
            GuestCount = Header.GuestCount
        };
        OnPropertyChanged(nameof(Title));

        IsEditMode = false;
    }

    private WeddingAgencyContext GetContext() => _serviceProvider.GetRequiredService<WeddingAgencyContext>();

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
        var context = GetContext();
        var results = await context.People
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
        await RefreshHeaderAsync();
    }

    [RelayCommand]
    private async Task RemoveClientAsync(ClientListItem? client)
    {
        if (client == null) return;
        await _peopleService.RemoveClientAsync(_projectId, client.PersonId);
        await LoadClientsAsync();
        await RefreshHeaderAsync();
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
        var context = GetContext();
        var results = await context.People
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
        await RefreshHeaderAsync();
    }
    [RelayCommand]
    private async Task SaveGuestsAsync()
    {
        foreach (var guest in Guests)
        {
            await _guestsService.UpdateGuestAsync(
                guest.Id,
                guest.InvitationStatus,
                guest.DietaryRestrictions,
                guest.TransferNeeded,
                guest.AccommodationNeeded,
                guest.TableNumber);
        }
    }
    [RelayCommand]
    private async Task RemoveContractorAsync(ContractorListItem? contractor)
    {
        if (contractor == null) return;
        await _peopleService.RemoveContractorAsync(_projectId, contractor.PersonId);
        await LoadContractorsAsync();
        await RefreshHeaderAsync();
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
        var context = GetContext();
        var results = await context.People
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
        await RefreshHeaderAsync();
    }

    [RelayCommand]
    private async Task RemoveGuestAsync(GuestListItem? guest)
    {
        if (guest == null) return;
        await _guestsService.RemoveGuestAsync(_projectId, guest.PersonId);
        await LoadGuestsAsync();
        await RefreshHeaderAsync();
    }

    // ========== ПЛОЩАДКА ==========

    [RelayCommand]
    private async Task LoadVenuesAsync()
    {
        var list = await _venueService.GetVenuesAsync(_projectId);
        Venues = new ObservableCollection<VenueItemModel>(list);
    }

    [RelayCommand]
    private async Task SearchVenuesAsync()
    {
        if (string.IsNullOrWhiteSpace(VenueSearchText))
        {
            VenueSearchResults.Clear();
            return;
        }
        var results = await _venueService.SearchVenuesAsync(VenueSearchText);
        VenueSearchResults = new ObservableCollection<VenuesCatalog>(results);
    }

    [RelayCommand]
    private async Task AddVenueAsync(VenuesCatalog? venue)
    {
        if (venue == null) return;
        await _venueService.AddVenueAsync(_projectId, venue.Id, NewVenueRentalCost, NewVenueDeposit, NewVenueEventDate);
        VenueSearchText = string.Empty;
        NewVenueRentalCost = null;
        NewVenueDeposit = null;
        NewVenueEventDate = null;
        VenueSearchResults.Clear();
        await LoadVenuesAsync();
    }

    [RelayCommand]
    private async Task RemoveVenueAsync(VenueItemModel? venue)
    {
        if (venue == null) return;
        await _venueService.RemoveVenueAsync(venue.BookingId);
        await LoadVenuesAsync();
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

    private async Task RefreshHeaderAsync()
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();
        var p = await context.Projects
            .Include(p => p.ResponsibleManager)
            .Include(p => p.ProjectPeople)
            .FirstOrDefaultAsync(p => p.Id == _projectId);

        if (p != null && Header != null)
        {
            Header = new ProjectHeaderModel
            {
                Id = Header.Id,
                ProjectNumber = p.ProjectNumber,
                WeddingDate = p.WeddingDate,
                Status = p.Status ?? "",
                BudgetTotal = p.BudgetTotal,
                GuestCountMin = p.GuestCountMin,
                LocationCity = p.LocationCity,
                ManagerName = p.ResponsibleManager?.FullName ?? "Не назначен",
                ClientCount = p.ProjectPeople.Count(pp => pp.Role == "Client"),
                ContractorCount = p.ProjectPeople.Count(pp => pp.Role == "Contractor"),
                GuestCount = p.ProjectPeople.Count(pp => pp.Role == "Guest")
            };
            OnPropertyChanged(nameof(Title));
        }
    }
}