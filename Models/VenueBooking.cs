using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class VenueBooking
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int VenueId { get; set; }

    public string? BookingNumber { get; set; }

    public DateOnly? EventDate { get; set; }

    public decimal? RentalCost { get; set; }

    public decimal? DepositAmount { get; set; }

    public string? CancellationPolicy { get; set; }

    public string? FilePath { get; set; }

    public string? Status { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual VenuesCatalog Venue { get; set; } = null!;
}
