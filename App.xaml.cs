using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Windows;
using WeddingAgency.Models;
using WeddingAgency.Services;
using WeddingAgency.ViewModels;
using WeddingAgency.Views.Windows;

namespace WeddingAgency;

public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        // Корректное завершение приложения
        ShutdownMode = ShutdownMode.OnLastWindowClose;

        _host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // DbContext
                services.AddDbContext<WeddingAgencyContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                // Auth
                services.AddScoped<IAuthService, AuthService>();
                // User management
                services.AddScoped<IUserManagementService, UserManagementService>();

                // Navigation
                services.AddSingleton<INavigationService, NavigationService>();

                // ViewModels
                services.AddScoped<IProjectFinanceService, ProjectFinanceService>();
                services.AddTransient<LoginViewModel>();
                services.AddTransient<ChangePasswordViewModel>();
                services.AddTransient<MainWindowViewModel>();
                services.AddTransient<AdminUsersViewModel>();
                services.AddTransient<DashboardViewModel>();
                services.AddScoped<IPeopleService, PeopleService>();
                services.AddTransient<PeopleViewModel>();
                services.AddScoped<IProjectService, ProjectService>();
                services.AddTransient<ProjectsViewModel>(); 
                services.AddTransient<VenuesViewModel>();
                services.AddTransient<FinanceViewModel>();
                services.AddTransient<ContractorsViewModel>();
                services.AddScoped<IProjectPeopleService, ProjectPeopleService>();
                services.AddScoped<IProjectDetailsService, ProjectDetailsService>();
                services.AddTransient<ProjectDetailsViewModel>();
                services.AddScoped<IProjectOverviewService, ProjectOverviewService>();
                services.AddScoped<IProjectClientsService, ProjectClientsService>();
                services.AddScoped<IProjectContractorsService, ProjectContractorsService>();
                services.AddScoped<IProjectGuestsService, ProjectGuestsService>();
                services.AddScoped<IProjectVenueService, ProjectVenueService>();
                services.AddScoped<IProjectTimelineService, ProjectTimelineService>();
                services.AddScoped<IVenueCatalogService, VenueCatalogService>();
                services.AddScoped<IFinanceOverviewService, FinanceOverviewService>();
                services.AddTransient<FinanceViewModel>();
                services.AddTransient<ContractorsViewModel>();
                services.AddScoped<IDashboardService, DashboardService>();
                // Windows
                services.AddTransient<LoginWindow>();
                services.AddTransient<ChangePasswordWindow>();
                services.AddTransient<MainWindow>();
                services.AddTransient<AdminWindow>();
                services.AddTransient<CreateProjectViewModel>();
                services.AddTransient<CreateProjectWindow>();
                services.AddTransient<SelectPersonViewModel>();
                services.AddTransient<SelectPersonWindow>();
                services.AddTransient<AddGuestWindow>();
                services.AddTransient<AddContractorWindow>();
                services.AddTransient<SelectVenueWindow>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        var loginWindow = _host.Services.GetRequiredService<LoginWindow>();
        loginWindow.Show();

        base.OnStartup(e);
        //MessageBox.Show(BCrypt.Net.BCrypt.HashPassword("1"));
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();

        base.OnExit(e);
    }
}