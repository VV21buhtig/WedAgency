using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;
using User = WeddingAgency.Models.User;

namespace WeddingAgency.ViewModels;

public partial class AdminUsersViewModel : BaseViewModel
{
    private readonly IUserManagementService _userService;
    private readonly IAuthService _authService;
    private CancellationTokenSource? _searchCts;

    [ObservableProperty]
    private ObservableCollection<User> _users = new();

    [ObservableProperty]
    private User? _selectedUser;

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private string _filterStatus = "Все";

    [ObservableProperty]
    private string _newLogin = string.Empty;

    [ObservableProperty]
    private string _newFullName = string.Empty;

    [ObservableProperty]
    private bool _newIsAdmin;

    public string ToggleButtonText => SelectedUser?.IsActive == true ? "Заблокировать" : "Разблокировать";

    public override string Title => "Управление пользователями";

    public event EventHandler<string>? InfoMessage;
    public event EventHandler<string>? ErrorMessage;

    public AdminUsersViewModel(IUserManagementService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    public async Task InitializeAsync()
    {
        await LoadUsers();
    }

    [RelayCommand]
    private async Task LoadUsers()
    {
        IsBusy = true;
        try
        {
            var allUsers = await _userService.GetAllUsersAsync();
            var filtered = allUsers.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                var search = SearchText.ToLower();
                filtered = filtered.Where(u =>
                    u.Login.ToLower().Contains(search) ||
                    (u.Person?.FullName?.ToLower().Contains(search) ?? false));
            }

            filtered = FilterStatus switch
            {
                "Активные" => filtered.Where(u => u.IsActive),
                "Заблокированные" => filtered.Where(u => !u.IsActive),
                "Админы" => filtered.Where(u => u.IsAdmin),
                _ => filtered
            };

            Users = new ObservableCollection<User>(filtered);

            // После перезагрузки списка пытаемся сохранить выделение
            if (SelectedUser != null)
            {
                var stillExists = Users.FirstOrDefault(u => u.Id == SelectedUser.Id);
                SelectedUser = stillExists;
            }
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task CreateUser()
    {
        if (string.IsNullOrWhiteSpace(NewLogin) || string.IsNullOrWhiteSpace(NewFullName))
        {
            ErrorMessage?.Invoke(this, "Введите логин и ФИО");
            return;
        }

        try
        {
            await _userService.CreateUserAsync(NewLogin.Trim(), NewFullName.Trim(), NewIsAdmin);
            NewLogin = string.Empty;
            NewFullName = string.Empty;
            NewIsAdmin = false;
            InfoMessage?.Invoke(this, "Пользователь создан");
            await LoadUsers();
        }
        catch (InvalidOperationException ex)
        {
            ErrorMessage?.Invoke(this, ex.Message);
        }
    }

    [RelayCommand]
    private async Task ResetPassword()
    {
        if (SelectedUser is null) return;

        if (SelectedUser.Id == _authService.CurrentUser?.Id)
        {
            ErrorMessage?.Invoke(this, "Нельзя сбросить пароль самому себе");
            return;
        }

        await _userService.ResetPasswordAsync(SelectedUser.Id);
        InfoMessage?.Invoke(this, "Пароль сброшен");
        await LoadUsers();
    }

    [RelayCommand]
    private async Task ToggleActive()
    {
        if (SelectedUser is null) return;

        if (SelectedUser.Id == _authService.CurrentUser?.Id)
        {
            ErrorMessage?.Invoke(this, "Нельзя заблокировать самого себя");
            return;
        }

        var newStatus = !SelectedUser.IsActive;
        await _userService.SetActiveStatusAsync(SelectedUser.Id, newStatus);

        // Обновляем текущий объект вручную
        SelectedUser.IsActive = newStatus;

        // Принудительно уведомляем UI
        OnPropertyChanged(nameof(SelectedUser));
        OnPropertyChanged(nameof(ToggleButtonText));

        InfoMessage?.Invoke(this, newStatus ? "Пользователь разблокирован" : "Пользователь заблокирован");

        // Перезагружаем список для актуальности
        await LoadUsers();
    }

    partial void OnSearchTextChanged(string value)
    {
        _searchCts?.Cancel();
        _searchCts = new CancellationTokenSource();
        var token = _searchCts.Token;

        Task.Delay(300, token).ContinueWith(async t =>
        {
            if (t.IsCanceled) return;
            await Application.Current.Dispatcher.InvokeAsync(() => LoadUsersCommand.Execute(null));
        }, TaskScheduler.Default);
    }

    partial void OnFilterStatusChanged(string value) => LoadUsersCommand.Execute(null);

    partial void OnSelectedUserChanged(User? value)
    {
        OnPropertyChanged(nameof(ToggleButtonText));
    }
}