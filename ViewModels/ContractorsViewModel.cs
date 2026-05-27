using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.ViewModels;

public partial class ContractorsViewModel : BaseViewModel
{
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private ObservableCollection<ContractorListItem> _contractors = new();

    [ObservableProperty]
    private ContractorListItem? _selectedContractor;

    [ObservableProperty]
    private string _searchText = string.Empty;

    public override string Title => "Подрядчики";

    public ContractorsViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task InitializeAsync() => await LoadContractors();

    [RelayCommand]
    private async Task LoadContractors()
    {
        IsBusy = true;
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();

            var query = context.ProjectPeople
                .Where(pp => pp.Role == ProjectRoles.Contractor)
                .Include(pp => pp.Person)
                .Include(pp => pp.ProjectContractor)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                var search = SearchText.ToLower();
                query = query.Where(pp =>
                    pp.Person.FullName.ToLower().Contains(search) ||
                    (pp.ProjectContractor != null && pp.ProjectContractor.EstimateItem.ItemName.ToLower().Contains(search)));
            }

            var list = await query.Select(pp => new ContractorListItem
            {
                PersonId = pp.PersonId,
                FullName = pp.Person.FullName,
                Service = pp.ProjectContractor != null ? pp.ProjectContractor.EstimateItem.ItemName : null,
                Cost = pp.ProjectContractor != null ? pp.ProjectContractor.ServiceCost : null
            }).ToListAsync();

            Contractors = new ObservableCollection<ContractorListItem>(list);
        }
        finally { IsBusy = false; }
    }

    partial void OnSearchTextChanged(string value) => LoadContractorsCommand.Execute(null);
}