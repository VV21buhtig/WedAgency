namespace WeddingAgency.ViewModels.ProjectDetails;

public class FinanceSummaryModel
{
    public decimal? BudgetTotal { get; init; }
    public decimal? TotalPlanned { get; init; }
    public decimal? TotalActual { get; init; }
    public decimal? PaidByClient { get; init; }
    public decimal? PaidToContractors { get; init; }
    public decimal? Remainder => (PaidByClient ?? 0) - (TotalActual ?? 0);
    public decimal? Profit => (PaidByClient ?? 0) - (PaidToContractors ?? 0);
}