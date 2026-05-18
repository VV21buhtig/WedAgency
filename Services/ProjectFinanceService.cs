using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public class ProjectFinanceService : IProjectFinanceService
{
    private readonly WeddingAgencyContext _context;

    public ProjectFinanceService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<FinanceSummaryModel?> GetSummaryAsync(int projectId)
    {
        var project = await _context.Projects
            .Include(p => p.Estimates).ThenInclude(e => e.EstimateItems)
            .Include(p => p.Invoices)
            .Include(p => p.ContractsContractors)
            .FirstOrDefaultAsync(p => p.Id == projectId);

        if (project == null) return null;

        var estimate = project.Estimates.FirstOrDefault();
        var totalPlanned = estimate?.TotalPlanned;
        var totalActual = estimate?.TotalActual;
        var paidByClient = project.Invoices
            .Where(i => i.Status == "Оплачен")
            .Sum(i => i.Amount);
        var paidToContractors = project.ContractsContractors
            .Where(c => c.Status == "Оплачен")
            .Sum(c => c.ServiceCost);

        return new FinanceSummaryModel
        {
            BudgetTotal = project.BudgetTotal,
            TotalPlanned = totalPlanned,
            TotalActual = totalActual,
            PaidByClient = paidByClient,
            PaidToContractors = paidToContractors
        };
    }

    public async Task<List<FinanceTransactionModel>> GetTransactionsAsync(int projectId)
    {
        var transactions = new List<FinanceTransactionModel>();

        var invoices = await _context.Invoices
            .Include(i => i.Counterparty)
            .Where(i => i.ProjectId == projectId)
            .ToListAsync();

        transactions.AddRange(invoices.Select(i => new FinanceTransactionModel
        {
            Type = "Счёт",
            Number = i.InvoiceNumber,
            Counterparty = i.Counterparty?.FullName,
            Amount = i.Amount,
            Status = i.Status,
            Date = i.DueDate
        }));

        var contracts = await _context.ContractsContractors
            .Include(c => c.ContractorPerson).ThenInclude(pp => pp.Person)
            .Where(c => c.ProjectId == projectId)
            .ToListAsync();

        transactions.AddRange(contracts.Select(c => new FinanceTransactionModel
        {
            Type = "Договор с подрядчиком",
            Number = c.ContractNumber,
            Counterparty = c.ContractorPerson?.Person?.FullName,
            Amount = c.ServiceCost,
            Status = c.Status,
            Date = c.SignedDate
        }));

        var acts = await _context.ActsCompletions
            .Where(a => a.ProjectId == projectId)
            .ToListAsync();

        transactions.AddRange(acts.Select(a => new FinanceTransactionModel
        {
            Type = "Акт",
            Number = a.ActNumber,
            Amount = a.TotalAmount,
            Status = a.SignedByClient == true ? "Подписан" : "Не подписан",
            Date = a.SignedDate
        }));

        return transactions.OrderByDescending(t => t.Date).ToList();
    }
}