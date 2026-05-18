using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public class ProjectOverviewService : IProjectOverviewService
{
    private readonly WeddingAgencyContext _context;

    public ProjectOverviewService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<ProjectHeaderModel?> GetHeaderAsync(int projectId)
    {
        var p = await _context.Projects
            .Include(p => p.ResponsibleManager)
            .Include(p => p.ProjectPeople)
            .FirstOrDefaultAsync(p => p.Id == projectId);

        if (p == null) return null;

        return new ProjectHeaderModel
        {
            Id = p.Id,
            ProjectNumber = p.ProjectNumber,
            WeddingDate = p.WeddingDate,
            Status = p.Status ?? "",
            BudgetTotal = p.BudgetTotal,
            GuestCountMin = p.GuestCountMin,
            LocationCity = p.LocationCity,
            ManagerName = p.ResponsibleManager?.FullName ?? "Не назначен",
            ClientCount = p.ProjectPeople.Count(pp => pp.Role == ProjectRoles.Client),
            ContractorCount = p.ProjectPeople.Count(pp => pp.Role == ProjectRoles.Contractor)
        };
    }
}