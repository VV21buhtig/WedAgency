using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class Incident
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public DateTime? OccurredAt { get; set; }

    public string? Description { get; set; }

    public string? PhotoPath { get; set; }

    public int? RelatedPersonId { get; set; }

    public string? Status { get; set; }

    public string? ResolutionComment { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ProjectPerson? RelatedPerson { get; set; }
}
