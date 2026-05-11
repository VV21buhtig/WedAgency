using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class VenueProposal
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int VenueId { get; set; }

    public decimal? ProposedCost { get; set; }

    public decimal? DepositAmount { get; set; }

    public string? Status { get; set; }

    public DateOnly? BookingDate { get; set; }

    public DateOnly? FinalPaymentDate { get; set; }

    public string? ContractFilePath { get; set; }

    public bool? IsMainVenue { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual VenuesCatalog Venue { get; set; } = null!;
}
