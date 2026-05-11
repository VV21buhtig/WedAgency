using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ChecklistItem
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string ItemText { get; set; } = null!;

    public bool? IsCompleted { get; set; }

    public DateTime? CompletedAt { get; set; }

    public int? CompletedById { get; set; }

    public string? Comment { get; set; }

    public virtual ProjectPerson? CompletedBy { get; set; }

    public virtual Project Project { get; set; } = null!;
}
