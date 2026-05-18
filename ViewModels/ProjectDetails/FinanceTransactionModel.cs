namespace WeddingAgency.ViewModels.ProjectDetails;

public class FinanceTransactionModel
{
    public string Type { get; init; } = string.Empty; // Счёт, Договор, Акт
    public string? Number { get; init; }
    public string? Counterparty { get; init; }
    public decimal? Amount { get; init; }
    public string? Status { get; init; }
    public DateOnly? Date { get; init; }
}