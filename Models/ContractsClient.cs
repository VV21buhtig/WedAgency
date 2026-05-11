using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ContractsClient
{
    public int Id { get; set; }

    public string ContractNumber { get; set; } = null!;

    public int ProjectId { get; set; }

    public int? EstimateId { get; set; }

    public string? PaymentSchedule { get; set; }

    public DateOnly? SignedDate { get; set; }

    public string? FilePathSigned { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ActsCompletion> ActsCompletions { get; set; } = new List<ActsCompletion>();

    public virtual Estimate? Estimate { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Project Project { get; set; } = null!;
}
