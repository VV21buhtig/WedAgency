using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class DashboardService : IDashboardService
{
    private readonly WeddingAgencyContext _context;

    public DashboardService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<DashboardData> GetDashboardDataAsync()
    {
        var projects = await _context.Projects
            .Include(p => p.ProjectPeople).ThenInclude(pp => pp.Person)
            .ToListAsync();

        var activeProjects = projects.Where(p => p.Status != "Закрыт").ToList();

        var totalClients = projects
            .SelectMany(p => p.ProjectPeople)
            .Count(pp => pp.Role == ProjectRoles.Client);

        var totalGuests = projects
            .SelectMany(p => p.ProjectPeople)
            .Count(pp => pp.Role == ProjectRoles.Guest);

        var totalContractors = projects
            .SelectMany(p => p.ProjectPeople)
            .Count(pp => pp.Role == ProjectRoles.Contractor);

        var totalBudget = projects.Sum(p => p.BudgetTotal);
        var totalPaid = await _context.Invoices
            .Where(i => i.Status == "Оплачен")
            .SumAsync(i => i.Amount);

        var upcoming = activeProjects
            .Where(p => p.WeddingDate.HasValue && p.WeddingDate.Value >= DateOnly.FromDateTime(DateTime.Today))
            .OrderBy(p => p.WeddingDate)
            .Take(5)
            .Select(p => new UpcomingWedding
            {
                ProjectNumber = p.ProjectNumber,
                WeddingDate = p.WeddingDate,
                City = p.LocationCity,
                GuestCount = p.GuestCountMin,
                ClientNames = string.Join(", ", p.ProjectPeople
                    .Where(pp => pp.Role == ProjectRoles.Client)
                    .Select(pp => pp.Person.FullName))
            })
            .ToList();

        return new DashboardData
        {
            ActiveProjects = activeProjects.Count,
            TotalClients = totalClients,
            TotalGuests = totalGuests,
            TotalContractors = totalContractors,
            TotalBudget = totalBudget,
            TotalPaid = totalPaid,
            UpcomingWeddings = upcoming
        };
    }
}