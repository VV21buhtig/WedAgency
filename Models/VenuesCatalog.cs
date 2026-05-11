using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class VenuesCatalog
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Coordinates { get; set; }

    public int? CapacityMin { get; set; }

    public int? CapacityMax { get; set; }

    public decimal? RentalCost { get; set; }

    public decimal? FoodDeposit { get; set; }

    public decimal? CorkageFee { get; set; }

    public bool? OwnAlcoholAllowed { get; set; }

    public string? Restrictions { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactPhone { get; set; }

    public string? Photos { get; set; }

    public string? WebsiteUrl { get; set; }

    public virtual ICollection<VenueBooking> VenueBookings { get; set; } = new List<VenueBooking>();

    public virtual ICollection<VenueProposal> VenueProposals { get; set; } = new List<VenueProposal>();
}
