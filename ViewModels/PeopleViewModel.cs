using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeddingAgency.Models;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class PeopleViewModel : BaseViewModel
{
    private readonly IPeopleService _peopleService;

    [ObservableProperty]
    private ObservableCollection<Person> _people = new();

    [ObservableProperty]
    private Person? _selectedPerson;

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private string _roleFilter = "Все";

    [ObservableProperty]
    private ObservableCollection<string> _selectedRoles = new();
    // Поля для добавления
    [ObservableProperty]
    private string _newPersonName = string.Empty;

    [ObservableProperty]
    private string _newPersonPhone = string.Empty;

    [ObservableProperty]
    private string _newPersonEmail = string.Empty;

    [RelayCommand]
    private async Task AddPersonAsync()
    {
        if (string.IsNullOrWhiteSpace(NewPersonName)) return;

        await _peopleService.CreatePersonAsync(NewPersonName.Trim(), NewPersonPhone.Trim(), NewPersonEmail.Trim());
        NewPersonName = string.Empty;
        NewPersonPhone = string.Empty;
        NewPersonEmail = string.Empty;
        await LoadPeople();
    }

    public string RolesDisplay =>
        SelectedRoles.Any()
            ? string.Join(", ", SelectedRoles)
            : "Нет ролей";

    public override string Title => "Люди";

    public PeopleViewModel(IPeopleService peopleService)
    {
        _peopleService = peopleService;
    }

    public async Task InitializeAsync() => await LoadPeople();

    [RelayCommand]
    private async Task LoadPeople()
    {
        IsBusy = true;
        try
        {
            var list = await _peopleService.GetFilteredAsync(SearchText, RoleFilter);
            People = new ObservableCollection<Person>(list);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task ArchivePerson()
    {
        if (SelectedPerson == null) return;
        await _peopleService.DeactivatePersonAsync(SelectedPerson.Id);
        await LoadPeople();
    }

    partial void OnSearchTextChanged(string value) => LoadPeopleCommand.Execute(null);
    partial void OnRoleFilterChanged(string value) => LoadPeopleCommand.Execute(null);

    partial void OnSelectedPersonChanged(Person? value)
    {
        if (value != null)
            _ = LoadRolesSafeAsync(value.Id);
        else
            SelectedRoles.Clear();
    }

    private async Task LoadRolesSafeAsync(int personId)
    {
        try
        {
            var roles = await _peopleService.GetRolesAsync(personId);
            SelectedRoles = new ObservableCollection<string>(roles);
            OnPropertyChanged(nameof(RolesDisplay));
        }
        catch
        {
            SelectedRoles.Clear();
            OnPropertyChanged(nameof(RolesDisplay));
        }
    }
}