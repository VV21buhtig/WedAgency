using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public class FinanceOverviewService : IFinanceOverviewService
{
    private readonly WeddingAgencyContext _context;

    public FinanceOverviewService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<FinanceSummaryModel> GetOverallSummaryAsync()
    {
        var projects = await _context.Projects.ToListAsync();
        var invoices = await _context.Invoices.ToListAsync();
        var contracts = await _context.ContractsContractors.ToListAsync();
        var estimates = await _context.Estimates.Include(e => e.EstimateItems).ToListAsync();

        return new FinanceSummaryModel
        {
            BudgetTotal = projects.Sum(p => p.BudgetTotal),
            TotalPlanned = estimates.Sum(e => e.TotalPlanned),
            TotalActual = estimates.Sum(e => e.TotalActual),
            PaidByClient = invoices.Where(i => i.Status == "Оплачен").Sum(i => i.Amount),
            PaidToContractors = contracts.Where(c => c.Status == "Оплачен").Sum(c => c.ServiceCost)
        };
    }

    public async Task<List<FinanceTransactionModel>> GetAllTransactionsAsync()
    {
        var transactions = new List<FinanceTransactionModel>();

        var invoices = await _context.Invoices.Include(i => i.Counterparty).ToListAsync();
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

        var acts = await _context.ActsCompletions.ToListAsync();
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