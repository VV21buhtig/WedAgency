using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class EstimateItem
{
    public int Id { get; set; }

    public int EstimateId { get; set; }

    public string? Category { get; set; }

    public string? ItemName { get; set; }

    public decimal? PlannedCost { get; set; }

    public decimal? ActualCost { get; set; }

    public string? Notes { get; set; }

    public string? FulfillmentStatus { get; set; }

    public virtual Estimate Estimate { get; set; } = null!;

    public virtual ICollection<ProjectContractor> ProjectContractors { get; set; } = new List<ProjectContractor>();
}
