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

                // Navigation
                services.AddSingleton<INavigationService, NavigationService>();

                // ViewModels
                services.AddTransient<MainWindowViewModel>();
                services.AddTransient<DashboardViewModel>();
                services.AddTransient<PeopleViewModel>();
                services.AddTransient<ProjectsViewModel>();
                services.AddTransient<VenuesViewModel>();
                services.AddTransient<FinanceViewModel>();
                services.AddTransient<ContractorsViewModel>();

                // Windows
                services.AddTransient<MainWindow>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();

        base.OnExit(e);
    }
}