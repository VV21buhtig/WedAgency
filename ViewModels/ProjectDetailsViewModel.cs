using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeddingAgency.Models;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;
using WeddingAgency.ViewModels.ProjectDetails;
using WeddingAgency.Views.Windows;

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
    private ClientListItem? _selectedClient;

    // Подрядчики
    [ObservableProperty]
    private ObservableCollection<ContractorListItem> _contractors = new();

    [ObservableProperty]
    private ContractorListItem? _selectedContractor;

    // Гости
    [ObservableProperty]
    private ObservableCollection<GuestListItem> _guests = new();

    [ObservableProperty]
    private GuestListItem? _selectedGuest;

    // Площадка
    [ObservableProperty]
    private ObservableCollection<VenueItemModel> _venues = new();

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

    [ObservableProperty]
    private DateTime? _newEventStartTime;

    [ObservableProperty]
    private DateTime? _newEventEndTime;

    [ObservableProperty]
    private string? _newEventDescription;

    [ObservableProperty]
    private string? _newEventLocation;

    [ObservableProperty]
    private string? _newEventNotes;

    [ObservableProperty]
    private User? _newEventResponsible;

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

    // Менеджеры
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
            if (_projectId == projectId && Header != null) return;
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
            finally { _isLoading = false; }
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

        var users = await context.Users.Include(u => u.Person).Where(u => u.IsActive).ToListAsync();
        Managers = new ObservableCollection<User>(users);
        SelectedManager = users.FirstOrDefault(u => u.Id == project.ResponsibleManagerId);
        IsEditMode = true;
    }

    [RelayCommand]
    private void CancelEdit() => IsEditMode = false;

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
    private async Task AddClientAsync()
    {
        var vm = _serviceProvider.GetRequiredService<SelectPersonViewModel>();
        var window = new SelectPersonWindow(vm);
        window.ShowDialog();
        if (window.Tag is PersonSearchResult person)
        {
            await _peopleService.AddClientAsync(_projectId, person.Id);
            await LoadClientsAsync();
            await RefreshHeaderAsync();
        }
    }

    [RelayCommand]
    private async Task EditClientAsync()
    {
        if (SelectedClient == null) return;
        var vm = _serviceProvider.GetRequiredService<SelectPersonViewModel>();
        vm.SearchText = SelectedClient.FullName;
        vm.SearchCommand.Execute(null);
        var window = new SelectPersonWindow(vm);
        window.ShowDialog();
        if (window.Tag is PersonSearchResult person)
        {
            await _peopleService.RemoveClientAsync(_projectId, SelectedClient.PersonId);
            await _peopleService.AddClientAsync(_projectId, person.Id);
            await LoadClientsAsync();
            await RefreshHeaderAsync();
        }
    }

    [RelayCommand]
    private async Task RemoveClientAsync()
    {
        if (SelectedClient == null) return;
        await _peopleService.RemoveClientAsync(_projectId, SelectedClient.PersonId);
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
    private async Task AddContractorAsync()
    {
        var vm = _serviceProvider.GetRequiredService<SelectPersonViewModel>();
        var window = new AddContractorWindow(vm);
        if (window.ShowDialog() == true && window.SelectedPerson != null)
        {
            await _peopleService.AddContractorAsync(_projectId, window.SelectedPerson.Id, window.ContractorService, window.ContractorCost, null);
            await LoadContractorsAsync();
            await RefreshHeaderAsync();
        }
    }

    [RelayCommand]
    private async Task EditContractorAsync()
    {
        if (SelectedContractor == null) return;
        var vm = _serviceProvider.GetRequiredService<SelectPersonViewModel>();
        vm.FillForContractor(SelectedContractor.Service, SelectedContractor.Cost);
        vm.SearchText = SelectedContractor.FullName;
        vm.SearchCommand.Execute(null);
        var window = new AddContractorWindow(vm);
        if (window.ShowDialog() == true && window.SelectedPerson != null)
        {
            await _peopleService.RemoveContractorAsync(_projectId, SelectedContractor.PersonId);
            await _peopleService.AddContractorAsync(_projectId, window.SelectedPerson.Id, window.ContractorService, window.ContractorCost, null);
            await LoadContractorsAsync();
            await RefreshHeaderAsync();
        }
    }

    [RelayCommand]
    private async Task RemoveContractorAsync()
    {
        if (SelectedContractor == null) return;
        await _peopleService.RemoveContractorAsync(_projectId, SelectedContractor.PersonId);
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
    private async Task AddGuestAsync()
    {
        var vm = _serviceProvider.GetRequiredService<SelectPersonViewModel>();
        var window = new AddGuestWindow(vm);
        if (window.ShowDialog() == true && window.SelectedPerson != null)
        {
            await _guestsService.AddGuestAsync(_projectId, window.SelectedPerson.Id);
            var guests = await _guestsService.GetGuestsAsync(_projectId);
            var lastGuest = guests.LastOrDefault();
            if (lastGuest != null)
            {
                await _guestsService.UpdateGuestAsync(lastGuest.Id, window.InvitationStatus, window.DietaryRestrictions, window.TransferNeeded, window.AccommodationNeeded, window.TableNumber);
            }
            await LoadGuestsAsync();
            await RefreshHeaderAsync();
        }
    }

    [RelayCommand]
    private async Task EditGuestAsync()
    {
        if (SelectedGuest == null) return;
        var vm = _serviceProvider.GetRequiredService<SelectPersonViewModel>();
        vm.FillForGuest(SelectedGuest.InvitationStatus, SelectedGuest.DietaryRestrictions, SelectedGuest.TransferNeeded, SelectedGuest.AccommodationNeeded, SelectedGuest.TableNumber);
        vm.SearchText = SelectedGuest.FullName;
        vm.SearchCommand.Execute(null);
        var window = new AddGuestWindow(vm);
        if (window.ShowDialog() == true && window.SelectedPerson != null)
        {
            await _guestsService.RemoveGuestAsync(_projectId, SelectedGuest.PersonId);
            await _guestsService.AddGuestAsync(_projectId, window.SelectedPerson.Id);
            var guests = await _guestsService.GetGuestsAsync(_projectId);
            var lastGuest = guests.LastOrDefault();
            if (lastGuest != null)
                await _guestsService.UpdateGuestAsync(lastGuest.Id, window.InvitationStatus, window.DietaryRestrictions, window.TransferNeeded, window.AccommodationNeeded, window.TableNumber);
            await LoadGuestsAsync();
            await RefreshHeaderAsync();
        }
    }

    [RelayCommand]
    private async Task RemoveGuestAsync()
    {
        if (SelectedGuest == null) return;
        await _guestsService.RemoveGuestAsync(_projectId, SelectedGuest.PersonId);
        await LoadGuestsAsync();
        await RefreshHeaderAsync();
    }

    // ========== ПЛОЩАДКА ==========

    [RelayCommand]
    private async Task LoadVenuesAsync() { var list = await _venueService.GetVenuesAsync(_projectId); Venues = new ObservableCollection<VenueItemModel>(list); }

    [RelayCommand]
    private async Task SearchVenuesAsync() { if (string.IsNullOrWhiteSpace(VenueSearchText)) { VenueSearchResults.Clear(); return; } var results = await _venueService.SearchVenuesAsync(VenueSearchText); VenueSearchResults = new ObservableCollection<VenuesCatalog>(results); }

    [RelayCommand]
    private async Task AddVenueAsync(VenuesCatalog? venue) { if (venue == null) return; await _venueService.AddVenueAsync(_projectId, venue.Id, NewVenueRentalCost, NewVenueDeposit, NewVenueEventDate); VenueSearchText = string.Empty; NewVenueRentalCost = null; NewVenueDeposit = null; NewVenueEventDate = null; VenueSearchResults.Clear(); await LoadVenuesAsync(); }

    [RelayCommand]
    private async Task RemoveVenueAsync(object? parameter) { if (parameter is VenueItemModel venue) { await _venueService.RemoveVenueAsync(venue.BookingId); await LoadVenuesAsync(); } }

    // ========== ТАЙМЛАЙН ==========

    [RelayCommand]
    private async Task LoadTimelineAsync() { var list = await _timelineService.GetEventsAsync(_projectId); TimelineEvents = new ObservableCollection<TimelineEventItem>(list); if (Managers.Count == 0) { var context = GetContext(); var users = await context.Users.Include(u => u.Person).Where(u => u.IsActive).ToListAsync(); Managers = new ObservableCollection<User>(users); } }

    [RelayCommand]
    private async Task AddTimelineEventAsync() { if (string.IsNullOrWhiteSpace(NewEventDescription)) return; await _timelineService.AddEventAsync(_projectId, NewEventStartTime, NewEventEndTime, NewEventDescription, NewEventLocation, NewEventResponsible?.PersonId, NewEventNotes); NewEventStartTime = null; NewEventEndTime = null; NewEventDescription = null; NewEventLocation = null; NewEventNotes = null; NewEventResponsible = null; await LoadTimelineAsync(); }

    [RelayCommand]
    private async Task DeleteTimelineEventAsync(object? parameter) { if (parameter is TimelineEventItem eventItem) { await _timelineService.DeleteEventAsync(eventItem.Id); await LoadTimelineAsync(); } }

    // ========== ФИНАНСЫ ==========

    [RelayCommand]
    private async Task LoadFinanceAsync() { if (IsFinanceLoaded) return; IsBusy = true; try { FinanceSummary = await _financeService.GetSummaryAsync(_projectId); var transactions = await _financeService.GetTransactionsAsync(_projectId); FinanceTransactions = new ObservableCollection<FinanceTransactionModel>(transactions); IsFinanceLoaded = true; } finally { IsBusy = false; } }

    // ========== НАЗАД ==========

    [RelayCommand]
    private void GoBack() => _navigation.NavigateTo<ProjectsViewModel>();

    private async Task RefreshHeaderAsync()
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();
        var p = await context.Projects.Include(p => p.ResponsibleManager).Include(p => p.ProjectPeople).FirstOrDefaultAsync(p => p.Id == _projectId);
        if (p != null && Header != null)
        {
            Header = new ProjectHeaderModel { Id = Header.Id, ProjectNumber = p.ProjectNumber, WeddingDate = p.WeddingDate, Status = p.Status ?? "", BudgetTotal = p.BudgetTotal, GuestCountMin = p.GuestCountMin, LocationCity = p.LocationCity, ManagerName = p.ResponsibleManager?.FullName ?? "Не назначен", ClientCount = p.ProjectPeople.Count(pp => pp.Role == "Client"), ContractorCount = p.ProjectPeople.Count(pp => pp.Role == "Contractor"), GuestCount = p.ProjectPeople.Count(pp => pp.Role == "Guest") };
            OnPropertyChanged(nameof(Title));
        }
    }
}