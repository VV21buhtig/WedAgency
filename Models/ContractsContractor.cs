using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ContractsContractor
{
    public int Id { get; set; }

    public string ContractNumber { get; set; } = null!;

    public int ProjectId { get; set; }

    public int? ContractorPersonId { get; set; }

    public string? ServiceDescription { get; set; }

    public decimal? ServiceCost { get; set; }

    public string? PaymentTerms { get; set; }

    public DateOnly? SignedDate { get; set; }

    public string? FilePathSigned { get; set; }

    public string? Status { get; set; }

    public virtual ProjectPerson? ContractorPerson { get; set; }

    public virtual Project Project { get; set; } = null!;
}
