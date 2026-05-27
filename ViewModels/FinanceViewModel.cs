using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.ViewModels;

public partial class FinanceViewModel : BaseViewModel
{
    private readonly IFinanceOverviewService _financeService;

    [ObservableProperty]
    private FinanceSummaryModel? _summary;

    [ObservableProperty]
    private ObservableCollection<FinanceTransactionModel> _transactions = new();

    public override string Title => "Финансы";

    public FinanceViewModel(IFinanceOverviewService financeService)
    {
        _financeService = financeService;
    }

    public async Task InitializeAsync() => await LoadFinance();

    [RelayCommand]
    private async Task LoadFinance()
    {
        IsBusy = true;
        try
        {
            Summary = await _financeService.GetOverallSummaryAsync();
            var transactions = await _financeService.GetAllTransactionsAsync();
            Transactions = new ObservableCollection<FinanceTransactionModel>(transactions);
        }
        finally { IsBusy = false; }
    }
}