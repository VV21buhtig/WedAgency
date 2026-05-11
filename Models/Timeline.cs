using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class Timeline
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public string? Status { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<TimelineEvent> TimelineEvents { get; set; } = new List<TimelineEvent>();
}
