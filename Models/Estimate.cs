using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class Estimate
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int VersionNumber { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public decimal? TotalPlanned { get; set; }

    public decimal? TotalActual { get; set; }

    public virtual ICollection<ContractsClient> ContractsClients { get; set; } = new List<ContractsClient>();

    public virtual ICollection<EstimateItem> EstimateItems { get; set; } = new List<EstimateItem>();

    public virtual Project Project { get; set; } = null!;
}
