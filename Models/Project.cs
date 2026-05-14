using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class Project
{
    public int Id { get; set; }

    public string ProjectNumber { get; set; } = null!;

    public DateOnly? WeddingDate { get; set; }

    public int? GuestCountMin { get; set; }

    public int? GuestCountMax { get; set; }

    public decimal? BudgetTotal { get; set; }

    public string? FormatType { get; set; }

    public string? LocationCity { get; set; }

    public string? LocationRegion { get; set; }

    public string? VenueType { get; set; }

    public string? SpecialNotes { get; set; }

    public string? Status { get; set; }

    public int? ResponsibleManagerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<ActsCompletion> ActsCompletions { get; set; } = new List<ActsCompletion>();

    public virtual ICollection<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();

    public virtual ContractsClient? ContractsClient { get; set; }

    public virtual ICollection<ContractsContractor> ContractsContractors { get; set; } = new List<ContractsContractor>();

    public virtual ICollection<Estimate> Estimates { get; set; } = new List<Estimate>();

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<ProjectPerson> ProjectPeople { get; set; } = new List<ProjectPerson>();

    public virtual Person? ResponsibleManager { get; set; }

    public virtual ICollection<SeatingTable> SeatingTables { get; set; } = new List<SeatingTable>();

    public virtual Timeline? Timeline { get; set; }

    public virtual ICollection<VenueBooking> VenueBookings { get; set; } = new List<VenueBooking>();

    public virtual ICollection<VenueProposal> VenueProposals { get; set; } = new List<VenueProposal>();
}
