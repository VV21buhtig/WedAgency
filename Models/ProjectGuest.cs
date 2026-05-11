using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ProjectGuest
{
    public int Id { get; set; }

    public int ProjectPersonId { get; set; }

    public string? InvitationStatus { get; set; }

    public string? GuestCategory { get; set; }

    public string? DietaryRestrictions { get; set; }

    public bool? TransferNeeded { get; set; }

    public string? TransferAddress { get; set; }

    public bool? AccommodationNeeded { get; set; }

    public int? TableId { get; set; }

    public virtual ProjectPerson ProjectPerson { get; set; } = null!;

    public virtual SeatingTable? Table { get; set; }
}
