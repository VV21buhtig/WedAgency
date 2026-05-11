using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ProjectPerson
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int PersonId { get; set; }

    public string? Role { get; set; }

    public string? Status { get; set; }

    public DateTime? AssignedAt { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();

    public virtual ICollection<ContractsContractor> ContractsContractors { get; set; } = new List<ContractsContractor>();

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();

    public virtual Person Person { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual ProjectContractor? ProjectContractor { get; set; }

    public virtual ProjectGuest? ProjectGuest { get; set; }

    public virtual ICollection<TimelineEvent> TimelineEvents { get; set; } = new List<TimelineEvent>();
}
