using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class SeatingTable
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int? TableNumber { get; set; }

    public string? Shape { get; set; }

    public int? Capacity { get; set; }

    public string? LocationNote { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<ProjectGuest> ProjectGuests { get; set; } = new List<ProjectGuest>();
}
