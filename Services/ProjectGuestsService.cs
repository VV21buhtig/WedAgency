using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public class ProjectGuestsService : IProjectGuestsService
{
    private readonly WeddingAgencyContext _context;

    public ProjectGuestsService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<GuestListItem>> GetGuestsAsync(int projectId)
    {
        return await _context.ProjectPeople
            .Where(pp => pp.ProjectId == projectId && pp.Role == ProjectRoles.Guest)
            .Select(pp => new GuestListItem
            {
                Id = pp.Id,
                PersonId = pp.PersonId,
                FullName = pp.Person.FullName,
                Phone = pp.Person.PhonePrimary,
                InvitationStatus = pp.ProjectGuest != null ? pp.ProjectGuest.InvitationStatus : null,
                DietaryRestrictions = pp.ProjectGuest != null ? pp.ProjectGuest.DietaryRestrictions : null,
                TransferNeeded = pp.ProjectGuest != null && pp.ProjectGuest.TransferNeeded == true,
                AccommodationNeeded = pp.ProjectGuest != null && pp.ProjectGuest.AccommodationNeeded == true,
                TableNumber = pp.ProjectGuest != null ? pp.ProjectGuest.Table.TableNumber : null
            })
            .ToListAsync();
    }

    public async Task AddGuestAsync(int projectId, int personId)
    {
        var exists = await _context.ProjectPeople
            .AnyAsync(pp => pp.ProjectId == projectId && pp.PersonId == personId && pp.Role == ProjectRoles.Guest);

        if (!exists)
        {
            var pp = new ProjectPerson
            {
                ProjectId = projectId,
                PersonId = personId,
                Role = ProjectRoles.Guest,
                AssignedAt = DateTime.Now
            };
            _context.ProjectPeople.Add(pp);
            await _context.SaveChangesAsync();

            // Создаём запись в project_guests
            _context.ProjectGuests.Add(new ProjectGuest
            {
                ProjectPersonId = pp.Id,
                InvitationStatus = "Не отправлено"
            });
            await _context.SaveChangesAsync();
        }
    }
    public async Task UpdateGuestAsync(int projectPersonId, string? invitationStatus, string? dietary, bool transfer, bool accommodation, int? tableNumber)
    {
        var guest = await _context.ProjectGuests
            .FirstOrDefaultAsync(g => g.ProjectPersonId == projectPersonId);

        if (guest != null)
        {
            guest.InvitationStatus = invitationStatus;
            guest.DietaryRestrictions = dietary;
            guest.TransferNeeded = transfer;
            guest.AccommodationNeeded = accommodation;
            guest.TableId = tableNumber;
            await _context.SaveChangesAsync();
        }
    }
    public async Task RemoveGuestAsync(int projectId, int personId)
    {
        var pp = await _context.ProjectPeople
            .Include(p => p.ProjectGuest)
            .FirstOrDefaultAsync(p => p.ProjectId == projectId && p.PersonId == personId && p.Role == ProjectRoles.Guest);

        if (pp != null)
        {
            if (pp.ProjectGuest != null)
                _context.ProjectGuests.Remove(pp.ProjectGuest);

            _context.ProjectPeople.Remove(pp);
            await _context.SaveChangesAsync();
        }
    }
}