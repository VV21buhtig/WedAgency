using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public int ProjectId { get; set; }

    public int? CounterpartyId { get; set; }

    public int? ContractId { get; set; }

    public decimal Amount { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateTime? IssuedAt { get; set; }

    public string? FilePath { get; set; }

    public string? Status { get; set; }

    public DateTime? PaidAt { get; set; }

    public virtual ContractsClient? Contract { get; set; }

    public virtual Person? Counterparty { get; set; }

    public virtual Project Project { get; set; } = null!;
}
