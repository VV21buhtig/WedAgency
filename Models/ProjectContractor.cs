using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ProjectContractor
{
    public int Id { get; set; }

    public int ProjectPersonId { get; set; }

    public int? EstimateItemId { get; set; }

    public decimal? ServiceCost { get; set; }

    public DateTime? WorkStart { get; set; }

    public DateTime? WorkEnd { get; set; }

    public string? RiderNotes { get; set; }

    public string? ContractFilePath { get; set; }

    public string? BookingStatus { get; set; }

    public virtual EstimateItem? EstimateItem { get; set; }

    public virtual ProjectPerson ProjectPerson { get; set; } = null!;
}
