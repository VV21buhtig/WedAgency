using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ActsCompletion
{
    public int Id { get; set; }

    public string ActNumber { get; set; } = null!;

    public int ProjectId { get; set; }

    public int? ContractId { get; set; }

    public DateOnly? ServicePeriodStart { get; set; }

    public DateOnly? ServicePeriodEnd { get; set; }

    public decimal? TotalAmount { get; set; }

    public bool? SignedByClient { get; set; }

    public bool? SignedByAgency { get; set; }

    public string? FilePath { get; set; }

    public DateOnly? SignedDate { get; set; }

    public virtual ContractsClient? Contract { get; set; }

    public virtual Project Project { get; set; } = null!;
}
