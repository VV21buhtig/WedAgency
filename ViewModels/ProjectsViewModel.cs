using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class ProjectsViewModel : BaseViewModel
{
    private readonly IProjectService _projectService;
    private readonly INavigationService _navigation;

    [ObservableProperty]
    private ObservableCollection<ProjectListItem> _projects = new();

    [ObservableProperty]
    private ProjectListItem? _selectedProject;

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private bool _canCloseProject;

    public override string Title => "Проекты";

    public ProjectsViewModel(IProjectService projectService, INavigationService navigation)
    {
        _projectService = projectService;
        _navigation = navigation;
    }

    public async Task InitializeAsync() => await LoadProjects();

    [RelayCommand]
    private async Task LoadProjects()
    {
        IsBusy = true;
        try
        {
            var list = await _projectService.GetAllProjectsAsync();

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                var search = SearchText.ToLower();
                list = list.Where(p =>
                    p.ProjectNumber.ToLower().Contains(search) ||
                    (p.LocationCity?.ToLower().Contains(search) ?? false))
                    .ToList();
            }

            var items = new List<ProjectListItem>();
            foreach (var p in list)
            {
                var clientNames = await _projectService.GetClientNamesAsync(p.Id);
                items.Add(new ProjectListItem
                {
                    Id = p.Id,
                    ProjectNumber = p.ProjectNumber,
                    WeddingDate = p.WeddingDate,
                    LocationCity = p.LocationCity,
                    BudgetTotal = p.BudgetTotal,
                    GuestCountMin = p.GuestCountMin,
                    Status = p.Status ?? "",
                    ManagerName = p.ResponsibleManager?.FullName,
                    ClientsDisplay = clientNames
                });
            }

            Projects = new ObservableCollection<ProjectListItem>(items);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task AddProject()
    {
        await _projectService.CreateProjectAsync(
            "PRJ-" + DateTime.Now.ToString("yyyyMMdd-HHmm"),
            DateOnly.FromDateTime(DateTime.Now.AddMonths(3)),
            50,
            500000m,
            "Москва",
            null);
        await LoadProjects();
    }

    [RelayCommand]
    private async Task CloseProject()
    {
        if (SelectedProject == null) return;
        await _projectService.DeactivateProjectAsync(SelectedProject.Id);
        await LoadProjects();
    }

    [RelayCommand]
    private void OpenProject()
    {
        if (SelectedProject == null) return;
        _navigation.NavigateTo<ProjectDetailsViewModel>(SelectedProject.Id);
    }

    partial void OnSearchTextChanged(string value) => LoadProjectsCommand.Execute(null);

    partial void OnSelectedProjectChanged(ProjectListItem? value)
    {
        CanCloseProject = value != null && value.Status != "Закрыт";
    }
}