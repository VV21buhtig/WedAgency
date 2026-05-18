using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public class ProjectPeopleService : IProjectPeopleService
{
    private readonly WeddingAgencyContext _context;

    public ProjectPeopleService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task AddClientAsync(int projectId, int personId)
    {
        var exists = await _context.ProjectPeople
            .AnyAsync(pp => pp.ProjectId == projectId && pp.PersonId == personId && pp.Role == ProjectRoles.Client);

        if (!exists)
        {
            _context.ProjectPeople.Add(new ProjectPerson
            {
                ProjectId = projectId,
                PersonId = personId,
                Role = ProjectRoles.Client,
                AssignedAt = DateTime.Now
            });
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveClientAsync(int projectId, int personId)
    {
        var pp = await _context.ProjectPeople
            .FirstOrDefaultAsync(p => p.ProjectId == projectId && p.PersonId == personId && p.Role == ProjectRoles.Client);

        if (pp != null)
        {
            _context.ProjectPeople.Remove(pp);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<ClientListItem>> GetClientsAsync(int projectId)
    {
        return await _context.ProjectPeople
            .Where(pp => pp.ProjectId == projectId && pp.Role == ProjectRoles.Client)
            .Select(pp => new ClientListItem
            {
                PersonId = pp.PersonId,
                FullName = pp.Person.FullName,
                Phone = pp.Person.PhonePrimary,
                Email = pp.Person.Email
            })
            .ToListAsync();
    }

    public async Task AddContractorAsync(int projectId, int personId, string? service, decimal? cost, string? notes)
    {
        var exists = await _context.ProjectPeople
            .AnyAsync(pp => pp.ProjectId == projectId && pp.PersonId == personId && pp.Role == ProjectRoles.Contractor);

        if (!exists)
        {
            var pp = new ProjectPerson
            {
                ProjectId = projectId,
                PersonId = personId,
                Role = ProjectRoles.Contractor,
                AssignedAt = DateTime.Now
            };
            _context.ProjectPeople.Add(pp);
            await _context.SaveChangesAsync();

            _context.ProjectContractors.Add(new ProjectContractor
            {
                ProjectPersonId = pp.Id,
                ServiceCost = cost,
                RiderNotes = notes
            });
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveContractorAsync(int projectId, int personId)
    {
        var pp = await _context.ProjectPeople
            .Include(p => p.ProjectContractor)
            .FirstOrDefaultAsync(p => p.ProjectId == projectId && p.PersonId == personId && p.Role == ProjectRoles.Contractor);

        if (pp != null)
        {
            if (pp.ProjectContractor != null)
                _context.ProjectContractors.Remove(pp.ProjectContractor);

            _context.ProjectPeople.Remove(pp);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<ContractorListItem>> GetContractorsAsync(int projectId)
    {
        return await _context.ProjectPeople
            .Where(pp => pp.ProjectId == projectId && pp.Role == ProjectRoles.Contractor)
            .Select(pp => new ContractorListItem
            {
                PersonId = pp.PersonId,
                FullName = pp.Person.FullName,
                Service = pp.ProjectContractor != null ? pp.ProjectContractor.EstimateItem.ItemName : null,
                Cost = pp.ProjectContractor != null ? pp.ProjectContractor.ServiceCost : null
            })
            .ToListAsync();
    }
}