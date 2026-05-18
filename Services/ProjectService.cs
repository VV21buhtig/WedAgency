using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class ProjectService : IProjectService
{
    private readonly WeddingAgencyContext _context;

    public ProjectService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllProjectsAsync()
    {
        return await _context.Projects
            .Include(p => p.ResponsibleManager)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _context.Projects
            .Include(p => p.ResponsibleManager)
            .Include(p => p.ProjectPeople).ThenInclude(pp => pp.Person)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Project> CreateProjectAsync(string projectNumber, DateOnly? weddingDate, int? guestCount, decimal? budget, string? city, int? managerId)
    {
        var project = new Project
        {
            ProjectNumber = projectNumber,
            WeddingDate = weddingDate,
            GuestCountMin = guestCount,
            BudgetTotal = budget,
            LocationCity = city,
            ResponsibleManagerId = managerId,
            Status = "Новый",
            CreatedAt = DateTime.Now
        };
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task UpdateProjectAsync(Project project)
    {
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
    }

    public async Task DeactivateProjectAsync(int projectId)
    {
        var project = await _context.Projects.FindAsync(projectId);
        if (project != null)
        {
            project.Status = "Закрыт";
            project.ClosedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<string> GetClientNamesAsync(int projectId)
    {
        var clients = await _context.ProjectPeople
            .Where(pp => pp.ProjectId == projectId && pp.Role == "Client")
            .Select(pp => pp.Person.FullName)
            .ToListAsync();

        return clients.Any() ? string.Join(", ", clients) : "Нет клиентов";
    }
}