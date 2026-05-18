using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectFinanceService
{
    Task<FinanceSummaryModel?> GetSummaryAsync(int projectId);
    Task<List<FinanceTransactionModel>> GetTransactionsAsync(int projectId);
}