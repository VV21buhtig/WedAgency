using CommunityToolkit.Mvvm.ComponentModel;

namespace WeddingAgency.ViewModels.Base;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    public virtual string Title { get; set; } = string.Empty;
}