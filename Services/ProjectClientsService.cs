using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class ProjectClientsService : IProjectClientsService
{
    private readonly WeddingAgencyContext _context;

    public ProjectClientsService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<ViewModels.ProjectDetails.ClientListItem>> GetClientsAsync(int projectId)
    {
        return await _context.ProjectPeople
            .Where(pp => pp.ProjectId == projectId && pp.Role == ProjectRoles.Client)
            .Select(pp => new ViewModels.ProjectDetails.ClientListItem
            {
                PersonId = pp.PersonId,
                FullName = pp.Person.FullName,
                Phone = pp.Person.PhonePrimary,
                Email = pp.Person.Email
            })
            .ToListAsync();
    }
}