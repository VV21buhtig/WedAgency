using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class ProjectContractorsService : IProjectContractorsService
{
    private readonly WeddingAgencyContext _context;

    public ProjectContractorsService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<ViewModels.ProjectDetails.ContractorListItem>> GetContractorsAsync(int projectId)
    {
        return await _context.ProjectPeople
            .Where(pp => pp.ProjectId == projectId && pp.Role == ProjectRoles.Contractor)
            .Select(pp => new ViewModels.ProjectDetails.ContractorListItem
            {
                PersonId = pp.PersonId,
                FullName = pp.Person.FullName,
                Service = pp.ProjectContractor != null ? pp.ProjectContractor.EstimateItem.ItemName : null,
                Cost = pp.ProjectContractor != null ? pp.ProjectContractor.ServiceCost : null
            })
            .ToListAsync();
    }
}