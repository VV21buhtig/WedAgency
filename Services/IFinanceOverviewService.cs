using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IFinanceOverviewService
{
    Task<FinanceSummaryModel> GetOverallSummaryAsync();
    Task<List<FinanceTransactionModel>> GetAllTransactionsAsync();
}