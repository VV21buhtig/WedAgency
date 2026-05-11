using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class TimelineEvent
{
    public int Id { get; set; }

    public int TimelineId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Location { get; set; }

    public string? EventDescription { get; set; }

    public int? ResponsiblePersonId { get; set; }

    public string? Notes { get; set; }

    public DateTime? ActualStart { get; set; }

    public DateTime? ActualEnd { get; set; }

    public virtual ProjectPerson? ResponsiblePerson { get; set; }

    public virtual Timeline Timeline { get; set; } = null!;
}
