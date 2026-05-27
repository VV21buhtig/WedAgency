# WeddingAgency - Документация по проекту

## Содержание
1. [App.xaml](#appxaml)
2. [App.xaml.cs](#appxamlcs)
3. [AssemblyInfo.cs](#assemblyinfocs)
4. [WeddingAgency.csproj](#weddingagencycsproj)
5. [Core/Helpers](#core-helpers)
   1. [BoolToVisibilityConverter.cs](#booltovisibilityconvertercs)
   2. [InvertBoolConverter.cs](#invertboolconvertercs)
   3. [IsNotNullConverter.cs](#isnotnullconvertercs)
   4. [StatusToColorConverter.cs](#statustocolorconvertercs)
   5. [StringToVisibilityConverter.cs](#stringtovisibilityconvertercs)
6. [Domain/Projects](#domain-projects)
   1. [ProjectRoles.cs](#projectrolescs)
   2. [ProjectStatuses.cs](#projectstatusescs)
7. [Models](#models)
   1. [ActsCompletion.cs](#actscompletioncs)
   2. [ChecklistItem.cs](#checklistitemcs)
   3. [ContractsClient.cs](#contractsclientcs)
   4. [ContractsContractor.cs](#contractscontractorcs)
   5. [Estimate.cs](#estimatecs)
   6. [EstimateItem.cs](#estimateitemcs)
   7. [Incident.cs](#incidentcs)
   8. [Invoice.cs](#invoicecs)
   9. [Person.cs](#personcs)
   10. [Project.cs](#projectcs)
   11. [ProjectContractor.cs](#projectcontractorcs)
   12. [ProjectGuest.cs](#projectguestcs)
   13. [ProjectPerson.cs](#projectpersoncs)
   14. [SeatingTable.cs](#seatingtablecs)
   15. [Timeline.cs](#timelinecs)
   16. [TimelineEvent.cs](#timelineeventcs)
   17. [User.cs](#usercs)
   18. [VenueBooking.cs](#venuebookingcs)
   19. [VenueProposal.cs](#venueproposalcs)
   20. [VenuesCatalog.cs](#venuescatalogcs)
   21. [WeddingAgencyContext.cs](#weddingagencycontextcs)
8. [Services](#services)
   1. [AuthService.cs](#authservicecs)
   2. [IAuthService.cs](#iauthservicecs)
   3. [INavigationAware.cs](#inavigationawarecs)
   4. [INavigationService.cs](#inavigationservicecs)
   5. [IPeopleService.cs](#ipeopleservicecs)
   6. [IProjectClientsService.cs](#iprojectclientsservicecs)
   7. [IProjectContractorsService.cs](#iprojectcontractorsservicecs)
   8. [IProjectDetailsService.cs](#iprojectdetailsservicecs)
   9. [IProjectFinanceService.cs](#iprojectfinanceservicecs)
   10. [IProjectGuestsService.cs](#iprojectguestsservicecs)
   11. [IProjectOverviewService.cs](#iprojectoverviewservicecs)
   12. [IProjectPeopleService.cs](#iprojectpeopleservicecs)
   13. [IProjectService.cs](#iprojectservicecs)
   14. [IProjectTimelineService.cs](#iprojecttimelineservicecs)
   15. [IProjectVenueService.cs](#iprojectvenueservicecs)
   16. [IUserManagementService.cs](#iusermanagementservicecs)
   17. [NavigationService.cs](#navigationservicecs)
   18. [PeopleService.cs](#peopleservicecs)
   19. [ProjectClientsService.cs](#projectclientsservicecs)
   20. [ProjectContractorsService.cs](#projectcontractorsservicecs)
   21. [ProjectDetailsService.cs](#projectdetailsservicecs)
   22. [ProjectFinanceService.cs](#projectfinanceservicecs)
   23. [ProjectGuestsService.cs](#projectguestsservicecs)
   24. [ProjectOverviewService.cs](#projectoverviewservicecs)
   25. [ProjectPeopleService.cs](#projectpeopleservicecs)
   26. [ProjectService.cs](#projectservicecs)
   27. [ProjectTimelineService.cs](#projecttimelineservicecs)
   28. [ProjectVenueService.cs](#projectvenueservicecs)
   29. [UserManagementService.cs](#usermanagementservicecs)
9. [Themes](#themes)
   1. [MaterialTheme.xaml](#materialthemexaml)
10. [Viewmodels](#viewmodels)
   1. [AdminUsersViewModel.cs](#adminusersviewmodelcs)
   2. [ChangePasswordViewModel.cs](#changepasswordviewmodelcs)
   3. [ContractorsViewModel.cs](#contractorsviewmodelcs)
   4. [CreateProjectViewModel.cs](#createprojectviewmodelcs)
   5. [DashboardViewModel.cs](#dashboardviewmodelcs)
   6. [FinanceViewModel.cs](#financeviewmodelcs)
   7. [GlobalUsings.cs](#globalusingscs)
   8. [LoginViewModel.cs](#loginviewmodelcs)
   9. [MainWindowViewModel.cs](#mainwindowviewmodelcs)
   10. [PeopleViewModel.cs](#peopleviewmodelcs)
   11. [ProjectDetailsViewModel.cs](#projectdetailsviewmodelcs)
   12. [ProjectListItem.cs](#projectlistitemcs)
   13. [ProjectsViewModel.cs](#projectsviewmodelcs)
   14. [VenuesViewModel.cs](#venuesviewmodelcs)
11. [Viewmodels/Base](#viewmodels-base)
   1. [BaseViewModel.cs](#baseviewmodelcs)
12. [Viewmodels/Projectdetails](#viewmodels-projectdetails)
   1. [ClientListItem.cs](#clientlistitemcs)
   2. [ContractorListItem.cs](#contractorlistitemcs)
   3. [FinanceSummaryModel.cs](#financesummarymodelcs)
   4. [FinanceTransactionModel.cs](#financetransactionmodelcs)
   5. [GuestListItem.cs](#guestlistitemcs)
   6. [PersonSearchResult.cs](#personsearchresultcs)
   7. [ProjectDetailsModel.cs](#projectdetailsmodelcs)
   8. [ProjectHeaderModel.cs](#projectheadermodelcs)
   9. [TimelineEventItem.cs](#timelineeventitemcs)
   10. [VenueItemModel.cs](#venueitemmodelcs)
13. [Views/Contractors](#views-contractors)
   1. [ContractorsView.xaml](#contractorsviewxaml)
   2. [ContractorsView.xaml.cs](#contractorsviewxamlcs)
14. [Views/Dashboard](#views-dashboard)
   1. [DashboardView.xaml](#dashboardviewxaml)
   2. [DashboardView.xaml.cs](#dashboardviewxamlcs)
15. [Views/Finance](#views-finance)
   1. [FinanceView.xaml](#financeviewxaml)
   2. [FinanceView.xaml.cs](#financeviewxamlcs)
16. [Views/People](#views-people)
   1. [PeopleView.xaml](#peopleviewxaml)
   2. [PeopleView.xaml.cs](#peopleviewxamlcs)
17. [Views/Projects](#views-projects)
   1. [ProjectDetailsView.xaml](#projectdetailsviewxaml)
   2. [ProjectDetailsView.xaml.cs](#projectdetailsviewxamlcs)
   3. [ProjectsView.xaml](#projectsviewxaml)
   4. [ProjectsView.xaml.cs](#projectsviewxamlcs)
18. [Views/Venues](#views-venues)
   1. [VenuesView.xaml](#venuesviewxaml)
   2. [VenuesView.xaml.cs](#venuesviewxamlcs)
19. [Views/Windows](#views-windows)
   1. [AdminWindow.xaml](#adminwindowxaml)
   2. [AdminWindow.xaml.cs](#adminwindowxamlcs)
   3. [ChangePasswordWindow.xaml](#changepasswordwindowxaml)
   4. [ChangePasswordWindow.xaml.cs](#changepasswordwindowxamlcs)
   5. [CreateProjectWindow.xaml](#createprojectwindowxaml)
   6. [CreateProjectWindow.xaml.cs](#createprojectwindowxamlcs)
   7. [LoginWindow.xaml](#loginwindowxaml)
   8. [LoginWindow.xaml.cs](#loginwindowxamlcs)
   9. [MainWindow.xaml](#mainwindowxaml)
   10. [MainWindow.xaml.cs](#mainwindowxamlcs)

## FILE 1: App.xaml

<a id='appxaml'></a>

```xml
﻿<Application x:Class="WeddingAgency.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:vm="clr-namespace:WeddingAgency.ViewModels"
             xmlns:viewsDashboard="clr-namespace:WeddingAgency.Views.Dashboard"
             xmlns:viewsPeople="clr-namespace:WeddingAgency.Views.People"
             xmlns:viewsProjects="clr-namespace:WeddingAgency.Views.Projects"
             xmlns:viewsVenues="clr-namespace:WeddingAgency.Views.Venues"
             xmlns:viewsFinance="clr-namespace:WeddingAgency.Views.Finance"
             xmlns:viewsContractors="clr-namespace:WeddingAgency.Views.Contractors">
    
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Themes/MaterialTheme.xaml" />
            </ResourceDictionary.MergedDictionaries>

            <!-- DataTemplates: ViewModel → View -->
            <DataTemplate DataType="{x:Type vm:DashboardViewModel}">
                <viewsDashboard:DashboardView />
            </DataTemplate>

            <DataTemplate DataType="{x:Type vm:PeopleViewModel}">
                <viewsPeople:PeopleView />
            </DataTemplate>

            <DataTemplate DataType="{x:Type vm:ProjectsViewModel}">
                <viewsProjects:ProjectsView />
            </DataTemplate>

            <DataTemplate DataType="{x:Type vm:VenuesViewModel}">
                <viewsVenues:VenuesView />
            </DataTemplate>

            <DataTemplate DataType="{x:Type vm:FinanceViewModel}">
                <viewsFinance:FinanceView />
            </DataTemplate>

            <DataTemplate DataType="{x:Type vm:ContractorsViewModel}">
                <viewsContractors:ContractorsView />
            </DataTemplate>

            <DataTemplate DataType="{x:Type vm:ProjectDetailsViewModel}">
                <viewsProjects:ProjectDetailsView />
            </DataTemplate>

        </ResourceDictionary>
    </Application.Resources>

</Application>
```

---

## FILE 2: App.xaml.cs

<a id='appxamlcs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
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
                // Windows
                services.AddTransient<LoginWindow>();
                services.AddTransient<ChangePasswordWindow>();
                services.AddTransient<MainWindow>();
                services.AddTransient<AdminWindow>();
                services.AddTransient<CreateProjectViewModel>();
                services.AddTransient<CreateProjectWindow>();
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
```

---

## FILE 3: AssemblyInfo.cs

<a id='assemblyinfocs'></a>

```csharp
using System.Windows;

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None,            //where theme specific resource dictionaries are located
                                                //(used if a resource is not found in the page,
                                                // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly   //where the generic resource dictionary is located
                                                //(used if a resource is not found in the page,
                                                // app, or any theme specific resource dictionaries)
)]
```

---

## FILE 4: BoolToVisibilityConverter.cs

<a id='booltovisibilityconvertercs'></a>

```csharp
﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WeddingAgency.Core.Helpers;

public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is true ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
```

---

## FILE 5: InvertBoolConverter.cs

<a id='invertboolconvertercs'></a>

```csharp
﻿using System.Globalization;
using System.Windows.Data;

namespace WeddingAgency.Core.Helpers;

public class InvertBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool b && !b;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool b && !b;
    }
}
```

---

## FILE 6: IsNotNullConverter.cs

<a id='isnotnullconvertercs'></a>

```csharp
﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace WeddingAgency.Core.Helpers;

public class IsNotNullConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value != null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

---

## FILE 7: StatusToColorConverter.cs

<a id='statustocolorconvertercs'></a>

```csharp
﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WeddingAgency.Core.Helpers;

public class StatusToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value?.ToString() switch
        {
            "Новый" => new SolidColorBrush(Color.FromRgb(33, 150, 243)),
            "В работе" => new SolidColorBrush(Color.FromRgb(255, 152, 0)),
            "Закрыт" => new SolidColorBrush(Color.FromRgb(76, 175, 80)),
            _ => new SolidColorBrush(Color.FromRgb(158, 158, 158))
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
```

---

## FILE 8: StringToVisibilityConverter.cs

<a id='stringtovisibilityconvertercs'></a>

```csharp
﻿using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WeddingAgency.Core.Helpers;

public class StringToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return string.IsNullOrEmpty(value as string) ? Visibility.Collapsed : Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

---

## FILE 9: ProjectRoles.cs

<a id='projectrolescs'></a>

```csharp
﻿namespace WeddingAgency.Domain.Projects;

public static class ProjectRoles
{
    public const string Client = "Client";
    public const string Contractor = "Contractor";
    public const string Guest = "Guest";
    public const string Coordinator = "Coordinator";
}
```

---

## FILE 10: ProjectStatuses.cs

<a id='projectstatusescs'></a>

```csharp
﻿namespace WeddingAgency.Domain.Projects;

public static class ProjectStatuses
{
    public const string New = "Новый";
    public const string Open = "Открыт";
    public const string Closed = "Закрыт";
}
```

---

## FILE 11: ActsCompletion.cs

<a id='actscompletioncs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ActsCompletion
{
    public int Id { get; set; }

    public string ActNumber { get; set; } = null!;

    public int ProjectId { get; set; }

    public int? ContractId { get; set; }

    public DateOnly? ServicePeriodStart { get; set; }

    public DateOnly? ServicePeriodEnd { get; set; }

    public decimal? TotalAmount { get; set; }

    public bool? SignedByClient { get; set; }

    public bool? SignedByAgency { get; set; }

    public string? FilePath { get; set; }

    public DateOnly? SignedDate { get; set; }

    public virtual ContractsClient? Contract { get; set; }

    public virtual Project Project { get; set; } = null!;
}
```

---

## FILE 12: ChecklistItem.cs

<a id='checklistitemcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ChecklistItem
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string ItemText { get; set; } = null!;

    public bool? IsCompleted { get; set; }

    public DateTime? CompletedAt { get; set; }

    public int? CompletedById { get; set; }

    public string? Comment { get; set; }

    public virtual ProjectPerson? CompletedBy { get; set; }

    public virtual Project Project { get; set; } = null!;
}
```

---

## FILE 13: ContractsClient.cs

<a id='contractsclientcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ContractsClient
{
    public int Id { get; set; }

    public string ContractNumber { get; set; } = null!;

    public int ProjectId { get; set; }

    public int? EstimateId { get; set; }

    public string? PaymentSchedule { get; set; }

    public DateOnly? SignedDate { get; set; }

    public string? FilePathSigned { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ActsCompletion> ActsCompletions { get; set; } = new List<ActsCompletion>();

    public virtual Estimate? Estimate { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Project Project { get; set; } = null!;
}
```

---

## FILE 14: ContractsContractor.cs

<a id='contractscontractorcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ContractsContractor
{
    public int Id { get; set; }

    public string ContractNumber { get; set; } = null!;

    public int ProjectId { get; set; }

    public int? ContractorPersonId { get; set; }

    public string? ServiceDescription { get; set; }

    public decimal? ServiceCost { get; set; }

    public string? PaymentTerms { get; set; }

    public DateOnly? SignedDate { get; set; }

    public string? FilePathSigned { get; set; }

    public string? Status { get; set; }

    public virtual ProjectPerson? ContractorPerson { get; set; }

    public virtual Project Project { get; set; } = null!;
}
```

---

## FILE 15: Estimate.cs

<a id='estimatecs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class Estimate
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int VersionNumber { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public decimal? TotalPlanned { get; set; }

    public decimal? TotalActual { get; set; }

    public virtual ICollection<ContractsClient> ContractsClients { get; set; } = new List<ContractsClient>();

    public virtual ICollection<EstimateItem> EstimateItems { get; set; } = new List<EstimateItem>();

    public virtual Project Project { get; set; } = null!;
}
```

---

## FILE 16: EstimateItem.cs

<a id='estimateitemcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class EstimateItem
{
    public int Id { get; set; }

    public int EstimateId { get; set; }

    public string? Category { get; set; }

    public string? ItemName { get; set; }

    public decimal? PlannedCost { get; set; }

    public decimal? ActualCost { get; set; }

    public string? Notes { get; set; }

    public string? FulfillmentStatus { get; set; }

    public virtual Estimate Estimate { get; set; } = null!;

    public virtual ICollection<ProjectContractor> ProjectContractors { get; set; } = new List<ProjectContractor>();
}
```

---

## FILE 17: Incident.cs

<a id='incidentcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class Incident
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public DateTime? OccurredAt { get; set; }

    public string? Description { get; set; }

    public string? PhotoPath { get; set; }

    public int? RelatedPersonId { get; set; }

    public string? Status { get; set; }

    public string? ResolutionComment { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ProjectPerson? RelatedPerson { get; set; }
}
```

---

## FILE 18: Invoice.cs

<a id='invoicecs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public int ProjectId { get; set; }

    public int? CounterpartyId { get; set; }

    public int? ContractId { get; set; }

    public decimal Amount { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateTime? IssuedAt { get; set; }

    public string? FilePath { get; set; }

    public string? Status { get; set; }

    public DateTime? PaidAt { get; set; }

    public virtual ContractsClient? Contract { get; set; }

    public virtual Person? Counterparty { get; set; }

    public virtual Project Project { get; set; } = null!;
}
```

---

## FILE 19: Person.cs

<a id='personcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class Person
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string PhonePrimary { get; set; } = null!;

    public string? PhoneSecondary { get; set; }

    public string? Email { get; set; }

    public string? SocialLinks { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? InternalNotes { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<ProjectPerson> ProjectPeople { get; set; } = new List<ProjectPerson>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual User? User { get; set; }
}
```

---

## FILE 20: Project.cs

<a id='projectcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class Project
{
    public int Id { get; set; }

    public string ProjectNumber { get; set; } = null!;

    public DateOnly? WeddingDate { get; set; }

    public int? GuestCountMin { get; set; }

    public int? GuestCountMax { get; set; }

    public decimal? BudgetTotal { get; set; }

    public string? FormatType { get; set; }

    public string? LocationCity { get; set; }

    public string? LocationRegion { get; set; }

    public string? VenueType { get; set; }

    public string? SpecialNotes { get; set; }

    public string? Status { get; set; }

    public int? ResponsibleManagerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<ActsCompletion> ActsCompletions { get; set; } = new List<ActsCompletion>();

    public virtual ICollection<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();

    public virtual ContractsClient? ContractsClient { get; set; }

    public virtual ICollection<ContractsContractor> ContractsContractors { get; set; } = new List<ContractsContractor>();

    public virtual ICollection<Estimate> Estimates { get; set; } = new List<Estimate>();

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<ProjectPerson> ProjectPeople { get; set; } = new List<ProjectPerson>();

    public virtual Person? ResponsibleManager { get; set; }

    public virtual ICollection<SeatingTable> SeatingTables { get; set; } = new List<SeatingTable>();

    public virtual Timeline? Timeline { get; set; }

    public virtual ICollection<VenueBooking> VenueBookings { get; set; } = new List<VenueBooking>();

    public virtual ICollection<VenueProposal> VenueProposals { get; set; } = new List<VenueProposal>();
}
```

---

## FILE 21: ProjectContractor.cs

<a id='projectcontractorcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ProjectContractor
{
    public int Id { get; set; }

    public int ProjectPersonId { get; set; }

    public int? EstimateItemId { get; set; }

    public decimal? ServiceCost { get; set; }

    public DateTime? WorkStart { get; set; }

    public DateTime? WorkEnd { get; set; }

    public string? RiderNotes { get; set; }

    public string? ContractFilePath { get; set; }

    public string? BookingStatus { get; set; }

    public virtual EstimateItem? EstimateItem { get; set; }

    public virtual ProjectPerson ProjectPerson { get; set; } = null!;
}
```

---

## FILE 22: ProjectGuest.cs

<a id='projectguestcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ProjectGuest
{
    public int Id { get; set; }

    public int ProjectPersonId { get; set; }

    public string? InvitationStatus { get; set; }

    public string? GuestCategory { get; set; }

    public string? DietaryRestrictions { get; set; }

    public bool? TransferNeeded { get; set; }

    public string? TransferAddress { get; set; }

    public bool? AccommodationNeeded { get; set; }

    public int? TableId { get; set; }

    public virtual ProjectPerson ProjectPerson { get; set; } = null!;

    public virtual SeatingTable? Table { get; set; }
}
```

---

## FILE 23: ProjectPerson.cs

<a id='projectpersoncs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class ProjectPerson
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int PersonId { get; set; }

    public string? Role { get; set; }

    public string? Status { get; set; }

    public DateTime? AssignedAt { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();

    public virtual ICollection<ContractsContractor> ContractsContractors { get; set; } = new List<ContractsContractor>();

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();

    public virtual Person Person { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual ProjectContractor? ProjectContractor { get; set; }

    public virtual ProjectGuest? ProjectGuest { get; set; }

    public virtual ICollection<TimelineEvent> TimelineEvents { get; set; } = new List<TimelineEvent>();
}
```

---

## FILE 24: SeatingTable.cs

<a id='seatingtablecs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class SeatingTable
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int? TableNumber { get; set; }

    public string? Shape { get; set; }

    public int? Capacity { get; set; }

    public string? LocationNote { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<ProjectGuest> ProjectGuests { get; set; } = new List<ProjectGuest>();
}
```

---

## FILE 25: Timeline.cs

<a id='timelinecs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class Timeline
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public string? Status { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<TimelineEvent> TimelineEvents { get; set; } = new List<TimelineEvent>();
}
```

---

## FILE 26: TimelineEvent.cs

<a id='timelineeventcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class TimelineEvent
{
    public int Id { get; set; }

    public int TimelineId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Location { get; set; }

    public string? EventDescription { get; set; }

    public int? ResponsiblePersonId { get; set; }

    public string? Notes { get; set; }

    public DateTime? ActualStart { get; set; }

    public DateTime? ActualEnd { get; set; }

    public virtual ProjectPerson? ResponsiblePerson { get; set; }

    public virtual Timeline Timeline { get; set; } = null!;
}
```

---

## FILE 27: User.cs

<a id='usercs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public int? PersonId { get; set; }

    public bool IsAdmin { get; set; }

    public bool MustChangePassword { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Person? Person { get; set; }
}
```

---

## FILE 28: VenueBooking.cs

<a id='venuebookingcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class VenueBooking
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int VenueId { get; set; }

    public string? BookingNumber { get; set; }

    public DateOnly? EventDate { get; set; }

    public decimal? RentalCost { get; set; }

    public decimal? DepositAmount { get; set; }

    public string? CancellationPolicy { get; set; }

    public string? FilePath { get; set; }

    public string? Status { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual VenuesCatalog Venue { get; set; } = null!;
}
```

---

## FILE 29: VenueProposal.cs

<a id='venueproposalcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class VenueProposal
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int VenueId { get; set; }

    public decimal? ProposedCost { get; set; }

    public decimal? DepositAmount { get; set; }

    public string? Status { get; set; }

    public DateOnly? BookingDate { get; set; }

    public DateOnly? FinalPaymentDate { get; set; }

    public string? ContractFilePath { get; set; }

    public bool? IsMainVenue { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual VenuesCatalog Venue { get; set; } = null!;
}
```

---

## FILE 30: VenuesCatalog.cs

<a id='venuescatalogcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;

namespace WeddingAgency.Models;

public partial class VenuesCatalog
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Coordinates { get; set; }

    public int? CapacityMin { get; set; }

    public int? CapacityMax { get; set; }

    public decimal? RentalCost { get; set; }

    public decimal? FoodDeposit { get; set; }

    public decimal? CorkageFee { get; set; }

    public bool? OwnAlcoholAllowed { get; set; }

    public string? Restrictions { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactPhone { get; set; }

    public string? Photos { get; set; }

    public string? WebsiteUrl { get; set; }

    public virtual ICollection<VenueBooking> VenueBookings { get; set; } = new List<VenueBooking>();

    public virtual ICollection<VenueProposal> VenueProposals { get; set; } = new List<VenueProposal>();
}
```

---

## FILE 31: WeddingAgencyContext.cs

<a id='weddingagencycontextcs'></a>

```csharp
﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WeddingAgency.Models;

public partial class WeddingAgencyContext : DbContext
{
    public WeddingAgencyContext()
    {
    }

    public WeddingAgencyContext(DbContextOptions<WeddingAgencyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActsCompletion> ActsCompletions { get; set; }

    public virtual DbSet<ChecklistItem> ChecklistItems { get; set; }

    public virtual DbSet<ContractsClient> ContractsClients { get; set; }

    public virtual DbSet<ContractsContractor> ContractsContractors { get; set; }

    public virtual DbSet<Estimate> Estimates { get; set; }

    public virtual DbSet<EstimateItem> EstimateItems { get; set; }

    public virtual DbSet<Incident> Incidents { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectContractor> ProjectContractors { get; set; }

    public virtual DbSet<ProjectGuest> ProjectGuests { get; set; }

    public virtual DbSet<ProjectPerson> ProjectPeople { get; set; }

    public virtual DbSet<SeatingTable> SeatingTables { get; set; }

    public virtual DbSet<Timeline> Timelines { get; set; }

    public virtual DbSet<TimelineEvent> TimelineEvents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VenueBooking> VenueBookings { get; set; }

    public virtual DbSet<VenueProposal> VenueProposals { get; set; }

    public virtual DbSet<VenuesCatalog> VenuesCatalogs { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-EU7O01O0\\SQLEXPRESS01;Database=WeddingAgency;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActsCompletion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__acts_com__3213E83F988A97D9");

            entity.ToTable("acts_completion");

            entity.HasIndex(e => e.ActNumber, "UQ__acts_com__4F2C0BF9113DED84").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActNumber)
                .HasMaxLength(50)
                .HasColumnName("act_number");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.FilePath)
                .HasMaxLength(500)
                .HasColumnName("file_path");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ServicePeriodEnd).HasColumnName("service_period_end");
            entity.Property(e => e.ServicePeriodStart).HasColumnName("service_period_start");
            entity.Property(e => e.SignedByAgency)
                .HasDefaultValue(false)
                .HasColumnName("signed_by_agency");
            entity.Property(e => e.SignedByClient)
                .HasDefaultValue(false)
                .HasColumnName("signed_by_client");
            entity.Property(e => e.SignedDate).HasColumnName("signed_date");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Contract).WithMany(p => p.ActsCompletions)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_acts_completion_contract");

            entity.HasOne(d => d.Project).WithMany(p => p.ActsCompletions)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_acts_completion_project");
        });

        modelBuilder.Entity<ChecklistItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__checklis__3213E83F714D7EA5");

            entity.ToTable("checklist_items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CompletedAt).HasColumnName("completed_at");
            entity.Property(e => e.CompletedById).HasColumnName("completed_by_id");
            entity.Property(e => e.IsCompleted)
                .HasDefaultValue(false)
                .HasColumnName("is_completed");
            entity.Property(e => e.ItemText)
                .HasMaxLength(500)
                .HasColumnName("item_text");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");

            entity.HasOne(d => d.CompletedBy).WithMany(p => p.ChecklistItems)
                .HasForeignKey(d => d.CompletedById)
                .HasConstraintName("FK_checklist_items_completed_by");

            entity.HasOne(d => d.Project).WithMany(p => p.ChecklistItems)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_checklist_items_project");
        });

        modelBuilder.Entity<ContractsClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contract__3213E83FE0A352E9");

            entity.ToTable("contracts_client");

            entity.HasIndex(e => e.ContractNumber, "UQ__contract__1CA37CCE313206DD").IsUnique();

            entity.HasIndex(e => e.ProjectId, "UQ__contract__BC799E1ED68434DD").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContractNumber)
                .HasMaxLength(50)
                .HasColumnName("contract_number");
            entity.Property(e => e.EstimateId).HasColumnName("estimate_id");
            entity.Property(e => e.FilePathSigned)
                .HasMaxLength(500)
                .HasColumnName("file_path_signed");
            entity.Property(e => e.PaymentSchedule).HasColumnName("payment_schedule");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.SignedDate).HasColumnName("signed_date");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");

            entity.HasOne(d => d.Estimate).WithMany(p => p.ContractsClients)
                .HasForeignKey(d => d.EstimateId)
                .HasConstraintName("FK_contracts_client_estimate");

            entity.HasOne(d => d.Project).WithOne(p => p.ContractsClient)
                .HasForeignKey<ContractsClient>(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_contracts_client_project");
        });

        modelBuilder.Entity<ContractsContractor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contract__3213E83F2FF851D1");

            entity.ToTable("contracts_contractor");

            entity.HasIndex(e => e.ContractNumber, "UQ__contract__1CA37CCEBFAB2C5B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContractNumber)
                .HasMaxLength(50)
                .HasColumnName("contract_number");
            entity.Property(e => e.ContractorPersonId).HasColumnName("contractor_person_id");
            entity.Property(e => e.FilePathSigned)
                .HasMaxLength(500)
                .HasColumnName("file_path_signed");
            entity.Property(e => e.PaymentTerms)
                .HasMaxLength(30)
                .HasColumnName("payment_terms");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ServiceCost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("service_cost");
            entity.Property(e => e.ServiceDescription).HasColumnName("service_description");
            entity.Property(e => e.SignedDate).HasColumnName("signed_date");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");

            entity.HasOne(d => d.ContractorPerson).WithMany(p => p.ContractsContractors)
                .HasForeignKey(d => d.ContractorPersonId)
                .HasConstraintName("FK_contracts_contractor_contractor");

            entity.HasOne(d => d.Project).WithMany(p => p.ContractsContractors)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_contracts_contractor_project");
        });

        modelBuilder.Entity<Estimate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__estimate__3213E83F5A76FDED");

            entity.ToTable("estimates");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovedAt).HasColumnName("approved_at");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");
            entity.Property(e => e.TotalActual)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_actual");
            entity.Property(e => e.TotalPlanned)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_planned");
            entity.Property(e => e.VersionNumber).HasColumnName("version_number");

            entity.HasOne(d => d.Project).WithMany(p => p.Estimates)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estimates_project");
        });

        modelBuilder.Entity<EstimateItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__estimate__3213E83F6BAB128C");

            entity.ToTable("estimate_items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActualCost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("actual_cost");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.EstimateId).HasColumnName("estimate_id");
            entity.Property(e => e.FulfillmentStatus)
                .HasMaxLength(30)
                .HasColumnName("fulfillment_status");
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .HasColumnName("item_name");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PlannedCost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("planned_cost");

            entity.HasOne(d => d.Estimate).WithMany(p => p.EstimateItems)
                .HasForeignKey(d => d.EstimateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estimate_items_estimate");
        });

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__incident__3213E83F3F95CD9C");

            entity.ToTable("incidents");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.OccurredAt).HasColumnName("occurred_at");
            entity.Property(e => e.PhotoPath)
                .HasMaxLength(500)
                .HasColumnName("photo_path");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.RelatedPersonId).HasColumnName("related_person_id");
            entity.Property(e => e.ResolutionComment).HasColumnName("resolution_comment");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");

            entity.HasOne(d => d.Project).WithMany(p => p.Incidents)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_incidents_project");

            entity.HasOne(d => d.RelatedPerson).WithMany(p => p.Incidents)
                .HasForeignKey(d => d.RelatedPersonId)
                .HasConstraintName("FK_incidents_related_person");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__invoices__3213E83FA15472DC");

            entity.ToTable("invoices");

            entity.HasIndex(e => e.InvoiceNumber, "UQ__invoices__8081A63A228AFE80").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CounterpartyId).HasColumnName("counterparty_id");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.FilePath)
                .HasMaxLength(500)
                .HasColumnName("file_path");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .HasColumnName("invoice_number");
            entity.Property(e => e.IssuedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("issued_at");
            entity.Property(e => e.PaidAt).HasColumnName("paid_at");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");

            entity.HasOne(d => d.Contract).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_invoices_contract");

            entity.HasOne(d => d.Counterparty).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CounterpartyId)
                .HasConstraintName("FK_invoices_counterparty");

            entity.HasOne(d => d.Project).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_invoices_project");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__people__3213E83F396F972D");

            entity.ToTable("people");

            entity.HasIndex(e => e.FullName, "IX_people_full_name");

            entity.HasIndex(e => e.PhonePrimary, "IX_people_phone_primary");

            entity.HasIndex(e => e.PhonePrimary, "UQ__people__B19FCF5B5F71F050").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.InternalNotes).HasColumnName("internal_notes");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.PhonePrimary)
                .HasMaxLength(50)
                .HasColumnName("phone_primary");
            entity.Property(e => e.PhoneSecondary)
                .HasMaxLength(50)
                .HasColumnName("phone_secondary");
            entity.Property(e => e.SocialLinks).HasColumnName("social_links");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__projects__3213E83F4DD6F454");

            entity.ToTable("projects");

            entity.HasIndex(e => e.Status, "IX_projects_status");

            entity.HasIndex(e => e.WeddingDate, "IX_projects_wedding_date");

            entity.HasIndex(e => e.ProjectNumber, "UQ__projects__5C6A7B0CA132DB70").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BudgetTotal)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("budget_total");
            entity.Property(e => e.ClosedAt).HasColumnName("closed_at");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.FormatType)
                .HasMaxLength(50)
                .HasColumnName("format_type");
            entity.Property(e => e.GuestCountMax).HasColumnName("guest_count_max");
            entity.Property(e => e.GuestCountMin).HasColumnName("guest_count_min");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LocationCity)
                .HasMaxLength(100)
                .HasColumnName("location_city");
            entity.Property(e => e.LocationRegion)
                .HasMaxLength(100)
                .HasColumnName("location_region");
            entity.Property(e => e.ProjectNumber)
                .HasMaxLength(50)
                .HasColumnName("project_number");
            entity.Property(e => e.ResponsibleManagerId).HasColumnName("responsible_manager_id");
            entity.Property(e => e.SpecialNotes).HasColumnName("special_notes");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.VenueType)
                .HasMaxLength(50)
                .HasColumnName("venue_type");
            entity.Property(e => e.WeddingDate).HasColumnName("wedding_date");

            entity.HasOne(d => d.ResponsibleManager).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ResponsibleManagerId)
                .HasConstraintName("FK_projects_responsible_manager");
        });

        modelBuilder.Entity<ProjectContractor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__project___3213E83FF5703D14");

            entity.ToTable("project_contractors");

            entity.HasIndex(e => e.ProjectPersonId, "UQ__project___E51222B24D1F9FFC").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingStatus)
                .HasMaxLength(30)
                .HasColumnName("booking_status");
            entity.Property(e => e.ContractFilePath)
                .HasMaxLength(500)
                .HasColumnName("contract_file_path");
            entity.Property(e => e.EstimateItemId).HasColumnName("estimate_item_id");
            entity.Property(e => e.ProjectPersonId).HasColumnName("project_person_id");
            entity.Property(e => e.RiderNotes).HasColumnName("rider_notes");
            entity.Property(e => e.ServiceCost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("service_cost");
            entity.Property(e => e.WorkEnd).HasColumnName("work_end");
            entity.Property(e => e.WorkStart).HasColumnName("work_start");

            entity.HasOne(d => d.EstimateItem).WithMany(p => p.ProjectContractors)
                .HasForeignKey(d => d.EstimateItemId)
                .HasConstraintName("FK_project_contractors_estimate_item");

            entity.HasOne(d => d.ProjectPerson).WithOne(p => p.ProjectContractor)
                .HasForeignKey<ProjectContractor>(d => d.ProjectPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_project_contractors_project_person");
        });

        modelBuilder.Entity<ProjectGuest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__project___3213E83F5B3E28F1");

            entity.ToTable("project_guests");

            entity.HasIndex(e => e.ProjectPersonId, "UQ__project___E51222B2836D8113").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccommodationNeeded)
                .HasDefaultValue(false)
                .HasColumnName("accommodation_needed");
            entity.Property(e => e.DietaryRestrictions).HasColumnName("dietary_restrictions");
            entity.Property(e => e.GuestCategory)
                .HasMaxLength(50)
                .HasColumnName("guest_category");
            entity.Property(e => e.InvitationStatus)
                .HasMaxLength(30)
                .HasColumnName("invitation_status");
            entity.Property(e => e.ProjectPersonId).HasColumnName("project_person_id");
            entity.Property(e => e.TableId).HasColumnName("table_id");
            entity.Property(e => e.TransferAddress)
                .HasMaxLength(255)
                .HasColumnName("transfer_address");
            entity.Property(e => e.TransferNeeded)
                .HasDefaultValue(false)
                .HasColumnName("transfer_needed");

            entity.HasOne(d => d.ProjectPerson).WithOne(p => p.ProjectGuest)
                .HasForeignKey<ProjectGuest>(d => d.ProjectPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_project_guests_project_person");

            entity.HasOne(d => d.Table).WithMany(p => p.ProjectGuests)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK_project_guests_table");
        });

        modelBuilder.Entity<ProjectPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__project___3213E83FE85C1284");

            entity.ToTable("project_people");

            entity.HasIndex(e => e.PersonId, "IX_project_people_person");

            entity.HasIndex(e => e.ProjectId, "IX_project_people_project");

            entity.HasIndex(e => new { e.ProjectId, e.PersonId, e.Role }, "UQ_project_people_unique_role").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("assigned_at");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");

            entity.HasOne(d => d.Person).WithMany(p => p.ProjectPeople)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_project_people_person");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectPeople)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_project_people_project");
        });

        modelBuilder.Entity<SeatingTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__seating___3213E83FE8D53690");

            entity.ToTable("seating_tables");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.LocationNote)
                .HasMaxLength(255)
                .HasColumnName("location_note");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Shape)
                .HasMaxLength(30)
                .HasColumnName("shape");
            entity.Property(e => e.TableNumber).HasColumnName("table_number");

            entity.HasOne(d => d.Project).WithMany(p => p.SeatingTables)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_seating_tables_project");
        });

        modelBuilder.Entity<Timeline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__timeline__3213E83FCE2929F5");

            entity.ToTable("timeline");

            entity.HasIndex(e => e.ProjectId, "UQ__timeline__BC799E1E4A338CA9").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovedAt).HasColumnName("approved_at");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");

            entity.HasOne(d => d.Project).WithOne(p => p.Timeline)
                .HasForeignKey<Timeline>(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_timeline_project");
        });

        modelBuilder.Entity<TimelineEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__timeline__3213E83FAE844284");

            entity.ToTable("timeline_events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActualEnd).HasColumnName("actual_end");
            entity.Property(e => e.ActualStart).HasColumnName("actual_start");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.EventDescription).HasColumnName("event_description");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.ResponsiblePersonId).HasColumnName("responsible_person_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.TimelineId).HasColumnName("timeline_id");

            entity.HasOne(d => d.ResponsiblePerson).WithMany(p => p.TimelineEvents)
                .HasForeignKey(d => d.ResponsiblePersonId)
                .HasConstraintName("FK_timeline_events_responsible");

            entity.HasOne(d => d.Timeline).WithMany(p => p.TimelineEvents)
                .HasForeignKey(d => d.TimelineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_timeline_events_timeline");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F245A47FF");

            entity.ToTable("users");

            entity.HasIndex(e => e.Login, "IX_users_login");

            entity.HasIndex(e => e.PersonId, "UQ__users__543848DE5DC1FC61").IsUnique();

            entity.HasIndex(e => e.Login, "UQ__users__7838F272D17C6DD3").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.MustChangePassword)
                .HasDefaultValue(true)
                .HasColumnName("must_change_password");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.Person).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.PersonId)
                .HasConstraintName("FK_users_person");
        });

        modelBuilder.Entity<VenueBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__venue_bo__3213E83F37B2A8F7");

            entity.ToTable("venue_bookings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingNumber)
                .HasMaxLength(50)
                .HasColumnName("booking_number");
            entity.Property(e => e.CancellationPolicy).HasColumnName("cancellation_policy");
            entity.Property(e => e.DepositAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("deposit_amount");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.FilePath)
                .HasMaxLength(500)
                .HasColumnName("file_path");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.RentalCost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("rental_cost");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");
            entity.Property(e => e.VenueId).HasColumnName("venue_id");

            entity.HasOne(d => d.Project).WithMany(p => p.VenueBookings)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_venue_bookings_project");

            entity.HasOne(d => d.Venue).WithMany(p => p.VenueBookings)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_venue_bookings_venue");
        });

        modelBuilder.Entity<VenueProposal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__venue_pr__3213E83F892002AF");

            entity.ToTable("venue_proposals");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingDate).HasColumnName("booking_date");
            entity.Property(e => e.ContractFilePath)
                .HasMaxLength(500)
                .HasColumnName("contract_file_path");
            entity.Property(e => e.DepositAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("deposit_amount");
            entity.Property(e => e.FinalPaymentDate).HasColumnName("final_payment_date");
            entity.Property(e => e.IsMainVenue)
                .HasDefaultValue(false)
                .HasColumnName("is_main_venue");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ProposedCost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("proposed_cost");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");
            entity.Property(e => e.VenueId).HasColumnName("venue_id");

            entity.HasOne(d => d.Project).WithMany(p => p.VenueProposals)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_venue_proposals_project");

            entity.HasOne(d => d.Venue).WithMany(p => p.VenueProposals)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_venue_proposals_venue");
        });

        modelBuilder.Entity<VenuesCatalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__venues_c__3213E83FF011A928");

            entity.ToTable("venues_catalog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.CapacityMax).HasColumnName("capacity_max");
            entity.Property(e => e.CapacityMin).HasColumnName("capacity_min");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(255)
                .HasColumnName("contact_person");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(50)
                .HasColumnName("contact_phone");
            entity.Property(e => e.Coordinates)
                .HasMaxLength(100)
                .HasColumnName("coordinates");
            entity.Property(e => e.CorkageFee)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("corkage_fee");
            entity.Property(e => e.FoodDeposit)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("food_deposit");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OwnAlcoholAllowed)
                .HasDefaultValue(false)
                .HasColumnName("own_alcohol_allowed");
            entity.Property(e => e.Photos).HasColumnName("photos");
            entity.Property(e => e.RentalCost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("rental_cost");
            entity.Property(e => e.Restrictions).HasColumnName("restrictions");
            entity.Property(e => e.WebsiteUrl)
                .HasMaxLength(500)
                .HasColumnName("website_url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
```

---

## FILE 32: AuthService.cs

<a id='authservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class AuthService : IAuthService
{
    private readonly WeddingAgencyContext _context;

    public User? CurrentUser { get; private set; }

    public AuthService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<User?> LoginAsync(string login, string password)
    {
        var user = await _context.Users
            .Include(u => u.Person)
            .FirstOrDefaultAsync(u => u.Login == login);

        if (user == null)
            return null;

        if (!user.IsActive)
            return null;

        if (user.PasswordHash != password)
            return null;

        CurrentUser = user;
        user.LastLogin = DateTime.Now;
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task ChangePasswordAsync(User user, string newPassword)
    {
        user.PasswordHash = newPassword; 
        user.MustChangePassword = false;
        user.LastLogin = DateTime.Now;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
```

---

## FILE 33: IAuthService.cs

<a id='iauthservicecs'></a>

```csharp
﻿using WeddingAgency.Models;

namespace WeddingAgency.Services;

public interface IAuthService
{
    Task<User?> LoginAsync(string login, string password);
    Task ChangePasswordAsync(User user, string newPassword);
    User? CurrentUser { get; }
}
```

---

## FILE 34: INavigationAware.cs

<a id='inavigationawarecs'></a>

```csharp
﻿namespace WeddingAgency.Services;

public interface INavigationAware
{
    void OnNavigatedTo(object? parameter);
}
```

---

## FILE 35: INavigationService.cs

<a id='inavigationservicecs'></a>

```csharp
﻿using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.Services;

public interface INavigationService
{
    BaseViewModel? CurrentViewModel { get; }
    event Action? CurrentViewModelChanged;
    void NavigateTo<T>() where T : BaseViewModel;
    void NavigateTo<T>(object? parameter) where T : BaseViewModel;
}
```

---

## FILE 36: IPeopleService.cs

<a id='ipeopleservicecs'></a>

```csharp
﻿using WeddingAgency.Models;

namespace WeddingAgency.Services;

public interface IPeopleService
{
    Task<List<Person>> GetAllPeopleAsync();
    Task<List<Person>> GetFilteredAsync(string? search, string? roleFilter);
    Task<Person?> GetByIdAsync(int id);
    Task UpdatePersonAsync(Person person);
    Task DeactivatePersonAsync(int personId);
    Task<Person> CreatePersonAsync(string fullName, string? phone, string? email);
    Task<List<string>> GetRolesAsync(int personId);
}
```

---

## FILE 37: IProjectClientsService.cs

<a id='iprojectclientsservicecs'></a>

```csharp
﻿using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectClientsService
{
    Task<List<ClientListItem>> GetClientsAsync(int projectId);
}
```

---

## FILE 38: IProjectContractorsService.cs

<a id='iprojectcontractorsservicecs'></a>

```csharp
﻿using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectContractorsService
{
    Task<List<ContractorListItem>> GetContractorsAsync(int projectId);
}
```

---

## FILE 39: IProjectDetailsService.cs

<a id='iprojectdetailsservicecs'></a>

```csharp
﻿using WeddingAgency.Models;

namespace WeddingAgency.Services;

public interface IProjectDetailsService
{
    Task<Project?> GetFullProjectAsync(int projectId);
}
```

---

## FILE 40: IProjectFinanceService.cs

<a id='iprojectfinanceservicecs'></a>

```csharp
﻿using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectFinanceService
{
    Task<FinanceSummaryModel?> GetSummaryAsync(int projectId);
    Task<List<FinanceTransactionModel>> GetTransactionsAsync(int projectId);
}
```

---

## FILE 41: IProjectGuestsService.cs

<a id='iprojectguestsservicecs'></a>

```csharp
﻿using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectGuestsService
{
    Task<List<GuestListItem>> GetGuestsAsync(int projectId);
    Task AddGuestAsync(int projectId, int personId);
    Task RemoveGuestAsync(int projectId, int personId);
    Task UpdateGuestAsync(int projectPersonId, string? invitationStatus, string? dietary, bool transfer, bool accommodation, int? tableNumber);
}
```

---

## FILE 42: IProjectOverviewService.cs

<a id='iprojectoverviewservicecs'></a>

```csharp
﻿using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectOverviewService
{
    Task<ProjectHeaderModel?> GetHeaderAsync(int projectId);
}
```

---

## FILE 43: IProjectPeopleService.cs

<a id='iprojectpeopleservicecs'></a>

```csharp
﻿using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectPeopleService
{
    Task AddClientAsync(int projectId, int personId);
    Task RemoveClientAsync(int projectId, int personId);
    Task<List<ClientListItem>> GetClientsAsync(int projectId);
    Task AddContractorAsync(int projectId, int personId, string? service, decimal? cost, string? notes);
    Task RemoveContractorAsync(int projectId, int personId);
    Task<List<ContractorListItem>> GetContractorsAsync(int projectId);
}
```

---

## FILE 44: IProjectService.cs

<a id='iprojectservicecs'></a>

```csharp
﻿using WeddingAgency.Models;

namespace WeddingAgency.Services;

public interface IProjectService
{
    Task<List<Project>> GetAllProjectsAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<Project> CreateProjectAsync(string projectNumber, DateOnly? weddingDate, int? guestCount, decimal? budget, string? city, int? managerId);
    Task UpdateProjectAsync(Project project);
    Task DeactivateProjectAsync(int projectId);
    Task<string> GetClientNamesAsync(int projectId);
}
```

---

## FILE 45: IProjectTimelineService.cs

<a id='iprojecttimelineservicecs'></a>

```csharp
﻿using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectTimelineService
{
    Task<List<TimelineEventItem>> GetEventsAsync(int projectId);
    Task AddEventAsync(int projectId, DateTime? start, DateTime? end, string? description, string? location, int? responsibleId, string? notes);
    Task DeleteEventAsync(int eventId);
}
```

---

## FILE 46: IProjectVenueService.cs

<a id='iprojectvenueservicecs'></a>

```csharp
﻿using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public interface IProjectVenueService
{
    Task<List<VenueItemModel>> GetVenuesAsync(int projectId);
    Task<List<VenuesCatalog>> SearchVenuesAsync(string? search);
    Task AddVenueAsync(int projectId, int venueId, decimal? rentalCost, decimal? deposit, DateOnly? eventDate);
    Task RemoveVenueAsync(int bookingId);
}
```

---

## FILE 47: IUserManagementService.cs

<a id='iusermanagementservicecs'></a>

```csharp
﻿using WeddingAgency.Models;

namespace WeddingAgency.Services;

public interface IUserManagementService
{
    Task<List<User>> GetAllUsersAsync();
    Task CreateUserAsync(string login, string fullName, bool isAdmin = false);
    Task ResetPasswordAsync(int userId);
    Task SetActiveStatusAsync(int userId, bool isActive);
}
```

---

## FILE 48: NavigationService.cs

<a id='navigationservicecs'></a>

```csharp
﻿using Microsoft.Extensions.DependencyInjection;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private BaseViewModel? _currentViewModel;

    public BaseViewModel? CurrentViewModel
    {
        get => _currentViewModel;
        private set
        {
            _currentViewModel = value;
            CurrentViewModelChanged?.Invoke();
        }
    }

    public event Action? CurrentViewModelChanged;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void NavigateTo<T>() where T : BaseViewModel
    {
        var viewModel = _serviceProvider.GetRequiredService<T>();
        CurrentViewModel = viewModel;
    }

    public void NavigateTo<T>(object? parameter) where T : BaseViewModel
    {
        var viewModel = _serviceProvider.GetRequiredService<T>();

        if (viewModel is INavigationAware aware)
            aware.OnNavigatedTo(parameter);

        CurrentViewModel = viewModel;
    }
}
```

---

## FILE 49: PeopleService.cs

<a id='peopleservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class PeopleService : IPeopleService
{
    private readonly WeddingAgencyContext _context;

    public PeopleService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<Person>> GetAllPeopleAsync()
    {
        return await _context.People
            .Where(p => !p.IsDeleted)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }
    public async Task<Person?> GetByIdAsync(int id)
    {
        return await _context.People.FindAsync(id);
    }
    public async Task<List<Person>> GetFilteredAsync(string? search, string? roleFilter)
    {
        var query = _context.People
            .Where(p => !p.IsDeleted);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.ToLower();
            query = query.Where(p =>
                p.FullName.ToLower().Contains(s) ||
                (p.PhonePrimary ?? "").Contains(s));
        }

        if (!string.IsNullOrWhiteSpace(roleFilter) && roleFilter != "Все")
        {
            switch (roleFilter)
            {
                case "Клиенты":
                    query = query.Where(p => _context.ProjectPeople
                        .Any(pp => pp.PersonId == p.Id && pp.Role == ProjectRoles.Client));
                    break;
                case "Сотрудники":
                    query = query.Where(p => _context.Users
                        .Any(u => u.PersonId == p.Id && u.IsActive));
                    break;
                case "Подрядчики":
                    query = query.Where(p => _context.ProjectPeople
                        .Any(pp => pp.PersonId == p.Id && pp.Role == ProjectRoles.Contractor));
                    break;
            }
        }

        return await query
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task<Person> CreatePersonAsync(string fullName, string? phone, string? email)
    {
        var person = new Person
        {
            FullName = fullName,
            PhonePrimary = phone ?? "-",
            Email = email,
            IsDeleted = false,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        _context.People.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task UpdatePersonAsync(Person person)
    {
        person.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
    }

    public async Task DeactivatePersonAsync(int personId)
    {
        var person = await _context.People.FindAsync(personId);
        if (person != null)
        {
            person.IsDeleted = true;
            person.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<string>> GetRolesAsync(int personId)
    {
        var roles = new List<string>();

        if (await _context.ProjectPeople.AnyAsync(pp => pp.PersonId == personId && pp.Role == ProjectRoles.Client))
            roles.Add("Клиент");

        if (await _context.Users.AnyAsync(u => u.PersonId == personId && u.IsActive))
            roles.Add("Сотрудник");

        if (await _context.ProjectPeople.AnyAsync(pp => pp.PersonId == personId && pp.Role == ProjectRoles.Contractor))
            roles.Add("Подрядчик");

        return roles;
    }
}
```

---

## FILE 50: ProjectClientsService.cs

<a id='projectclientsservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class ProjectClientsService : IProjectClientsService
{
    private readonly WeddingAgencyContext _context;

    public ProjectClientsService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<ViewModels.ProjectDetails.ClientListItem>> GetClientsAsync(int projectId)
    {
        return await _context.ProjectPeople
            .Where(pp => pp.ProjectId == projectId && pp.Role == ProjectRoles.Client)
            .Select(pp => new ViewModels.ProjectDetails.ClientListItem
            {
                PersonId = pp.PersonId,
                FullName = pp.Person.FullName,
                Phone = pp.Person.PhonePrimary,
                Email = pp.Person.Email
            })
            .ToListAsync();
    }
}
```

---

## FILE 51: ProjectContractorsService.cs

<a id='projectcontractorsservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class ProjectContractorsService : IProjectContractorsService
{
    private readonly WeddingAgencyContext _context;

    public ProjectContractorsService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<ViewModels.ProjectDetails.ContractorListItem>> GetContractorsAsync(int projectId)
    {
        return await _context.ProjectPeople
            .Where(pp => pp.ProjectId == projectId && pp.Role == ProjectRoles.Contractor)
            .Select(pp => new ViewModels.ProjectDetails.ContractorListItem
            {
                PersonId = pp.PersonId,
                FullName = pp.Person.FullName,
                Service = pp.ProjectContractor != null ? pp.ProjectContractor.EstimateItem.ItemName : null,
                Cost = pp.ProjectContractor != null ? pp.ProjectContractor.ServiceCost : null
            })
            .ToListAsync();
    }
}
```

---

## FILE 52: ProjectDetailsService.cs

<a id='projectdetailsservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class ProjectDetailsService : IProjectDetailsService
{
    private readonly WeddingAgencyContext _context;

    public ProjectDetailsService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<Project?> GetFullProjectAsync(int projectId)
    {
        return await _context.Projects
            .Include(p => p.ResponsibleManager)
            .Include(p => p.ProjectPeople).ThenInclude(pp => pp.Person)
            .Include(p => p.VenueBookings).ThenInclude(v => v.Venue)
            .Include(p => p.Estimates)
            .Include(p => p.ContractsClient)
            .Include(p => p.Timeline)
            .FirstOrDefaultAsync(p => p.Id == projectId);
    }
}
```

---

## FILE 53: ProjectFinanceService.cs

<a id='projectfinanceservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
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
```

---

## FILE 54: ProjectGuestsService.cs

<a id='projectguestsservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public class ProjectGuestsService : IProjectGuestsService
{
    private readonly WeddingAgencyContext _context;

    public ProjectGuestsService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<GuestListItem>> GetGuestsAsync(int projectId)
    {
        return await _context.ProjectPeople
            .Where(pp => pp.ProjectId == projectId && pp.Role == ProjectRoles.Guest)
            .Select(pp => new GuestListItem
            {
                Id = pp.Id,
                PersonId = pp.PersonId,
                FullName = pp.Person.FullName,
                Phone = pp.Person.PhonePrimary,
                InvitationStatus = pp.ProjectGuest != null ? pp.ProjectGuest.InvitationStatus : null,
                DietaryRestrictions = pp.ProjectGuest != null ? pp.ProjectGuest.DietaryRestrictions : null,
                TransferNeeded = pp.ProjectGuest != null && pp.ProjectGuest.TransferNeeded == true,
                AccommodationNeeded = pp.ProjectGuest != null && pp.ProjectGuest.AccommodationNeeded == true,
                TableNumber = pp.ProjectGuest != null ? pp.ProjectGuest.Table.TableNumber : null
            })
            .ToListAsync();
    }

    public async Task AddGuestAsync(int projectId, int personId)
    {
        var exists = await _context.ProjectPeople
            .AnyAsync(pp => pp.ProjectId == projectId && pp.PersonId == personId && pp.Role == ProjectRoles.Guest);

        if (!exists)
        {
            var pp = new ProjectPerson
            {
                ProjectId = projectId,
                PersonId = personId,
                Role = ProjectRoles.Guest,
                AssignedAt = DateTime.Now
            };
            _context.ProjectPeople.Add(pp);
            await _context.SaveChangesAsync();

            // Создаём запись в project_guests
            _context.ProjectGuests.Add(new ProjectGuest
            {
                ProjectPersonId = pp.Id,
                InvitationStatus = "Не отправлено"
            });
            await _context.SaveChangesAsync();
        }
    }
    public async Task UpdateGuestAsync(int projectPersonId, string? invitationStatus, string? dietary, bool transfer, bool accommodation, int? tableNumber)
    {
        var guest = await _context.ProjectGuests
            .FirstOrDefaultAsync(g => g.ProjectPersonId == projectPersonId);

        if (guest != null)
        {
            guest.InvitationStatus = invitationStatus;
            guest.DietaryRestrictions = dietary;
            guest.TransferNeeded = transfer;
            guest.AccommodationNeeded = accommodation;
            guest.TableId = tableNumber;
            await _context.SaveChangesAsync();
        }
    }
    public async Task RemoveGuestAsync(int projectId, int personId)
    {
        var pp = await _context.ProjectPeople
            .Include(p => p.ProjectGuest)
            .FirstOrDefaultAsync(p => p.ProjectId == projectId && p.PersonId == personId && p.Role == ProjectRoles.Guest);

        if (pp != null)
        {
            if (pp.ProjectGuest != null)
                _context.ProjectGuests.Remove(pp.ProjectGuest);

            _context.ProjectPeople.Remove(pp);
            await _context.SaveChangesAsync();
        }
    }
}
```

---

## FILE 55: ProjectOverviewService.cs

<a id='projectoverviewservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public class ProjectOverviewService : IProjectOverviewService
{
    private readonly WeddingAgencyContext _context;

    public ProjectOverviewService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<ProjectHeaderModel?> GetHeaderAsync(int projectId)
    {
        var p = await _context.Projects
            .Include(p => p.ResponsibleManager)
            .Include(p => p.ProjectPeople)
            .FirstOrDefaultAsync(p => p.Id == projectId);

        if (p == null) return null;

        return new ProjectHeaderModel
        {
            Id = p.Id,
            ProjectNumber = p.ProjectNumber,
            WeddingDate = p.WeddingDate,
            Status = p.Status ?? "",
            BudgetTotal = p.BudgetTotal,
            GuestCountMin = p.GuestCountMin,
            LocationCity = p.LocationCity,
            ManagerName = p.ResponsibleManager?.FullName ?? "Не назначен",
            ClientCount = p.ProjectPeople.Count(pp => pp.Role == ProjectRoles.Client),
            ContractorCount = p.ProjectPeople.Count(pp => pp.Role == ProjectRoles.Contractor),
            GuestCount = p.ProjectPeople.Count(pp => pp.Role == ProjectRoles.Guest)
        };
    }
}
```

---

## FILE 56: ProjectPeopleService.cs

<a id='projectpeopleservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
using WeddingAgency.Domain.Projects;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public class ProjectPeopleService : IProjectPeopleService
{
    private readonly WeddingAgencyContext _context;

    public ProjectPeopleService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task AddClientAsync(int projectId, int personId)
    {
        var exists = await _context.ProjectPeople
            .AnyAsync(pp => pp.ProjectId == projectId && pp.PersonId == personId && pp.Role == ProjectRoles.Client);

        if (!exists)
        {
            _context.ProjectPeople.Add(new ProjectPerson
            {
                ProjectId = projectId,
                PersonId = personId,
                Role = ProjectRoles.Client,
                AssignedAt = DateTime.Now
            });
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveClientAsync(int projectId, int personId)
    {
        var pp = await _context.ProjectPeople
            .FirstOrDefaultAsync(p => p.ProjectId == projectId && p.PersonId == personId && p.Role == ProjectRoles.Client);

        if (pp != null)
        {
            _context.ProjectPeople.Remove(pp);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<ClientListItem>> GetClientsAsync(int projectId)
    {
        return await _context.ProjectPeople
            .Where(pp => pp.ProjectId == projectId && pp.Role == ProjectRoles.Client)
            .Select(pp => new ClientListItem
            {
                PersonId = pp.PersonId,
                FullName = pp.Person.FullName,
                Phone = pp.Person.PhonePrimary,
                Email = pp.Person.Email
            })
            .ToListAsync();
    }

    public async Task AddContractorAsync(int projectId, int personId, string? service, decimal? cost, string? notes)
    {
        var exists = await _context.ProjectPeople
            .AnyAsync(pp => pp.ProjectId == projectId && pp.PersonId == personId && pp.Role == ProjectRoles.Contractor);

        if (!exists)
        {
            var pp = new ProjectPerson
            {
                ProjectId = projectId,
                PersonId = personId,
                Role = ProjectRoles.Contractor,
                AssignedAt = DateTime.Now
            };
            _context.ProjectPeople.Add(pp);
            await _context.SaveChangesAsync();

            _context.ProjectContractors.Add(new ProjectContractor
            {
                ProjectPersonId = pp.Id,
                ServiceCost = cost,
                RiderNotes = notes
            });
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveContractorAsync(int projectId, int personId)
    {
        var pp = await _context.ProjectPeople
            .Include(p => p.ProjectContractor)
            .FirstOrDefaultAsync(p => p.ProjectId == projectId && p.PersonId == personId && p.Role == ProjectRoles.Contractor);

        if (pp != null)
        {
            if (pp.ProjectContractor != null)
                _context.ProjectContractors.Remove(pp.ProjectContractor);

            _context.ProjectPeople.Remove(pp);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<ContractorListItem>> GetContractorsAsync(int projectId)
    {
        return await _context.ProjectPeople
            .Where(pp => pp.ProjectId == projectId && pp.Role == ProjectRoles.Contractor)
            .Select(pp => new ContractorListItem
            {
                PersonId = pp.PersonId,
                FullName = pp.Person.FullName,
                Service = pp.ProjectContractor != null ? pp.ProjectContractor.EstimateItem.ItemName : null,
                Cost = pp.ProjectContractor != null ? pp.ProjectContractor.ServiceCost : null
            })
            .ToListAsync();
    }
}
```

---

## FILE 57: ProjectService.cs

<a id='projectservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class ProjectService : IProjectService
{
    private readonly WeddingAgencyContext _context;

    public ProjectService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllProjectsAsync()
    {
        return await _context.Projects
            .Include(p => p.ResponsibleManager)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _context.Projects
            .Include(p => p.ResponsibleManager)
            .Include(p => p.ProjectPeople).ThenInclude(pp => pp.Person)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Project> CreateProjectAsync(string projectNumber, DateOnly? weddingDate, int? guestCount, decimal? budget, string? city, int? managerId)
    {
        var project = new Project
        {
            ProjectNumber = projectNumber,
            WeddingDate = weddingDate,
            GuestCountMin = guestCount,
            BudgetTotal = budget,
            LocationCity = city,
            ResponsibleManagerId = managerId,
            Status = "Новый",
            CreatedAt = DateTime.Now
        };
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task UpdateProjectAsync(Project project)
    {
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
    }

    public async Task DeactivateProjectAsync(int projectId)
    {
        var project = await _context.Projects.FindAsync(projectId);
        if (project != null)
        {
            project.Status = "Закрыт";
            project.ClosedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<string> GetClientNamesAsync(int projectId)
    {
        var clients = await _context.ProjectPeople
            .Where(pp => pp.ProjectId == projectId && pp.Role == "Client")
            .Select(pp => pp.Person.FullName)
            .ToListAsync();

        return clients.Any() ? string.Join(", ", clients) : "Нет клиентов";
    }
}
```

---

## FILE 58: ProjectTimelineService.cs

<a id='projecttimelineservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public class ProjectTimelineService : IProjectTimelineService
{
    private readonly WeddingAgencyContext _context;

    public ProjectTimelineService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<TimelineEventItem>> GetEventsAsync(int projectId)
    {
        return await _context.TimelineEvents
            .Where(te => te.Timeline.ProjectId == projectId)
            .Include(te => te.ResponsiblePerson).ThenInclude(pp => pp.Person)
            .OrderBy(te => te.StartTime)
            .Select(te => new TimelineEventItem
            {
                Id = te.Id,
                StartTime = te.StartTime,
                EndTime = te.EndTime,
                Location = te.Location,
                Description = te.EventDescription,
                ResponsiblePerson = te.ResponsiblePerson != null ? te.ResponsiblePerson.Person.FullName : null,
                Notes = te.Notes
            })
            .ToListAsync();
    }

    public async Task AddEventAsync(int projectId, DateTime? start, DateTime? end, string? description, string? location, int? responsiblePersonId, string? notes)
    {
        // 1. Убедимся, что у проекта есть таймлайн
        var timeline = await _context.Timelines.FirstOrDefaultAsync(t => t.ProjectId == projectId);
        if (timeline == null)
        {
            timeline = new Timeline
            {
                ProjectId = projectId,
                Status = "Активен"
            };
            _context.Timelines.Add(timeline);
            await _context.SaveChangesAsync();
        }

        // 2. Находим ProjectPerson для ответственного
        // Ответственный должен быть связан с этим проектом.
        // Если responsiblePersonId null, то и ResponsiblePersonId в событии будет null.
        int? projectPersonId = null;

        if (responsiblePersonId.HasValue)
        {
            var projectPerson = await _context.ProjectPeople
                .FirstOrDefaultAsync(pp => pp.ProjectId == projectId && pp.PersonId == responsiblePersonId.Value);

            if (projectPerson != null)
            {
                projectPersonId = projectPerson.Id;
            }
            // Если человек не добавлен в проект ни в какой роли, 
            // мы можем либо добавить его автоматически, либо оставить null.
            // В данном случае оставим null, чтобы не ломать логику ролей, 
            // либо можно добавить его как "Coordinator" или другую роль, если требуется.
        }

        var eventItem = new TimelineEvent
        {
            TimelineId = timeline.Id,
            StartTime = start,
            EndTime = end,
            EventDescription = description,
            Location = location,
            ResponsiblePersonId = projectPersonId, // Используем ID из ProjectPeople
            Notes = notes
        };

        _context.TimelineEvents.Add(eventItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEventAsync(int eventId)
    {
        var eventItem = await _context.TimelineEvents.FindAsync(eventId);
        if (eventItem != null)
        {
            _context.TimelineEvents.Remove(eventItem);
            await _context.SaveChangesAsync();
        }
    }
}
```

---

## FILE 59: ProjectVenueService.cs

<a id='projectvenueservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.Services;

public class ProjectVenueService : IProjectVenueService
{
    private readonly WeddingAgencyContext _context;

    public ProjectVenueService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<VenueItemModel>> GetVenuesAsync(int projectId)
    {
        return await _context.VenueBookings
            .Where(vb => vb.ProjectId == projectId)
            .Include(vb => vb.Venue)
            .Select(vb => new VenueItemModel
            {
                BookingId = vb.Id,
                VenueName = vb.Venue.Name,
                Address = vb.Venue.Address,
                City = vb.Venue.City,
                RentalCost = vb.RentalCost,
                DepositAmount = vb.DepositAmount,
                Status = vb.Status,
                EventDate = vb.EventDate
            })
            .ToListAsync();
    }

    public async Task<List<VenuesCatalog>> SearchVenuesAsync(string? search)
    {
        var query = _context.VenuesCatalogs.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(v => v.Name.Contains(search) || v.City.Contains(search));

        return await query.Take(10).ToListAsync();
    }

    public async Task AddVenueAsync(int projectId, int venueId, decimal? rentalCost, decimal? deposit, DateOnly? eventDate)
    {
        var booking = new VenueBooking
        {
            ProjectId = projectId,
            VenueId = venueId,
            RentalCost = rentalCost,
            DepositAmount = deposit,
            EventDate = eventDate,
            Status = "Забронировано"
        };
        _context.VenueBookings.Add(booking);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveVenueAsync(int bookingId)
    {
        var booking = await _context.VenueBookings.FindAsync(bookingId);
        if (booking != null)
        {
            _context.VenueBookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}
```

---

## FILE 60: UserManagementService.cs

<a id='usermanagementservicecs'></a>

```csharp
﻿using Microsoft.EntityFrameworkCore;
using WeddingAgency.Models;

namespace WeddingAgency.Services;

public class UserManagementService : IUserManagementService
{
    private readonly WeddingAgencyContext _context;

    public UserManagementService(WeddingAgencyContext context)
    {
        _context = context;
    }

    public async Task<List<Models.User>> GetAllUsersAsync()
    {
        return await _context.Users
            .Include(u => u.Person)
            .ToListAsync();
    }

    public async Task CreateUserAsync(string login, string fullName, bool isAdmin = false)
    {
        if (await _context.Users.AnyAsync(u => u.Login == login))
            throw new InvalidOperationException("Пользователь с таким логином уже существует.");

        var person = new Person
        {
            FullName = fullName,
            PhonePrimary = "-",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        _context.People.Add(person);
        await _context.SaveChangesAsync();

        var user = new Models.User
        {
            Login = login,
            PasswordHash = "1",
            IsAdmin = isAdmin,
            MustChangePassword = true,
            IsActive = true,
            PersonId = person.Id,
            CreatedAt = DateTime.Now
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task ResetPasswordAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user is null) return;

        user.PasswordHash = "1"; 
        user.MustChangePassword = true;
        await _context.SaveChangesAsync();
    }

    public async Task SetActiveStatusAsync(int userId, bool isActive)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user is null) return;

        user.IsActive = isActive;
        await _context.SaveChangesAsync();
    }
}
```

---

## FILE 61: MaterialTheme.xaml

<a id='materialthemexaml'></a>

```xml
﻿<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
                    xmlns:helpers="clr-namespace:WeddingAgency.Core.Helpers">

    <ResourceDictionary.MergedDictionaries>
        <materialDesign:BundledTheme BaseTheme="Light"
                                     PrimaryColor="DeepPurple"
                                     SecondaryColor="Amber" />
        <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesign3.Defaults.xaml" />
    </ResourceDictionary.MergedDictionaries>

    <!-- Конвертеры -->
    <helpers:StringToVisibilityConverter x:Key="StringToVisibilityConverter" />
    <helpers:InvertBoolConverter x:Key="InvertBoolConverter" />
    <helpers:IsNotNullConverter x:Key="IsNotNullConverter" />
    <helpers:StatusToColorConverter x:Key="StatusToColorConverter" />
    <helpers:BoolToVisibilityConverter x:Key="BoolToVisibilityConverter" />

    <!-- Стиль кнопки бокового меню -->
    <Style x:Key="SidebarButton"
           TargetType="Button"
           BasedOn="{StaticResource MaterialDesignFlatButton}">
        <Setter Property="HorizontalAlignment" Value="Stretch" />
        <Setter Property="HorizontalContentAlignment" Value="Stretch" />
        <Setter Property="VerticalContentAlignment" Value="Center" />
        <Setter Property="Height" Value="44" />
        <Setter Property="Padding" Value="12,0" />
        <Setter Property="Margin" Value="4,2" />
        <Setter Property="FontSize" Value="14" />
    </Style>

    <!-- Стиль верхней панели -->
    <Style x:Key="HeaderBar" TargetType="Border">
        <Setter Property="Background" Value="{DynamicResource MaterialDesignPaper}" />
        <Setter Property="Padding" Value="16,12" />
        <Setter Property="Margin" Value="0" />
    </Style>

</ResourceDictionary>
```

---

## FILE 62: AdminUsersViewModel.cs

<a id='adminusersviewmodelcs'></a>

```csharp
﻿using System.Collections.ObjectModel;
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
```

---

## FILE 63: BaseViewModel.cs

<a id='baseviewmodelcs'></a>

```csharp
﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace WeddingAgency.ViewModels.Base;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    public virtual string Title { get; set; } = string.Empty;
}
```

---

## FILE 64: ChangePasswordViewModel.cs

<a id='changepasswordviewmodelcs'></a>

```csharp
﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class ChangePasswordViewModel : BaseViewModel
{
    private readonly IAuthService _authService;

    [ObservableProperty]
    private string _newPassword = string.Empty;

    [ObservableProperty]
    private string _confirmPassword = string.Empty;

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    public override string Title => "Смена пароля";

    public event Action? PasswordChanged;

    public ChangePasswordViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [RelayCommand]
    private async Task ChangePasswordAsync()
    {
        ErrorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(NewPassword) || string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            ErrorMessage = "Заполните все поля";
            return;
        }

        if (NewPassword.Length < 4)
        {
            ErrorMessage = "Пароль должен быть не менее 4 символов";
            return;
        }

        if (NewPassword != ConfirmPassword)
        {
            ErrorMessage = "Пароли не совпадают";
            return;
        }

        var user = _authService.CurrentUser;
        if (user == null)
        {
            ErrorMessage = "Ошибка сессии";
            return;
        }

        IsBusy = true;

        try
        {
            await _authService.ChangePasswordAsync(user, NewPassword);
            PasswordChanged?.Invoke();
        }
        finally
        {
            IsBusy = false;
        }
    }
}
```

---

## FILE 65: ContractorsViewModel.cs

<a id='contractorsviewmodelcs'></a>

```csharp
﻿using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class ContractorsViewModel : BaseViewModel
{
    public override string Title => "Подрядчики";
}
```

---

## FILE 66: CreateProjectViewModel.cs

<a id='createprojectviewmodelcs'></a>

```csharp
﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using WeddingAgency.Models;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class CreateProjectViewModel : BaseViewModel
{
    private readonly IProjectService _projectService;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private string _projectNumber = string.Empty;

    [ObservableProperty]
    private DateOnly? _weddingDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(3));

    [ObservableProperty]
    private string? _locationCity;

    [ObservableProperty]
    private decimal? _budgetTotal;

    [ObservableProperty]
    private int? _guestCount = 50;

    [ObservableProperty]
    private string _status = "Новый";

    [ObservableProperty]
    private ObservableCollection<User> _managers = new();

    [ObservableProperty]
    private User? _selectedManager;

    public event Action? ProjectCreated;
    public event Action? Cancelled;

    public override string Title => "Новый проект";

    public CreateProjectViewModel(IProjectService projectService, IServiceProvider serviceProvider)
    {
        _projectService = projectService;
        _serviceProvider = serviceProvider;
        ProjectNumber = "PRJ-" + DateTime.Now.ToString("yyyyMMdd-HHmm");
        _ = LoadManagersAsync();
    }

    private async Task LoadManagersAsync()
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();
        var users = await context.Users
            .Include(u => u.Person)
            .Where(u => u.IsActive)
            .ToListAsync();
        Managers = new ObservableCollection<User>(users);
    }

    [RelayCommand]
    private async Task CreateAsync()
    {
        if (string.IsNullOrWhiteSpace(ProjectNumber))
            return;

        await _projectService.CreateProjectAsync(
            ProjectNumber,
            WeddingDate,
            GuestCount,
            BudgetTotal,
            LocationCity,
            SelectedManager?.PersonId);

        ProjectCreated?.Invoke();
    }

    [RelayCommand]
    private void Cancel()
    {
        Cancelled?.Invoke();
    }
}
```

---

## FILE 67: DashboardViewModel.cs

<a id='dashboardviewmodelcs'></a>

```csharp
﻿using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class DashboardViewModel : BaseViewModel
{
    public override string Title => "Дашборд";
}
```

---

## FILE 68: FinanceViewModel.cs

<a id='financeviewmodelcs'></a>

```csharp
﻿using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class FinanceViewModel : BaseViewModel
{
    public override string Title => "Финансы";
}
```

---

## FILE 69: GlobalUsings.cs

<a id='globalusingscs'></a>

```csharp
﻿global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;
```

---

## FILE 70: LoginViewModel.cs

<a id='loginviewmodelcs'></a>

```csharp
﻿using CommunityToolkit.Mvvm.ComponentModel;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly IAuthService _authService;

    [ObservableProperty]
    private string _login = string.Empty;

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    public override string Title => "Авторизация";

    public event Action? LoginSucceeded;
    public event Action? ChangePasswordRequired;
    public event Action? AdminLoginSucceeded;

    public LoginViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task LoginAsync(string password)
    {
        ErrorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(password))
        {
            ErrorMessage = "Введите логин и пароль";
            return;
        }

        IsBusy = true;

        try
        {
            var user = await _authService.LoginAsync(Login, password);

            if (user == null)
            {
                ErrorMessage = "Неверный логин или пароль";
                return;
            }

            if (!user.IsActive)
            {
                ErrorMessage = "Учётная запись заблокирована";
                return;
            }

            if (user.MustChangePassword)
            {
                ChangePasswordRequired?.Invoke();
            }
            else if (user.IsAdmin)
            {
                AdminLoginSucceeded?.Invoke();
            }
            else
            {
                LoginSucceeded?.Invoke();
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
}
```

---

## FILE 71: MainWindowViewModel.cs

<a id='mainwindowviewmodelcs'></a>

```csharp
﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;
using WeddingAgency.Views.Windows;

namespace WeddingAgency.ViewModels;

public partial class MainWindowViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private BaseViewModel? _currentViewModel;

    public override string Title => CurrentViewModel?.Title ?? "Wedding Agency";

    public MainWindowViewModel(INavigationService navigationService, IServiceProvider serviceProvider)
    {
        _navigationService = navigationService;
        _serviceProvider = serviceProvider;
        _navigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;
        _navigationService.NavigateTo<DashboardViewModel>();
    }

    [RelayCommand]
    private void Navigate(string parameter)
    {
        switch (parameter)
        {
            case "Dashboard":
                if (CurrentViewModel is not DashboardViewModel)
                    _navigationService.NavigateTo<DashboardViewModel>();
                break;
            case "People":
                if (CurrentViewModel is not PeopleViewModel)
                    _navigationService.NavigateTo<PeopleViewModel>();
                break;
            case "Projects":
                if (CurrentViewModel is not ProjectsViewModel)
                    _navigationService.NavigateTo<ProjectsViewModel>();
                break;
            case "Venues":
                if (CurrentViewModel is not VenuesViewModel)
                    _navigationService.NavigateTo<VenuesViewModel>();
                break;
            case "Finance":
                if (CurrentViewModel is not FinanceViewModel)
                    _navigationService.NavigateTo<FinanceViewModel>();
                break;
            case "Contractors":
                if (CurrentViewModel is not ContractorsViewModel)
                    _navigationService.NavigateTo<ContractorsViewModel>();
                break;
        }
    }

    [RelayCommand]
    private void Logout()
    {
        var mainWindow = Application.Current.Windows
            .OfType<MainWindow>()
            .FirstOrDefault();
        mainWindow?.Close();

        var loginWindow = _serviceProvider.GetRequiredService<LoginWindow>();
        loginWindow.Show();
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModel = _navigationService.CurrentViewModel;
        OnPropertyChanged(nameof(Title));
    }
}
```

---

## FILE 72: PeopleViewModel.cs

<a id='peopleviewmodelcs'></a>

```csharp
﻿using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeddingAgency.Models;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class PeopleViewModel : BaseViewModel
{
    private readonly IPeopleService _peopleService;

    [ObservableProperty]
    private ObservableCollection<Person> _people = new();

    [ObservableProperty]
    private Person? _selectedPerson;

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private string _roleFilter = "Все";

    [ObservableProperty]
    private ObservableCollection<string> _selectedRoles = new();
    // Поля для добавления
    [ObservableProperty]
    private string _newPersonName = string.Empty;

    [ObservableProperty]
    private string _newPersonPhone = string.Empty;

    [ObservableProperty]
    private string _newPersonEmail = string.Empty;

    [RelayCommand]
    private async Task AddPersonAsync()
    {
        if (string.IsNullOrWhiteSpace(NewPersonName)) return;

        await _peopleService.CreatePersonAsync(NewPersonName.Trim(), NewPersonPhone.Trim(), NewPersonEmail.Trim());
        NewPersonName = string.Empty;
        NewPersonPhone = string.Empty;
        NewPersonEmail = string.Empty;
        await LoadPeople();
    }

    public string RolesDisplay =>
        SelectedRoles.Any()
            ? string.Join(", ", SelectedRoles)
            : "Нет ролей";

    public override string Title => "Люди";

    public PeopleViewModel(IPeopleService peopleService)
    {
        _peopleService = peopleService;
    }

    public async Task InitializeAsync() => await LoadPeople();

    [RelayCommand]
    private async Task LoadPeople()
    {
        IsBusy = true;
        try
        {
            var list = await _peopleService.GetFilteredAsync(SearchText, RoleFilter);
            People = new ObservableCollection<Person>(list);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task ArchivePerson()
    {
        if (SelectedPerson == null) return;
        await _peopleService.DeactivatePersonAsync(SelectedPerson.Id);
        await LoadPeople();
    }

    partial void OnSearchTextChanged(string value) => LoadPeopleCommand.Execute(null);
    partial void OnRoleFilterChanged(string value) => LoadPeopleCommand.Execute(null);

    partial void OnSelectedPersonChanged(Person? value)
    {
        if (value != null)
            _ = LoadRolesSafeAsync(value.Id);
        else
            SelectedRoles.Clear();
    }

    private async Task LoadRolesSafeAsync(int personId)
    {
        try
        {
            var roles = await _peopleService.GetRolesAsync(personId);
            SelectedRoles = new ObservableCollection<string>(roles);
            OnPropertyChanged(nameof(RolesDisplay));
        }
        catch
        {
            SelectedRoles.Clear();
            OnPropertyChanged(nameof(RolesDisplay));
        }
    }
}
```

---

## FILE 73: ProjectDetailsViewModel.cs

<a id='projectdetailsviewmodelcs'></a>

```csharp
﻿using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeddingAgency.Models;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;
using WeddingAgency.ViewModels.ProjectDetails;

namespace WeddingAgency.ViewModels;

public partial class ProjectDetailsViewModel : BaseViewModel, INavigationAware
{
    private readonly IProjectOverviewService _overviewService;
    private readonly IProjectPeopleService _peopleService;
    private readonly IProjectFinanceService _financeService;
    private readonly IProjectGuestsService _guestsService;
    private readonly IProjectVenueService _venueService;
    private readonly IProjectTimelineService _timelineService;
    private readonly INavigationService _navigation;
    private readonly IServiceProvider _serviceProvider;

    private int _projectId;
    private bool _isLoading;

    [ObservableProperty]
    private ProjectHeaderModel? _header;

    // Клиенты
    [ObservableProperty]
    private ObservableCollection<ClientListItem> _clients = new();

    [ObservableProperty]
    private string _clientSearchText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<PersonSearchResult> _clientSearchResults = new();

    // Подрядчики
    [ObservableProperty]
    private ObservableCollection<ContractorListItem> _contractors = new();

    [ObservableProperty]
    private string _contractorSearchText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<PersonSearchResult> _contractorSearchResults = new();

    [ObservableProperty]
    private string? _contractorService;

    [ObservableProperty]
    private decimal? _contractorCost;

    // Гости
    [ObservableProperty]
    private ObservableCollection<GuestListItem> _guests = new();

    [ObservableProperty]
    private string _guestSearchText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<PersonSearchResult> _guestSearchResults = new();

    // Площадка
    [ObservableProperty]
    private ObservableCollection<VenueItemModel> _venues = new();

    // Поиск площадок
    [ObservableProperty]
    private string _venueSearchText = string.Empty;

    [ObservableProperty]
    private ObservableCollection<VenuesCatalog> _venueSearchResults = new();

    [ObservableProperty]
    private decimal? _newVenueRentalCost;

    [ObservableProperty]
    private decimal? _newVenueDeposit;

    [ObservableProperty]
    private DateOnly? _newVenueEventDate;

    // Таймлайн
    [ObservableProperty]
    private ObservableCollection<TimelineEventItem> _timelineEvents = new();

    // Таймлайн - поля для добавления
    [ObservableProperty]
    private DateTime? _newEventStartTime;

    [ObservableProperty]
    private DateTime? _newEventEndTime;

    [ObservableProperty]
    private string? _newEventDescription;

    [ObservableProperty]
    private string? _newEventLocation;

    [ObservableProperty]
    private string? _newEventNotes;

    [ObservableProperty]
    private User? _newEventResponsible;

    // Финансы
    [ObservableProperty]
    private FinanceSummaryModel? _financeSummary;

    [ObservableProperty]
    private ObservableCollection<FinanceTransactionModel> _financeTransactions = new();

    [ObservableProperty]
    private bool _isFinanceLoaded;

    // Edit mode
    [ObservableProperty]
    private bool _isEditMode;

    [ObservableProperty]
    private string? _editProjectNumber;

    [ObservableProperty]
    private DateOnly? _editWeddingDate;

    [ObservableProperty]
    private string? _editLocationCity;

    [ObservableProperty]
    private decimal? _editBudgetTotal;

    [ObservableProperty]
    private int? _editGuestCount;

    [ObservableProperty]
    private string? _editStatus;

    // Менеджеры для выбора
    [ObservableProperty]
    private ObservableCollection<User> _managers = new();

    [ObservableProperty]
    private User? _selectedManager;

    public override string Title => $"Проект: {Header?.ProjectNumber ?? ""}";

    public ProjectDetailsViewModel(
        IProjectOverviewService overviewService,
        IProjectPeopleService peopleService,
        IProjectFinanceService financeService,
        IProjectGuestsService guestsService,
        IProjectVenueService venueService,
        IProjectTimelineService timelineService,
        INavigationService navigation,
        IServiceProvider serviceProvider)
    {
        _overviewService = overviewService;
        _peopleService = peopleService;
        _financeService = financeService;
        _guestsService = guestsService;
        _venueService = venueService;
        _timelineService = timelineService;
        _navigation = navigation;
        _serviceProvider = serviceProvider;
    }

    public async void OnNavigatedTo(object? parameter)
    {
        if (parameter is int projectId)
        {
            // Если уже загружен этот же проект — ничего не делаем
            if (_projectId == projectId && Header != null)
                return;

            if (_isLoading) return;

            _projectId = projectId;
            _isLoading = true;

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();
                var p = await context.Projects
                    .Include(p => p.ResponsibleManager)
                    .Include(p => p.ProjectPeople)
                    .FirstOrDefaultAsync(p => p.Id == projectId);

                if (p != null)
                {
                    Header = new ProjectHeaderModel
                    {
                        Id = p.Id,
                        ProjectNumber = p.ProjectNumber,
                        WeddingDate = p.WeddingDate,
                        Status = p.Status ?? "",
                        BudgetTotal = p.BudgetTotal,
                        GuestCountMin = p.GuestCountMin,
                        LocationCity = p.LocationCity,
                        ManagerName = p.ResponsibleManager?.FullName ?? "Не назначен",
                        ClientCount = p.ProjectPeople.Count(pp => pp.Role == "Client"),
                        ContractorCount = p.ProjectPeople.Count(pp => pp.Role == "Contractor"),
                        GuestCount = p.ProjectPeople.Count(pp => pp.Role == "Guest")
                    };
                    OnPropertyChanged(nameof(Title));
                }
            }
            finally
            {
                _isLoading = false;
            }
        }
    }

    // ========== EDIT MODE ==========

    [RelayCommand]
    private async Task EnableEditMode()
    {
        if (Header == null) return;

        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();
        var project = await context.Projects.FindAsync(_projectId);

        if (project == null) return;

        EditProjectNumber = project.ProjectNumber;
        EditWeddingDate = project.WeddingDate;
        EditLocationCity = project.LocationCity;
        EditBudgetTotal = project.BudgetTotal;
        EditGuestCount = project.GuestCountMin;
        EditStatus = project.Status;

        var users = await context.Users
            .Include(u => u.Person)
            .Where(u => u.IsActive)
            .ToListAsync();
        Managers = new ObservableCollection<User>(users);
        SelectedManager = users.FirstOrDefault(u => u.Id == project.ResponsibleManagerId);

        IsEditMode = true;
    }

    [RelayCommand]
    private void CancelEdit()
    {
        IsEditMode = false;
    }

    [RelayCommand]
    private async Task SaveEditAsync()
    {
        if (Header == null) return;

        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();

        var project = await context.Projects.FindAsync(_projectId);
        if (project == null) return;

        project.ProjectNumber = EditProjectNumber ?? Header.ProjectNumber;
        project.WeddingDate = EditWeddingDate;
        project.LocationCity = EditLocationCity;
        project.BudgetTotal = EditBudgetTotal;
        project.GuestCountMin = EditGuestCount;
        project.Status = EditStatus ?? Header.Status;
        project.ResponsibleManagerId = SelectedManager?.PersonId;

        await context.SaveChangesAsync();

        Header = new ProjectHeaderModel
        {
            Id = Header.Id,
            ProjectNumber = project.ProjectNumber,
            WeddingDate = project.WeddingDate,
            Status = project.Status ?? "",
            BudgetTotal = project.BudgetTotal,
            GuestCountMin = project.GuestCountMin,
            LocationCity = project.LocationCity,
            ManagerName = SelectedManager?.Person?.FullName ?? "Не назначен",
            ClientCount = Header.ClientCount,
            ContractorCount = Header.ContractorCount,
            GuestCount = Header.GuestCount
        };
        OnPropertyChanged(nameof(Title));

        IsEditMode = false;
    }

    private WeddingAgencyContext GetContext() => _serviceProvider.GetRequiredService<WeddingAgencyContext>();

    // ========== КЛИЕНТЫ ==========

    [RelayCommand]
    private async Task LoadClientsAsync()
    {
        var list = await _peopleService.GetClientsAsync(_projectId);
        Clients = new ObservableCollection<ClientListItem>(list);
    }

    [RelayCommand]
    private async Task SearchClientsAsync()
    {
        if (string.IsNullOrWhiteSpace(ClientSearchText))
        {
            ClientSearchResults.Clear();
            return;
        }

        // ИСПРАВЛЕНИЕ: Используем GetContext() вместо new WeddingAgencyContext()
        var context = GetContext();

        var searchLower = ClientSearchText.ToLower().Trim();

        var results = await context.People
            .Where(p => !p.IsDeleted &&
                (p.FullName != null && p.FullName.ToLower().Contains(searchLower)) ||
                (p.PhonePrimary != null && p.PhonePrimary.ToLower().Contains(searchLower)))
            .Take(15)
            .Select(p => new PersonSearchResult
            {
                Id = p.Id,
                FullName = p.FullName,
                Phone = p.PhonePrimary
            })
            .ToListAsync();

        ClientSearchResults = new ObservableCollection<PersonSearchResult>(results);
    }

    [RelayCommand]
    private async Task AddClientAsync(PersonSearchResult? person)
    {
        if (person == null) return;
        await _peopleService.AddClientAsync(_projectId, person.Id);
        ClientSearchText = string.Empty;
        ClientSearchResults.Clear();
        await LoadClientsAsync();
        await RefreshHeaderAsync();
    }

    [RelayCommand]
    private async Task RemoveClientAsync(object? parameter)
    {
        var client = parameter as ClientListItem;
        if (client == null) return;

        await _peopleService.RemoveClientAsync(_projectId, client.PersonId);
        await LoadClientsAsync();
        await RefreshHeaderAsync();
    }

    // ========== ПОДРЯДЧИКИ ==========

    [RelayCommand]
    private async Task LoadContractorsAsync()
    {
        var list = await _peopleService.GetContractorsAsync(_projectId);
        Contractors = new ObservableCollection<ContractorListItem>(list);
    }

    [RelayCommand]
    private async Task SearchContractorsAsync()
    {
        if (string.IsNullOrWhiteSpace(ContractorSearchText))
        {
            ContractorSearchResults.Clear();
            return;
        }

        // ИСПРАВЛЕНИЕ: Используем GetContext() вместо new WeddingAgencyContext()
        var context = GetContext();

        var searchLower = ContractorSearchText.ToLower().Trim();

        var results = await context.People
            .Where(p => !p.IsDeleted &&
                (p.FullName != null && p.FullName.ToLower().Contains(searchLower)) ||
                (p.PhonePrimary != null && p.PhonePrimary.ToLower().Contains(searchLower)))
            .Take(15)
            .Select(p => new PersonSearchResult
            {
                Id = p.Id,
                FullName = p.FullName,
                Phone = p.PhonePrimary
            })
            .ToListAsync();

        ContractorSearchResults = new ObservableCollection<PersonSearchResult>(results);
    }

    [RelayCommand]
    private async Task AddContractorAsync(PersonSearchResult? person)
    {
        if (person == null) return;
        await _peopleService.AddContractorAsync(_projectId, person.Id, ContractorService, ContractorCost, null);
        ContractorSearchText = string.Empty;
        ContractorService = null;
        ContractorCost = null;
        ContractorSearchResults.Clear();
        await LoadContractorsAsync();
        await RefreshHeaderAsync();
    }

    [RelayCommand]
    private async Task RemoveContractorAsync(object? parameter)
    {
        var contractor = parameter as ContractorListItem;
        if (contractor == null) return;

        await _peopleService.RemoveContractorAsync(_projectId, contractor.PersonId);
        await LoadContractorsAsync();
        await RefreshHeaderAsync();
    }

    // ========== ГОСТИ ==========

    [RelayCommand]
    private async Task LoadGuestsAsync()
    {
        var list = await _guestsService.GetGuestsAsync(_projectId);
        Guests = new ObservableCollection<GuestListItem>(list);
    }

    [RelayCommand]
    private async Task SearchGuestsAsync()
    {
        if (string.IsNullOrWhiteSpace(GuestSearchText))
        {
            GuestSearchResults.Clear();
            return;
        }

        // ИСПРАВЛЕНИЕ: Используем GetContext() вместо new WeddingAgencyContext()
        var context = GetContext();

        var searchLower = GuestSearchText.ToLower().Trim();

        var results = await context.People
            .Where(p => !p.IsDeleted &&
                (p.FullName != null && p.FullName.ToLower().Contains(searchLower)) ||
                (p.PhonePrimary != null && p.PhonePrimary.ToLower().Contains(searchLower)))
            .Take(15)
            .Select(p => new PersonSearchResult
            {
                Id = p.Id,
                FullName = p.FullName,
                Phone = p.PhonePrimary
            })
            .ToListAsync();

        GuestSearchResults = new ObservableCollection<PersonSearchResult>(results);
    }

    [RelayCommand]
    private async Task AddGuestAsync(PersonSearchResult? person)
    {
        if (person == null) return;
        await _guestsService.AddGuestAsync(_projectId, person.Id);
        GuestSearchText = string.Empty;
        GuestSearchResults.Clear();
        await LoadGuestsAsync();
        await RefreshHeaderAsync();
    }

    [RelayCommand]
    private async Task SaveGuestsAsync()
    {
        foreach (var guest in Guests)
        {
            await _guestsService.UpdateGuestAsync(
                guest.Id,
                guest.InvitationStatus,
                guest.DietaryRestrictions,
                guest.TransferNeeded,
                guest.AccommodationNeeded,
                guest.TableNumber);
        }
    }

    [RelayCommand]
    private async Task RemoveGuestAsync(object? parameter)
    {
        var guest = parameter as GuestListItem;
        if (guest == null) return;

        await _guestsService.RemoveGuestAsync(_projectId, guest.PersonId);
        await LoadGuestsAsync();
        await RefreshHeaderAsync();
    }

    // ========== ПЛОЩАДКА ==========

    [RelayCommand]
    private async Task LoadVenuesAsync()
    {
        var list = await _venueService.GetVenuesAsync(_projectId);
        Venues = new ObservableCollection<VenueItemModel>(list);
    }

    [RelayCommand]
    private async Task SearchVenuesAsync()
    {
        if (string.IsNullOrWhiteSpace(VenueSearchText))
        {
            VenueSearchResults.Clear();
            return;
        }
        var results = await _venueService.SearchVenuesAsync(VenueSearchText);
        VenueSearchResults = new ObservableCollection<VenuesCatalog>(results);
    }

    [RelayCommand]
    private async Task AddVenueAsync(VenuesCatalog? venue)
    {
        if (venue == null) return;
        await _venueService.AddVenueAsync(_projectId, venue.Id, NewVenueRentalCost, NewVenueDeposit, NewVenueEventDate);
        VenueSearchText = string.Empty;
        NewVenueRentalCost = null;
        NewVenueDeposit = null;
        NewVenueEventDate = null;
        VenueSearchResults.Clear();
        await LoadVenuesAsync();
    }

    [RelayCommand]
    private async Task RemoveVenueAsync(object? parameter)
    {
        var venue = parameter as VenueItemModel;
        if (venue == null) return;

        await _venueService.RemoveVenueAsync(venue.BookingId);
        await LoadVenuesAsync();
    }

    // ========== ТАЙМЛАЙН ==========

    [RelayCommand]
    private async Task LoadTimelineAsync()
    {
        var list = await _timelineService.GetEventsAsync(_projectId);
        TimelineEvents = new ObservableCollection<TimelineEventItem>(list);

        // Загружаем менеджеров для выбора ответственного, если еще не загружены
        if (Managers.Count == 0)
        {
            var context = GetContext();
            var users = await context.Users
                .Include(u => u.Person)
                .Where(u => u.IsActive)
                .ToListAsync();
            Managers = new ObservableCollection<User>(users);
        }
    }

    [RelayCommand]
    private async Task AddTimelineEventAsync()
    {
        if (string.IsNullOrWhiteSpace(NewEventDescription)) return;

        await _timelineService.AddEventAsync(
            _projectId,
            NewEventStartTime,
            NewEventEndTime,
            NewEventDescription,
            NewEventLocation,
            NewEventResponsible?.PersonId,
            NewEventNotes);

        // Очистка полей
        NewEventStartTime = null;
        NewEventEndTime = null;
        NewEventDescription = null;
        NewEventLocation = null;
        NewEventNotes = null;
        NewEventResponsible = null;

        await LoadTimelineAsync();
    }

    [RelayCommand]
    private async Task DeleteTimelineEventAsync(object? parameter)
    {
        var eventItem = parameter as TimelineEventItem;
        if (eventItem == null) return;

        await _timelineService.DeleteEventAsync(eventItem.Id);
        await LoadTimelineAsync();
    }

    // ========== ФИНАНСЫ ==========

    [RelayCommand]
    private async Task LoadFinanceAsync()
    {
        if (IsFinanceLoaded) return;
        IsBusy = true;
        try
        {
            FinanceSummary = await _financeService.GetSummaryAsync(_projectId);
            var transactions = await _financeService.GetTransactionsAsync(_projectId);
            FinanceTransactions = new ObservableCollection<FinanceTransactionModel>(transactions);
            IsFinanceLoaded = true;
        }
        finally
        {
            IsBusy = false;
        }
    }

    // ========== НАЗАД ==========

    [RelayCommand]
    private void GoBack()
    {
        _navigation.NavigateTo<ProjectsViewModel>();
    }

    private async Task RefreshHeaderAsync()
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();
        var p = await context.Projects
            .Include(p => p.ResponsibleManager)
            .Include(p => p.ProjectPeople)
            .FirstOrDefaultAsync(p => p.Id == _projectId);

        if (p != null && Header != null)
        {
            Header = new ProjectHeaderModel
            {
                Id = Header.Id,
                ProjectNumber = p.ProjectNumber,
                WeddingDate = p.WeddingDate,
                Status = p.Status ?? "",
                BudgetTotal = p.BudgetTotal,
                GuestCountMin = p.GuestCountMin,
                LocationCity = p.LocationCity,
                ManagerName = p.ResponsibleManager?.FullName ?? "Не назначен",
                ClientCount = p.ProjectPeople.Count(pp => pp.Role == "Client"),
                ContractorCount = p.ProjectPeople.Count(pp => pp.Role == "Contractor"),
                GuestCount = p.ProjectPeople.Count(pp => pp.Role == "Guest")
            };
            OnPropertyChanged(nameof(Title));
        }
    }
}
```

---

## FILE 74: ClientListItem.cs

<a id='clientlistitemcs'></a>

```csharp
﻿namespace WeddingAgency.ViewModels.ProjectDetails;

public class ClientListItem
{
    public int PersonId { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string? Phone { get; init; }
    public string? Email { get; init; }
}
```

---

## FILE 75: ContractorListItem.cs

<a id='contractorlistitemcs'></a>

```csharp
﻿namespace WeddingAgency.ViewModels.ProjectDetails;

public class ContractorListItem
{
    public int PersonId { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string? Service { get; init; }
    public decimal? Cost { get; init; }
}
```

---

## FILE 76: FinanceSummaryModel.cs

<a id='financesummarymodelcs'></a>

```csharp
﻿namespace WeddingAgency.ViewModels.ProjectDetails;

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
```

---

## FILE 77: FinanceTransactionModel.cs

<a id='financetransactionmodelcs'></a>

```csharp
﻿namespace WeddingAgency.ViewModels.ProjectDetails;

public class FinanceTransactionModel
{
    public string Type { get; init; } = string.Empty; // Счёт, Договор, Акт
    public string? Number { get; init; }
    public string? Counterparty { get; init; }
    public decimal? Amount { get; init; }
    public string? Status { get; init; }
    public DateOnly? Date { get; init; }
}
```

---

## FILE 78: GuestListItem.cs

<a id='guestlistitemcs'></a>

```csharp
﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace WeddingAgency.ViewModels.ProjectDetails;

public partial class GuestListItem : ObservableObject
{
    public int Id { get; init; }
    public int PersonId { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string? Phone { get; init; }

    [ObservableProperty]
    private string? _invitationStatus;

    [ObservableProperty]
    private string? _dietaryRestrictions;

    [ObservableProperty]
    private bool _transferNeeded;

    [ObservableProperty]
    private bool _accommodationNeeded;

    [ObservableProperty]
    private int? _tableNumber;
}
```

---

## FILE 79: PersonSearchResult.cs

<a id='personsearchresultcs'></a>

```csharp
﻿namespace WeddingAgency.ViewModels.ProjectDetails;

public class PersonSearchResult
{
    public int Id { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string? Phone { get; init; }
}
```

---

## FILE 80: ProjectDetailsModel.cs

<a id='projectdetailsmodelcs'></a>

```csharp
﻿namespace WeddingAgency.ViewModels.ProjectDetails;

public class ProjectDetailsModel
{
    public int Id { get; init; }
    public string ProjectNumber { get; init; } = string.Empty;
    public DateOnly? WeddingDate { get; init; }
    public string Status { get; init; } = string.Empty;
    public decimal? BudgetTotal { get; init; }
    public int? GuestCountMin { get; init; }
    public string? LocationCity { get; init; }
    public string? ManagerName { get; init; }
}
```

---

## FILE 81: ProjectHeaderModel.cs

<a id='projectheadermodelcs'></a>

```csharp
﻿namespace WeddingAgency.ViewModels.ProjectDetails;

public class ProjectHeaderModel
{
    public int Id { get; init; }
    public string ProjectNumber { get; init; } = string.Empty;
    public DateOnly? WeddingDate { get; init; }
    public string Status { get; init; } = string.Empty;
    public decimal? BudgetTotal { get; init; }
    public int? GuestCountMin { get; init; }
    public string? LocationCity { get; init; }
    public string? ManagerName { get; init; }
    public int ClientCount { get; init; }
    public int ContractorCount { get; init; }
    public int GuestCount { get; init; }
}
```

---

## FILE 82: TimelineEventItem.cs

<a id='timelineeventitemcs'></a>

```csharp
﻿namespace WeddingAgency.ViewModels.ProjectDetails;

public class TimelineEventItem
{
    public int Id { get; init; }
    public DateTime? StartTime { get; init; }
    public DateTime? EndTime { get; init; }
    public string? Location { get; init; }
    public string? Description { get; init; }
    public string? ResponsiblePerson { get; init; }
    public string? Notes { get; init; }
}
```

---

## FILE 83: VenueItemModel.cs

<a id='venueitemmodelcs'></a>

```csharp
﻿namespace WeddingAgency.ViewModels.ProjectDetails;

public class VenueItemModel
{
    public int BookingId { get; init; }
    public string? VenueName { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
    public decimal? RentalCost { get; init; }
    public decimal? DepositAmount { get; init; }
    public string? Status { get; init; }
    public DateOnly? EventDate { get; init; }
}
```

---

## FILE 84: ProjectListItem.cs

<a id='projectlistitemcs'></a>

```csharp
﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace WeddingAgency.ViewModels;

public partial class ProjectListItem : ObservableObject
{
    public int Id { get; init; }
    public string ProjectNumber { get; init; } = string.Empty;
    public DateOnly? WeddingDate { get; init; }
    public string? LocationCity { get; init; }
    public decimal? BudgetTotal { get; init; }
    public int? GuestCountMin { get; init; }
    public string Status { get; init; } = string.Empty;
    public string? ManagerName { get; init; }
    public string ClientsDisplay { get; init; } = "Нет клиентов";
}
```

---

## FILE 85: ProjectsViewModel.cs

<a id='projectsviewmodelcs'></a>

```csharp
﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using WeddingAgency.Models;
using WeddingAgency.Services;
using WeddingAgency.ViewModels.Base;
using WeddingAgency.Views.Windows;

namespace WeddingAgency.ViewModels;

public partial class ProjectsViewModel : BaseViewModel
{
    private readonly IProjectService _projectService;
    private readonly INavigationService _navigation;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private ObservableCollection<ProjectListItem> _projects = new();

    [ObservableProperty]
    private ProjectListItem? _selectedProject;

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private bool _canCloseProject;

    public override string Title => "Проекты";

    public ProjectsViewModel(IProjectService projectService, INavigationService navigation, IServiceProvider serviceProvider)
    {
        _projectService = projectService;
        _navigation = navigation;
        _serviceProvider = serviceProvider;
    }

    public async Task InitializeAsync() => await LoadProjects();

    [RelayCommand]
    private async Task LoadProjects()
    {
        IsBusy = true;
        try
        {
            // Используем свежий контекст для каждого запроса
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<WeddingAgencyContext>();

            var list = await context.Projects
                .Include(p => p.ResponsibleManager)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                var search = SearchText.ToLower();
                list = list.Where(p =>
                    p.ProjectNumber.ToLower().Contains(search) ||
                    (p.LocationCity?.ToLower().Contains(search) ?? false))
                    .ToList();
            }

            var items = new List<ProjectListItem>();
            foreach (var p in list)
            {
                var clientNames = await context.ProjectPeople
                    .Where(pp => pp.ProjectId == p.Id && pp.Role == "Client")
                    .Select(pp => pp.Person.FullName)
                    .ToListAsync();

                items.Add(new ProjectListItem
                {
                    Id = p.Id,
                    ProjectNumber = p.ProjectNumber,
                    WeddingDate = p.WeddingDate,
                    LocationCity = p.LocationCity,
                    BudgetTotal = p.BudgetTotal,
                    GuestCountMin = p.GuestCountMin,
                    Status = p.Status ?? "",
                    ManagerName = p.ResponsibleManager?.FullName,
                    ClientsDisplay = clientNames.Any() ? string.Join(", ", clientNames) : "Нет клиентов"
                });
            }

            Projects = new ObservableCollection<ProjectListItem>(items);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task AddProject()
    {
        var window = _serviceProvider.GetRequiredService<CreateProjectWindow>();
        var result = window.ShowDialog();

        if (result == true)
            await LoadProjects();
    }

    [RelayCommand]
    private async Task CloseProject()
    {
        if (SelectedProject == null) return;
        await _projectService.DeactivateProjectAsync(SelectedProject.Id);
        await LoadProjects();
    }

    [RelayCommand]
    private void OpenProject()
    {
        if (SelectedProject == null) return;
        _navigation.NavigateTo<ProjectDetailsViewModel>(SelectedProject.Id);
    }

    partial void OnSearchTextChanged(string value) => LoadProjectsCommand.Execute(null);

    partial void OnSelectedProjectChanged(ProjectListItem? value)
    {
        CanCloseProject = value != null && value.Status != "Закрыт";
    }
}
```

---

## FILE 86: VenuesViewModel.cs

<a id='venuesviewmodelcs'></a>

```csharp
﻿using WeddingAgency.ViewModels.Base;

namespace WeddingAgency.ViewModels;

public partial class VenuesViewModel : BaseViewModel
{
    public override string Title => "Площадки";
}
```

---

## FILE 87: ContractorsView.xaml

<a id='contractorsviewxaml'></a>

```xml
﻿<UserControl x:Class="WeddingAgency.Views.Contractors.ContractorsView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Grid Margin="24">
        <TextBlock Text="Подрядчики"
                   Style="{StaticResource MaterialDesignHeadline4TextBlock}"
                   VerticalAlignment="Center"
                   HorizontalAlignment="Center"
                   Opacity="0.5" />
    </Grid>

</UserControl>
```

---

## FILE 88: ContractorsView.xaml.cs

<a id='contractorsviewxamlcs'></a>

```csharp
﻿using System.Windows.Controls;

namespace WeddingAgency.Views.Contractors;

public partial class ContractorsView : UserControl
{
    public ContractorsView()
    {
        InitializeComponent();
    }
}
```

---

## FILE 89: DashboardView.xaml

<a id='dashboardviewxaml'></a>

```xml
﻿<UserControl x:Class="WeddingAgency.Views.Dashboard.DashboardView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes">

    <Grid Margin="24">
        <TextBlock Text="Дашборд"
                   Style="{StaticResource MaterialDesignHeadline4TextBlock}"
                   VerticalAlignment="Center"
                   HorizontalAlignment="Center"
                   Opacity="0.5" />
    </Grid>

</UserControl>
```

---

## FILE 90: DashboardView.xaml.cs

<a id='dashboardviewxamlcs'></a>

```csharp
﻿using System.Windows.Controls;

namespace WeddingAgency.Views.Dashboard;

public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();
    }
}
```

---

## FILE 91: FinanceView.xaml

<a id='financeviewxaml'></a>

```xml
﻿<UserControl x:Class="WeddingAgency.Views.Finance.FinanceView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Grid Margin="24">
        <TextBlock Text="Финансы"
                   Style="{StaticResource MaterialDesignHeadline4TextBlock}"
                   VerticalAlignment="Center"
                   HorizontalAlignment="Center"
                   Opacity="0.5" />
    </Grid>

</UserControl>
```

---

## FILE 92: FinanceView.xaml.cs

<a id='financeviewxamlcs'></a>

```csharp
﻿using System.Windows.Controls;

namespace WeddingAgency.Views.Finance;

public partial class FinanceView : UserControl
{
    public FinanceView()
    {
        InitializeComponent();
    }
}
```

---

## FILE 93: PeopleView.xaml

<a id='peopleviewxaml'></a>

```xml
﻿<UserControl x:Class="WeddingAgency.Views.People.PeopleView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
             xmlns:sys="clr-namespace:System;assembly=mscorlib">

    <UserControl.Resources>
        <x:Array x:Key="RoleFilterOptions" Type="sys:String">
            <sys:String>Все</sys:String>
            <sys:String>Клиенты</sys:String>
            <sys:String>Сотрудники</sys:String>
            <sys:String>Подрядчики</sys:String>
        </x:Array>
    </UserControl.Resources>

    <Grid Margin="20">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <!-- ПАНЕЛЬ ДОБАВЛЕНИЯ -->
        <Border Grid.Row="0"
                Background="{DynamicResource MaterialDesignPaper}"
                CornerRadius="6"
                Padding="16"
                Margin="0,0,0,16">
            <StackPanel>
                <TextBlock Text="Новый человек"
                           Style="{StaticResource MaterialDesignSubtitle1TextBlock}"
                           Margin="0,0,0,8"/>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="Auto"/>
                    </Grid.ColumnDefinitions>
                    <TextBox Grid.Column="0"
                             Text="{Binding NewPersonName, UpdateSourceTrigger=PropertyChanged}"
                             materialDesign:HintAssist.Hint="ФИО"
                             Margin="0,0,8,0"/>
                    <TextBox Grid.Column="1"
                             Text="{Binding NewPersonPhone, UpdateSourceTrigger=PropertyChanged}"
                             materialDesign:HintAssist.Hint="Телефон"
                             Margin="0,0,8,0"/>
                    <TextBox Grid.Column="2"
                             Text="{Binding NewPersonEmail, UpdateSourceTrigger=PropertyChanged}"
                             materialDesign:HintAssist.Hint="Email"
                             Margin="0,0,8,0"/>
                    <Button Grid.Column="3"
                            Content="Добавить"
                            Command="{Binding AddPersonCommand}"
                            Style="{StaticResource MaterialDesignRaisedButton}"/>
                </Grid>
            </StackPanel>
        </Border>

        <!-- ПОИСК И ФИЛЬТР -->
        <StackPanel Grid.Row="1" Orientation="Horizontal" Margin="0,0,0,12">
            <TextBox materialDesign:HintAssist.Hint="Поиск по имени или телефону"
                     Text="{Binding SearchText, UpdateSourceTrigger=PropertyChanged}"
                     Width="250" Margin="0,0,12,0" />
            <ComboBox ItemsSource="{StaticResource RoleFilterOptions}"
                      SelectedItem="{Binding RoleFilter}"
                      Width="140" />
        </StackPanel>

        <!-- ТАБЛИЦА -->
        <DataGrid Grid.Row="2"
                  ItemsSource="{Binding People}"
                  SelectedItem="{Binding SelectedPerson}"
                  AutoGenerateColumns="False"
                  IsReadOnly="True"
                  SelectionMode="Single">
            <DataGrid.Columns>
                <DataGridTextColumn Header="ФИО" Binding="{Binding FullName}" Width="*" />
                <DataGridTextColumn Header="Телефон" Binding="{Binding PhonePrimary}" Width="140" />
                <DataGridTextColumn Header="Email" Binding="{Binding Email}" Width="160" />
            </DataGrid.Columns>
        </DataGrid>

        <!-- КНОПКИ ДЕЙСТВИЙ -->
        <StackPanel Grid.Row="3" Orientation="Horizontal" Margin="0,8,0,0">
            <Button Content="Архивировать"
                    Command="{Binding ArchivePersonCommand}"
                    IsEnabled="{Binding SelectedPerson, Converter={StaticResource IsNotNullConverter}}"
                    Style="{StaticResource MaterialDesignFlatButton}" />
            <TextBlock Text="{Binding RolesDisplay, StringFormat='Роли: {0}'}"
                       Margin="16,0,0,0"
                       VerticalAlignment="Center"
                       Opacity="0.7" />
        </StackPanel>
    </Grid>
</UserControl>
```

---

## FILE 94: PeopleView.xaml.cs

<a id='peopleviewxamlcs'></a>

```csharp
﻿using System.Windows.Controls;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.People;

public partial class PeopleView : UserControl
{
    public PeopleView()
    {
        InitializeComponent();
        Loaded += async (_, _) =>
        {
            if (DataContext is PeopleViewModel vm)
                await vm.InitializeAsync();
        };
    }
}
```

---

## FILE 95: ProjectDetailsView.xaml

<a id='projectdetailsviewxaml'></a>

```xml
﻿<UserControl x:Class="WeddingAgency.Views.Projects.ProjectDetailsView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes">

    <Grid Margin="20">

        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <!-- BACK -->
        <Button Grid.Row="0"
                Content="← Назад"
                Command="{Binding GoBackCommand}"
                Style="{StaticResource MaterialDesignFlatButton}"
                HorizontalAlignment="Left"
                Margin="0,0,0,12"/>

        <!-- ========================= -->
        <!-- VIEW HEADER -->
        <!-- ========================= -->

        <Border Grid.Row="1"
                Background="{DynamicResource MaterialDesignPaper}"
                CornerRadius="6"
                Padding="24"
                Margin="0,0,0,12"
                Visibility="{Binding IsEditMode, Converter={StaticResource InvertBoolConverter}}">

            <Grid>

                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                </Grid.RowDefinitions>

                <!-- TOP -->
                <Grid Grid.Row="0">

                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="Auto"/>
                    </Grid.ColumnDefinitions>

                    <TextBlock Text="{Binding Header.ProjectNumber}"
                               FontSize="34"
                               FontWeight="Bold"
                               VerticalAlignment="Center"/>

                    <Button Grid.Column="1"
                            Content="Редактировать"
                            Command="{Binding EnableEditModeCommand}"
                            Style="{StaticResource MaterialDesignRaisedButton}"/>

                </Grid>

                <!-- INFO -->
                <UniformGrid Grid.Row="1"
                             Columns="5"
                             Margin="0,24,0,0">

                    <StackPanel>
                        <TextBlock Text="Статус"
                                   Foreground="Gray"
                                   FontSize="12"/>
                        <TextBlock Text="{Binding Header.Status}"
                                   FontWeight="SemiBold"/>
                    </StackPanel>

                    <StackPanel>
                        <TextBlock Text="Дата"
                                   Foreground="Gray"
                                   FontSize="12"/>
                        <TextBlock Text="{Binding Header.WeddingDate, StringFormat={}{0:dd.MM.yyyy}}"
                                   FontWeight="SemiBold"/>
                    </StackPanel>

                    <StackPanel>
                        <TextBlock Text="Город"
                                   Foreground="Gray"
                                   FontSize="12"/>
                        <TextBlock Text="{Binding Header.LocationCity}"
                                   FontWeight="SemiBold"/>
                    </StackPanel>

                    <StackPanel>
                        <TextBlock Text="Бюджет"
                                   Foreground="Gray"
                                   FontSize="12"/>
                        <TextBlock Text="{Binding Header.BudgetTotal, StringFormat={}{0:N0} ₽}"
                                   FontWeight="SemiBold"/>
                    </StackPanel>

                    <StackPanel>
                        <TextBlock Text="Менеджер"
                                   Foreground="Gray"
                                   FontSize="12"/>
                        <TextBlock Text="{Binding Header.ManagerName}"
                                   FontWeight="SemiBold"/>
                    </StackPanel>

                </UniformGrid>

                <!-- COUNTERS -->
                <StackPanel Grid.Row="2"
                            Orientation="Horizontal"
                            Margin="0,24,0,0">

                    <TextBlock Text="{Binding Header.ClientCount, StringFormat=Клиентов: {0}}"
                               FontWeight="Bold"
                               Margin="0,0,24,0"/>

                    <TextBlock Text="{Binding Header.ContractorCount, StringFormat=Подрядчиков: {0}}"
                               FontWeight="Bold"
                               Margin="0,0,24,0"/>

                    <TextBlock Text="{Binding Header.GuestCount, StringFormat=Гостей: {0}}"
                               FontWeight="Bold"/>

                </StackPanel>

            </Grid>

        </Border>

        <!-- ========================= -->
        <!-- EDIT HEADER -->
        <!-- ========================= -->

        <Border Grid.Row="1"
                Background="{DynamicResource MaterialDesignPaper}"
                CornerRadius="6"
                Padding="24"
                Margin="0,0,0,12"
                Visibility="{Binding IsEditMode, Converter={StaticResource BoolToVisibilityConverter}}">

            <Grid>

                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                </Grid.RowDefinitions>

                <!-- TOP -->
                <Grid Grid.Row="0">

                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="Auto"/>
                    </Grid.ColumnDefinitions>

                    <TextBox Text="{Binding EditProjectNumber}"
                             FontSize="34"
                             FontWeight="Bold"
                             Width="420"/>

                    <StackPanel Grid.Column="1"
                                Orientation="Horizontal">

                        <Button Content="Сохранить"
                                Command="{Binding SaveEditCommand}"
                                Style="{StaticResource MaterialDesignRaisedButton}"
                                Margin="0,0,8,0"/>

                        <Button Content="Отмена"
                                Command="{Binding CancelEditCommand}"
                                Style="{StaticResource MaterialDesignFlatButton}"/>

                    </StackPanel>

                </Grid>

                <!-- INFO -->
                <UniformGrid Grid.Row="1"
                             Columns="5"
                             Margin="0,24,0,0">

                    <ComboBox Text="{Binding EditStatus}">
                        <ComboBoxItem>Новый</ComboBoxItem>
                        <ComboBoxItem>Открыт</ComboBoxItem>
                        <ComboBoxItem>Закрыт</ComboBoxItem>
                    </ComboBox>

                    <DatePicker SelectedDate="{Binding EditWeddingDate}"/>

                    <TextBox Text="{Binding EditLocationCity}"
                             materialDesign:HintAssist.Hint="Город"/>

                    <TextBox Text="{Binding EditBudgetTotal}"
                             materialDesign:HintAssist.Hint="Бюджет"/>

                    <ComboBox ItemsSource="{Binding Managers}"
                              SelectedItem="{Binding SelectedManager}"
                              DisplayMemberPath="Person.FullName"/>

                </UniformGrid>

            </Grid>

        </Border>

        <!-- TABS -->
        <TabControl Grid.Row="2">

            <!-- КЛИЕНТЫ -->
            <TabItem Header="Клиенты" PreviewMouseLeftButtonDown="OnClientsTabSelected">
                <Grid Margin="12">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto" />
                        <RowDefinition Height="*" />
                    </Grid.RowDefinitions>

                    <StackPanel Orientation="Horizontal" Margin="0,0,0,8">
                        <TextBox materialDesign:HintAssist.Hint="Поиск человека по имени или телефону"
                                 Text="{Binding ClientSearchText, UpdateSourceTrigger=PropertyChanged}"
                                 Width="250"
                                 Margin="0,0,8,0"
                                 KeyDown="OnClientSearchKeyDown" />

                        <Button Content="Найти"
                                Command="{Binding SearchClientsCommand}"
                                Style="{StaticResource MaterialDesignFlatButton}" />
                    </StackPanel>

                    <ListBox Grid.Row="0"
                             ItemsSource="{Binding ClientSearchResults}"
                             Visibility="{Binding ClientSearchResults.Count, Converter={StaticResource BoolToVisibilityConverter}}"
                             MaxHeight="120"
                             Margin="0,0,0,8">

                        <ListBox.ItemTemplate>
                            <DataTemplate>
                                <Grid>
                                    <TextBlock Text="{Binding FullName}" />

                                    <Button Content="Добавить"
                                            HorizontalAlignment="Right"
                                            Command="{Binding DataContext.AddClientCommand, RelativeSource={RelativeSource AncestorType=ListBox}}"
                                            CommandParameter="{Binding}" />
                                </Grid>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>

                    <DataGrid Grid.Row="1"
                              ItemsSource="{Binding Clients}"
                              AutoGenerateColumns="False"
                              IsReadOnly="True"
                              CanUserAddRows="False"
                              ColumnWidth="*">

                        <DataGrid.Columns>

                            <DataGridTextColumn Header="ФИО"
                                                Binding="{Binding FullName}"
                                                Width="*" />

                            <DataGridTextColumn Header="Телефон"
                                                Binding="{Binding Phone}"
                                                Width="140" />

                            <DataGridTextColumn Header="Email"
                                                Binding="{Binding Email}"
                                                Width="180" />

                            <DataGridTemplateColumn Header=""
                                                    Width="60">

                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <Button Content="✕"
                                                Width="40"
                                                Height="24"
                                                Command="{Binding DataContext.RemoveClientCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}"
                                                CommandParameter="{Binding}" />
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>

                            </DataGridTemplateColumn>

                        </DataGrid.Columns>
                    </DataGrid>
                </Grid>
            </TabItem>

            <!-- ПОДРЯДЧИКИ -->
            <TabItem Header="Подрядчики" PreviewMouseLeftButtonDown="OnContractorsTabSelected">
                <Grid Margin="12">

                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto" />
                        <RowDefinition Height="*" />
                    </Grid.RowDefinitions>

                    <StackPanel Orientation="Horizontal"
                                Margin="0,0,0,8">

                        <TextBox materialDesign:HintAssist.Hint="Поиск человека"
                                 Text="{Binding ContractorSearchText, UpdateSourceTrigger=PropertyChanged}"
                                 Width="180"
                                 Margin="0,0,6,0"
                                 KeyDown="OnContractorSearchKeyDown" />

                        <TextBox materialDesign:HintAssist.Hint="Услуга"
                                 Text="{Binding ContractorService, UpdateSourceTrigger=PropertyChanged}"
                                 Width="100"
                                 Margin="0,0,6,0" />

                        <TextBox materialDesign:HintAssist.Hint="Стоимость"
                                 Text="{Binding ContractorCost, UpdateSourceTrigger=PropertyChanged}"
                                 Width="90"
                                 Margin="0,0,6,0" />

                        <Button Content="Найти"
                                Command="{Binding SearchContractorsCommand}"
                                Style="{StaticResource MaterialDesignFlatButton}" />
                    </StackPanel>

                    <ListBox Grid.Row="0"
                             ItemsSource="{Binding ContractorSearchResults}"
                             Visibility="{Binding ContractorSearchResults.Count, Converter={StaticResource BoolToVisibilityConverter}}"
                             MaxHeight="120"
                             Margin="0,0,0,8">

                        <ListBox.ItemTemplate>
                            <DataTemplate>
                                <Grid>
                                    <TextBlock Text="{Binding FullName}" />

                                    <Button Content="Добавить"
                                            HorizontalAlignment="Right"
                                            Command="{Binding DataContext.AddContractorCommand, RelativeSource={RelativeSource AncestorType=ListBox}}"
                                            CommandParameter="{Binding}" />
                                </Grid>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>

                    <DataGrid Grid.Row="1"
                              ItemsSource="{Binding Contractors}"
                              AutoGenerateColumns="False"
                              IsReadOnly="True"
                              CanUserAddRows="False"
                              ColumnWidth="*">

                        <DataGrid.Columns>

                            <DataGridTextColumn Header="ФИО"
                                                Binding="{Binding FullName}"
                                                Width="*" />

                            <DataGridTextColumn Header="Услуга"
                                                Binding="{Binding Service}"
                                                Width="160" />

                            <DataGridTextColumn Header="Стоимость"
                                                Binding="{Binding Cost, StringFormat='{}{0:N0} ₽'}"
                                                Width="120" />

                            <DataGridTemplateColumn Header=""
                                                    Width="60">

                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <Button Content="✕"
                                                Width="40"
                                                Height="24"
                                                Command="{Binding DataContext.RemoveContractorCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}"
                                                CommandParameter="{Binding}" />
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>

                            </DataGridTemplateColumn>

                        </DataGrid.Columns>
                    </DataGrid>
                </Grid>
            </TabItem>


            <!-- ГОСТИ -->
            <!-- ГОСТИ -->
            <TabItem Header="Гости" PreviewMouseLeftButtonDown="OnGuestsTabSelected">
                <Grid Margin="12">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto" />
                        <RowDefinition Height="*" />
                        <RowDefinition Height="Auto" />
                    </Grid.RowDefinitions>

                    <StackPanel Orientation="Horizontal" Margin="0,0,0,8">
                        <TextBox materialDesign:HintAssist.Hint="Поиск человека"
                     Text="{Binding GuestSearchText, UpdateSourceTrigger=PropertyChanged}"
                     Width="250" Margin="0,0,8,0"
                     KeyDown="OnGuestSearchKeyDown" />
                        <Button Content="Найти" Command="{Binding SearchGuestsCommand}"
                    Style="{StaticResource MaterialDesignFlatButton}" />
                    </StackPanel>

                    <ListBox Grid.Row="0" ItemsSource="{Binding GuestSearchResults}"
                 Visibility="{Binding GuestSearchResults.Count, Converter={StaticResource BoolToVisibilityConverter}}"
                 MaxHeight="120" Margin="0,0,0,8">
                        <ListBox.ItemTemplate>
                            <DataTemplate>
                                <Grid>
                                    <TextBlock Text="{Binding FullName}" />
                                    <Button Content="Добавить" HorizontalAlignment="Right"
                                Command="{Binding DataContext.AddGuestCommand, RelativeSource={RelativeSource AncestorType=ListBox}}"
                                CommandParameter="{Binding}" />
                                </Grid>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>

                    <DataGrid Grid.Row="1" ItemsSource="{Binding Guests}" AutoGenerateColumns="False"
                              CanUserAddRows="False"
                              ColumnWidth="*">
                        <DataGrid.Columns>
                            <DataGridTextColumn Header="ФИО" Binding="{Binding FullName}" Width="*" IsReadOnly="True" />
                            <DataGridTextColumn Header="Телефон" Binding="{Binding Phone}" Width="120" IsReadOnly="True" />
                            <DataGridTextColumn Header="Приглашение" Binding="{Binding InvitationStatus, UpdateSourceTrigger=PropertyChanged}" Width="110" />
                            <DataGridTextColumn Header="Диета" Binding="{Binding DietaryRestrictions, UpdateSourceTrigger=PropertyChanged}" Width="120" />
                            <DataGridCheckBoxColumn Header="Трансфер" Binding="{Binding TransferNeeded, UpdateSourceTrigger=PropertyChanged}" Width="70" />
                            <DataGridCheckBoxColumn Header="Проживание" Binding="{Binding AccommodationNeeded, UpdateSourceTrigger=PropertyChanged}" Width="80" />
                            <DataGridTextColumn Header="Стол" Binding="{Binding TableNumber, UpdateSourceTrigger=PropertyChanged}" Width="60" />
                            <DataGridTemplateColumn Header="" Width="60">
                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <Button Content="✕" Width="40" Height="24"
                                    Command="{Binding DataContext.RemoveGuestCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}"
                                    CommandParameter="{Binding}" />
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>
                            </DataGridTemplateColumn>
                        </DataGrid.Columns>
                    </DataGrid>

                    <StackPanel Grid.Row="2" Orientation="Horizontal" Margin="0,8,0,0">
                        <Button Content="Сохранить изменения"
        Command="{Binding SaveGuestsCommand}"
        Style="{StaticResource MaterialDesignRaisedButton}" />
                    </StackPanel>
                </Grid>
            </TabItem>

            <!-- ПЛОЩАДКА -->
            <TabItem Header="Площадка" PreviewMouseLeftButtonDown="OnVenuesTabSelected">
                <Grid Margin="12">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto" />
                        <RowDefinition Height="*" />
                    </Grid.RowDefinitions>

                    <!-- Поиск и добавление -->
                    <StackPanel Orientation="Horizontal" Margin="0,0,0,8">
                        <TextBox materialDesign:HintAssist.Hint="Поиск площадки"
                                 Text="{Binding VenueSearchText, UpdateSourceTrigger=PropertyChanged}"
                                 Width="200" Margin="0,0,8,0"
                                 KeyDown="OnVenueSearchKeyDown" />
                        <TextBox materialDesign:HintAssist.Hint="Аренда"
                                 Text="{Binding NewVenueRentalCost, UpdateSourceTrigger=PropertyChanged}"
                                 Width="100" Margin="0,0,6,0" />
                        <TextBox materialDesign:HintAssist.Hint="Депозит"
                                 Text="{Binding NewVenueDeposit, UpdateSourceTrigger=PropertyChanged}"
                                 Width="100" Margin="0,0,6,0" />
                        <DatePicker SelectedDate="{Binding NewVenueEventDate}" Width="120" Margin="0,0,6,0" />
                        <Button Content="Найти" Command="{Binding SearchVenuesCommand}"
                                Style="{StaticResource MaterialDesignFlatButton}" />
                    </StackPanel>

                    <!-- Результаты поиска -->
                    <ListBox Grid.Row="0" ItemsSource="{Binding VenueSearchResults}"
                             Visibility="{Binding VenueSearchResults.Count, Converter={StaticResource BoolToVisibilityConverter}}"
                             MaxHeight="120" Margin="0,0,0,8">
                        <ListBox.ItemTemplate>
                            <DataTemplate>
                                <Grid>
                                    <StackPanel>
                                        <TextBlock Text="{Binding Name}" FontWeight="Bold" />
                                        <TextBlock Text="{Binding City}" />
                                    </StackPanel>
                                    <Button Content="Добавить" HorizontalAlignment="Right"
                                            Command="{Binding DataContext.AddVenueCommand, RelativeSource={RelativeSource AncestorType=ListBox}}"
                                            CommandParameter="{Binding}" />
                                </Grid>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>

                    <!-- Список площадок -->
                    <DataGrid Grid.Row="1" ItemsSource="{Binding Venues}" AutoGenerateColumns="False" IsReadOnly="True"
                              CanUserAddRows="False"
                              ColumnWidth="*">
                        <DataGrid.Columns>
                            <DataGridTextColumn Header="Название" Binding="{Binding VenueName}" Width="*" />
                            <DataGridTextColumn Header="Адрес" Binding="{Binding Address}" Width="*" />
                            <DataGridTextColumn Header="Город" Binding="{Binding City}" Width="100" />
                            <DataGridTextColumn Header="Аренда" Binding="{Binding RentalCost, StringFormat='{}{0:N0} ₽'}" Width="110" />
                            <DataGridTextColumn Header="Депозит" Binding="{Binding DepositAmount, StringFormat='{}{0:N0} ₽'}" Width="110" />
                            <DataGridTextColumn Header="Статус" Binding="{Binding Status}" Width="100" />
                            <DataGridTextColumn Header="Дата" Binding="{Binding EventDate, StringFormat='{}{0:dd.MM.yyyy}'}" Width="100" />
                            <DataGridTemplateColumn Header="" Width="60">
                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <Button Content="✕" Width="40" Height="24"
                                                Command="{Binding DataContext.RemoveVenueCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}"
                                                CommandParameter="{Binding}" />
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>
                            </DataGridTemplateColumn>
                        </DataGrid.Columns>
                    </DataGrid>
                </Grid>
            </TabItem>

            <!-- ТАЙМЛАЙН -->
            <TabItem Header="Таймлайн" PreviewMouseLeftButtonDown="OnTimelineTabSelected">
                <Grid Margin="12">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto" />
                        <RowDefinition Height="*" />
                    </Grid.RowDefinitions>

                    <!-- Панель добавления -->
                    <Border Background="{DynamicResource MaterialDesignPaper}" Padding="12" CornerRadius="4" Margin="0,0,0,12">
                        <StackPanel>
                            <TextBlock Text="Новое событие" Style="{StaticResource MaterialDesignSubtitle1TextBlock}" Margin="0,0,0,8"/>
                            <WrapPanel>
                                <DatePicker SelectedDate="{Binding NewEventStartTime}" 
                                            materialDesign:HintAssist.Hint="Дата начала" Width="120" Margin="0,0,8,8"/>

                                <TextBox Text="{Binding NewEventStartTime, StringFormat='{}{0:HH:mm}'}" 
                                         materialDesign:HintAssist.Hint="Время нач." Width="80" Margin="0,0,8,8"/>

                                <TextBox Text="{Binding NewEventEndTime, StringFormat='{}{0:HH:mm}'}" 
                                         materialDesign:HintAssist.Hint="Время кон." Width="80" Margin="0,0,8,8"/>

                                <TextBox Text="{Binding NewEventDescription, UpdateSourceTrigger=PropertyChanged}" 
                                         materialDesign:HintAssist.Hint="Описание" Width="180" Margin="0,0,8,8"/>

                                <TextBox Text="{Binding NewEventLocation, UpdateSourceTrigger=PropertyChanged}" 
                                         materialDesign:HintAssist.Hint="Локация" Width="140" Margin="0,0,8,8"/>

                                <ComboBox ItemsSource="{Binding Managers}" SelectedItem="{Binding NewEventResponsible}"
                                          DisplayMemberPath="Person.FullName" Width="140" Margin="0,0,8,8"
                                          materialDesign:HintAssist.Hint="Ответственный"/>

                                <TextBox Text="{Binding NewEventNotes, UpdateSourceTrigger=PropertyChanged}" 
                                         materialDesign:HintAssist.Hint="Заметки" Width="160" Margin="0,0,8,8"/>

                                <Button Content="Добавить" Command="{Binding AddTimelineEventCommand}"
                                        Style="{StaticResource MaterialDesignRaisedButton}" VerticalAlignment="Center"/>
                            </WrapPanel>
                        </StackPanel>
                    </Border>

                    <!-- Таблица -->
                    <DataGrid Grid.Row="1" ItemsSource="{Binding TimelineEvents}" AutoGenerateColumns="False" IsReadOnly="True"
                              CanUserAddRows="False"
                              ColumnWidth="*">
                        <DataGrid.Columns>
                            <DataGridTextColumn Header="Начало" Binding="{Binding StartTime, StringFormat='{}{0:dd.MM HH:mm}'}" Width="110" />
                            <DataGridTextColumn Header="Конец" Binding="{Binding EndTime, StringFormat='{}{0:dd.MM HH:mm}'}" Width="110" />
                            <DataGridTextColumn Header="Описание" Binding="{Binding Description}" Width="*" />
                            <DataGridTextColumn Header="Локация" Binding="{Binding Location}" Width="140" />
                            <DataGridTextColumn Header="Ответственный" Binding="{Binding ResponsiblePerson}" Width="140" />
                            <DataGridTextColumn Header="Заметки" Binding="{Binding Notes}" Width="160" />
                            <DataGridTemplateColumn Header="" Width="60">
                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <Button Content="✕" Width="40" Height="24"
                                                Command="{Binding DataContext.DeleteTimelineEventCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}"
                                                CommandParameter="{Binding}" />
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>
                            </DataGridTemplateColumn>
                        </DataGrid.Columns>
                    </DataGrid>
                </Grid>
            </TabItem>

            <!-- ФИНАНСЫ -->
            <TabItem Header="Финансы" PreviewMouseLeftButtonDown="OnFinanceTabSelected">
                <Grid Margin="12">

                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto" />
                        <RowDefinition Height="*" />
                    </Grid.RowDefinitions>

                    <Border Background="{DynamicResource MaterialDesignPaper}"
                            Padding="12"
                            CornerRadius="4"
                            Margin="0,0,0,12">

                        <WrapPanel>

                            <TextBlock Text="{Binding FinanceSummary.BudgetTotal, StringFormat='Бюджет: {0:N0} ₽'}"
                                       Margin="0,0,20,0"
                                       FontWeight="Bold" />

                            <TextBlock Text="{Binding FinanceSummary.PaidByClient, StringFormat='Оплачено клиентом: {0:N0} ₽'}"
                                       Margin="0,0,20,0" />

                            <TextBlock Text="{Binding FinanceSummary.TotalActual, StringFormat='Расходы: {0:N0} ₽'}"
                                       Margin="0,0,20,0" />

                            <TextBlock Text="{Binding FinanceSummary.Remainder, StringFormat='Остаток: {0:N0} ₽'}"
                                       Margin="0,0,20,0"
                                       Foreground="Green" />

                            <TextBlock Text="{Binding FinanceSummary.Profit, StringFormat='Прибыль: {0:N0} ₽'}"
                                       FontWeight="Bold"
                                       Foreground="DarkGreen" />

                        </WrapPanel>
                    </Border>

                    <DataGrid Grid.Row="1"
                              ItemsSource="{Binding FinanceTransactions}"
                              AutoGenerateColumns="False"
                              IsReadOnly="True"
                              ColumnWidth="*">

                        <DataGrid.Columns>

                            <DataGridTextColumn Header="Тип"
                                                Binding="{Binding Type}"
                                                Width="140" />

                            <DataGridTextColumn Header="Номер"
                                                Binding="{Binding Number}"
                                                Width="120" />

                            <DataGridTextColumn Header="Контрагент"
                                                Binding="{Binding Counterparty}"
                                                Width="*" />

                            <DataGridTextColumn Header="Сумма"
                                                Binding="{Binding Amount, StringFormat='{}{0:N0} ₽'}"
                                                Width="120" />

                            <DataGridTextColumn Header="Статус"
                                                Binding="{Binding Status}"
                                                Width="100" />

                            <DataGridTextColumn Header="Дата"
                                                Binding="{Binding Date, StringFormat='{}{0:dd.MM.yyyy}'}"
                                                Width="100" />

                        </DataGrid.Columns>
                    </DataGrid>
                </Grid>
            </TabItem>

        </TabControl>

    </Grid>

</UserControl>
```

---

## FILE 96: ProjectDetailsView.xaml.cs

<a id='projectdetailsviewxamlcs'></a>

```csharp
﻿using System.Windows.Controls;
using System.Windows.Input;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Projects;

public partial class ProjectDetailsView : UserControl
{
    public ProjectDetailsView()
    {
        InitializeComponent();
    }

    private void OnClientsTabSelected(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectDetailsViewModel vm)
            vm.LoadClientsCommand.Execute(null);
    }

    private void OnContractorsTabSelected(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectDetailsViewModel vm)
            vm.LoadContractorsCommand.Execute(null);
    }

    private void OnFinanceTabSelected(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectDetailsViewModel vm)
            vm.LoadFinanceCommand.Execute(null);
    }

    private void OnClientSearchKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && DataContext is ProjectDetailsViewModel vm)
            vm.SearchClientsCommand.Execute(null);
    }

    private void OnContractorSearchKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && DataContext is ProjectDetailsViewModel vm)
            vm.SearchContractorsCommand.Execute(null);
    }
    private void OnGuestsTabSelected(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectDetailsViewModel vm)
            vm.LoadGuestsCommand.Execute(null);
    }

    private void OnGuestSearchKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && DataContext is ProjectDetailsViewModel vm)
            vm.SearchGuestsCommand.Execute(null);
    }
    private void OnVenuesTabSelected(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectDetailsViewModel vm)
            vm.LoadVenuesCommand.Execute(null);
    }

    private void OnTimelineTabSelected(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectDetailsViewModel vm)
            vm.LoadTimelineCommand.Execute(null);
    }

    private void OnVenueSearchKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && DataContext is ProjectDetailsViewModel vm)
            vm.SearchVenuesCommand.Execute(null);
    }
}
```

---

## FILE 97: ProjectsView.xaml

<a id='projectsviewxaml'></a>

```xml
﻿<UserControl x:Class="WeddingAgency.Views.Projects.ProjectsView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes">

    <UserControl.Resources>

        <Style x:Key="StatusCell" TargetType="DataGridCell">
            <Setter Property="Foreground"
                    Value="{Binding Status, Converter={StaticResource StatusToColorConverter}}" />
            <Setter Property="FontWeight" Value="SemiBold" />
        </Style>

    </UserControl.Resources>

    <Grid Margin="20">

        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <!-- TOP BAR -->
        <DockPanel Grid.Row="0"
                   Margin="0,0,0,16">

            <Button DockPanel.Dock="Right"
                    Content="Добавить"
                    Command="{Binding AddProjectCommand}"
                    Style="{StaticResource MaterialDesignRaisedButton}"
                    Padding="18,8"/>

            <TextBox Width="280"
                     Margin="0,0,12,0"
                     Text="{Binding SearchText, UpdateSourceTrigger=PropertyChanged}"
                     materialDesign:HintAssist.Hint="Поиск по номеру или городу"/>
        </DockPanel>

        <!-- TABLE -->
        <Border Grid.Row="1"
                Background="{DynamicResource MaterialDesignPaper}"
                CornerRadius="6"
                Padding="8">

            <DataGrid ItemsSource="{Binding Projects}"
                      SelectedItem="{Binding SelectedProject}"
                      AutoGenerateColumns="False"
                      IsReadOnly="True"
                      SelectionMode="Single"
                      HeadersVisibility="Column"
                      GridLinesVisibility="Horizontal"
                      BorderThickness="0">

                <DataGrid.Columns>

                    <DataGridTextColumn Header="Номер"
                                        Binding="{Binding ProjectNumber}"
                                        Width="160"/>

                    <DataGridTextColumn Header="Дата"
                                        Binding="{Binding WeddingDate, StringFormat='{}{0:dd.MM.yyyy}'}"
                                        Width="120"/>

                    <DataGridTextColumn Header="Город"
                                        Binding="{Binding LocationCity}"
                                        Width="140"/>

                    <DataGridTextColumn Header="Бюджет"
                                        Binding="{Binding BudgetTotal, StringFormat='{}{0:N0} ₽'}"
                                        Width="140"/>

                    <DataGridTextColumn Header="Гостей"
                                        Binding="{Binding GuestCountMin}"
                                        Width="90"/>

                    <DataGridTextColumn Header="Статус"
                                        Binding="{Binding Status}"
                                        Width="120"
                                        CellStyle="{StaticResource StatusCell}"/>

                    <DataGridTextColumn Header="Менеджер"
                                        Binding="{Binding ManagerName}"
                                        Width="180"/>

                    <DataGridTextColumn Header="Клиенты"
                                        Binding="{Binding ClientsDisplay}"
                                        Width="*"/>

                </DataGrid.Columns>

            </DataGrid>

        </Border>

        <!-- ACTIONS -->
        <StackPanel Grid.Row="2"
                    Orientation="Horizontal"
                    Margin="0,12,0,0">

            <Button Content="Открыть"
                    Command="{Binding OpenProjectCommand}"
                    IsEnabled="{Binding SelectedProject, Converter={StaticResource IsNotNullConverter}}"
                    Style="{StaticResource MaterialDesignRaisedButton}"
                    Margin="0,0,8,0"/>

            <Button Content="Закрыть проект"
                    Command="{Binding CloseProjectCommand}"
                    IsEnabled="{Binding CanCloseProject}"
                    Style="{StaticResource MaterialDesignFlatButton}"/>

        </StackPanel>

    </Grid>

</UserControl>
```

---

## FILE 98: ProjectsView.xaml.cs

<a id='projectsviewxamlcs'></a>

```csharp
﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Projects;

public partial class ProjectsView : UserControl
{
    public ProjectsView()
    {
        InitializeComponent();
        Loaded += async (_, _) =>
        {
            if (DataContext is ProjectsViewModel vm)
                await vm.InitializeAsync();
        };
    }

    private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ProjectsViewModel vm && vm.SelectedProject != null)
        {
            MessageBox.Show($"Открыть проект {vm.SelectedProject.ProjectNumber}", "Проект");
        }
    }
}
```

---

## FILE 99: VenuesView.xaml

<a id='venuesviewxaml'></a>

```xml
﻿<UserControl x:Class="WeddingAgency.Views.Venues.VenuesView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Grid Margin="24">
        <TextBlock Text="Площадки"
                   Style="{StaticResource MaterialDesignHeadline4TextBlock}"
                   VerticalAlignment="Center"
                   HorizontalAlignment="Center"
                   Opacity="0.5" />
    </Grid>

</UserControl>
```

---

## FILE 100: VenuesView.xaml.cs

<a id='venuesviewxamlcs'></a>

```csharp
﻿using System.Windows.Controls;

namespace WeddingAgency.Views.Venues;

public partial class VenuesView : UserControl
{
    public VenuesView()
    {
        InitializeComponent();
    }
}
```

---

## FILE 101: AdminWindow.xaml

<a id='adminwindowxaml'></a>

```xml
﻿<Window x:Class="WeddingAgency.Views.Windows.AdminWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
        xmlns:sys="clr-namespace:System;assembly=mscorlib"
        Title="Панель администратора"
        Height="600"
        Width="900"
        WindowStartupLocation="CenterScreen"
        Background="{DynamicResource MaterialDesignBackground}">

    <Window.Resources>
        <x:Array x:Key="FilterOptions" Type="sys:String">
            <sys:String>Все</sys:String>
            <sys:String>Активные</sys:String>
            <sys:String>Заблокированные</sys:String>
            <sys:String>Админы</sys:String>
        </x:Array>
    </Window.Resources>

    <Grid Margin="20">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>

        <!-- Заголовок -->
        <TextBlock Text="{Binding Title}"
                   Style="{StaticResource MaterialDesignHeadline5TextBlock}"
                   Margin="0,0,0,16" />

        <!-- Панель создания пользователя -->
        <Border Grid.Row="1"
                Background="{DynamicResource MaterialDesignPaper}"
                Padding="16"
                Margin="0,0,0,16"
                CornerRadius="4">
            <StackPanel>
                <TextBlock Text="Новый пользователь"
                           Style="{StaticResource MaterialDesignSubtitle1TextBlock}"
                           Margin="0,0,0,8" />
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="Auto" />
                        <ColumnDefinition Width="Auto" />
                    </Grid.ColumnDefinitions>
                    <TextBox Grid.Column="0"
                             materialDesign:HintAssist.Hint="Логин"
                             Text="{Binding NewLogin, UpdateSourceTrigger=PropertyChanged}"
                             Margin="0,0,8,0" />
                    <TextBox Grid.Column="1"
                             materialDesign:HintAssist.Hint="ФИО"
                             Text="{Binding NewFullName, UpdateSourceTrigger=PropertyChanged}"
                             Margin="0,0,8,0" />
                    <CheckBox Grid.Column="2"
                              Content="Админ"
                              IsChecked="{Binding NewIsAdmin}"
                              VerticalAlignment="Center"
                              Margin="0,0,8,0" />
                    <Button Grid.Column="3"
                            Content="Создать"
                            Command="{Binding CreateUserCommand}"
                            Style="{StaticResource MaterialDesignRaisedButton}" />
                </Grid>
            </StackPanel>
        </Border>

        <!-- Таблица пользователей и фильтры -->
        <Grid Grid.Row="2">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto" />
                <RowDefinition Height="*" />
            </Grid.RowDefinitions>

            <!-- Поиск и фильтр -->
            <StackPanel Orientation="Horizontal"
                        Margin="0,0,0,8">
                <TextBox materialDesign:HintAssist.Hint="Поиск по логину или ФИО"
                         Text="{Binding SearchText, UpdateSourceTrigger=PropertyChanged}"
                         Width="250"
                         Margin="0,0,16,0" />
                <ComboBox ItemsSource="{StaticResource FilterOptions}"
                          SelectedItem="{Binding FilterStatus}"
                          Width="150" />
            </StackPanel>

            <!-- DataGrid -->
            <DataGrid Grid.Row="1"
                      ItemsSource="{Binding Users}"
                      SelectedItem="{Binding SelectedUser}"
                      AutoGenerateColumns="False"
                      IsReadOnly="True"
                      SelectionMode="Single">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Логин" Binding="{Binding Login}" Width="*" />
                    <DataGridTextColumn Header="ФИО" Binding="{Binding Person.FullName}" Width="*" />
                    <DataGridCheckBoxColumn Header="Активен" Binding="{Binding IsActive}" Width="80" />
                    <DataGridCheckBoxColumn Header="Админ" Binding="{Binding IsAdmin}" Width="80" />
                    <DataGridTextColumn Header="Последний вход"
                                        Binding="{Binding LastLogin, StringFormat='{}{0:dd.MM.yyyy HH:mm}'}"
                                        Width="140" />
                </DataGrid.Columns>
            </DataGrid>

            <!-- Кнопки действий -->
            <StackPanel Grid.Row="1"
                        Orientation="Horizontal"
                        VerticalAlignment="Bottom"
                        Margin="0,8,0,0">
                <Button Content="Сбросить пароль"
                        Command="{Binding ResetPasswordCommand}"
                        IsEnabled="{Binding SelectedUser, Converter={StaticResource IsNotNullConverter}}"
                        Style="{StaticResource MaterialDesignFlatButton}"
                        Margin="0,0,8,0" />
                <Button Content="{Binding ToggleButtonText}"
                        Command="{Binding ToggleActiveCommand}"
                        IsEnabled="{Binding SelectedUser, Converter={StaticResource IsNotNullConverter}}"
                        Style="{StaticResource MaterialDesignFlatButton}" />
            </StackPanel>
        </Grid>
    </Grid>
</Window>
```

---

## FILE 102: AdminWindow.xaml.cs

<a id='adminwindowxamlcs'></a>

```csharp
﻿using System.Windows;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Windows;

public partial class AdminWindow : Window
{
    private readonly AdminUsersViewModel _viewModel;

    public AdminWindow(AdminUsersViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;

        _viewModel.InfoMessage += (_, msg) =>
            MessageBox.Show(msg, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

        _viewModel.ErrorMessage += (_, msg) =>
            MessageBox.Show(msg, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        Loaded += async (_, _) => await _viewModel.InitializeAsync();
    }
}
```

---

## FILE 103: ChangePasswordWindow.xaml

<a id='changepasswordwindowxaml'></a>

```xml
﻿<Window x:Class="WeddingAgency.Views.Windows.ChangePasswordWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
        Title="Смена пароля"
        Height="300"
        Width="400"
        WindowStartupLocation="CenterScreen"
        ResizeMode="NoResize"
        Background="{DynamicResource MaterialDesignBackground}">

    <Grid Margin="30">
        <StackPanel VerticalAlignment="Center">

            <TextBlock Text="Смена пароля"
                       Style="{StaticResource MaterialDesignHeadline5TextBlock}"
                       HorizontalAlignment="Center"
                       Margin="0,0,0,24" />

            <PasswordBox x:Name="NewPasswordBox"
                         materialDesign:HintAssist.Hint="Новый пароль"
                         Margin="0,0,0,12" />

            <PasswordBox x:Name="ConfirmPasswordBox"
                         materialDesign:HintAssist.Hint="Подтверждение пароля"
                         Margin="0,0,0,8" />

            <TextBlock Text="{Binding ErrorMessage}"
                       Foreground="{DynamicResource MaterialDesignErrorBrush}"
                       HorizontalAlignment="Center"
                       Margin="0,4"
                       Visibility="{Binding ErrorMessage, Converter={StaticResource StringToVisibilityConverter}}"
                       Style="{StaticResource MaterialDesignCaptionTextBlock}" />

            <Button Content="Сохранить"
                    IsDefault="True"
                    Click="SaveButton_Click"
                    IsEnabled="{Binding IsBusy, Converter={StaticResource InvertBoolConverter}}"
                    Style="{StaticResource MaterialDesignRaisedButton}"
                    Margin="0,16,0,0"
                    HorizontalAlignment="Stretch" />

        </StackPanel>
    </Grid>
</Window>
```

---

## FILE 104: ChangePasswordWindow.xaml.cs

<a id='changepasswordwindowxamlcs'></a>

```csharp
﻿using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WeddingAgency.Services;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Windows;

public partial class ChangePasswordWindow : Window
{
    private readonly ChangePasswordViewModel _viewModel;
    private readonly IServiceProvider _serviceProvider;

    public ChangePasswordWindow(ChangePasswordViewModel viewModel, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _viewModel = viewModel;
        _serviceProvider = serviceProvider;
        DataContext = _viewModel;

        _viewModel.PasswordChanged += OnPasswordChanged;

        Closed += (_, _) =>
        {
            _viewModel.PasswordChanged -= OnPasswordChanged;
        };
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.NewPassword = NewPasswordBox.Password;
        _viewModel.ConfirmPassword = ConfirmPasswordBox.Password;
        await _viewModel.ChangePasswordCommand.ExecuteAsync(null);
    }

    private void OnPasswordChanged()
    {
        var authService = _serviceProvider.GetRequiredService<IAuthService>();
        if (authService.CurrentUser?.IsAdmin == true)
        {
            var adminWindow = _serviceProvider.GetRequiredService<AdminWindow>();
            adminWindow.Show();
        }
        else
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
        Close();
    }
}
```

---

## FILE 105: CreateProjectWindow.xaml

<a id='createprojectwindowxaml'></a>

```xml
﻿<Window x:Class="WeddingAgency.Views.Windows.CreateProjectWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
        Title="Новый проект"
        Height="450"
        Width="500"
        WindowStartupLocation="CenterScreen"
        ResizeMode="NoResize"
        Background="{DynamicResource MaterialDesignBackground}">

    <Grid Margin="24">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>

        <TextBlock Text="Новый проект"
                   Style="{StaticResource MaterialDesignHeadline5TextBlock}"
                   Margin="0,0,0,20" />

        <StackPanel Grid.Row="1">
            <TextBox Text="{Binding ProjectNumber, UpdateSourceTrigger=PropertyChanged}"
                     materialDesign:HintAssist.Hint="Номер проекта"
                     Margin="0,0,0,12" />

            <DatePicker SelectedDate="{Binding WeddingDate}"
                        materialDesign:HintAssist.Hint="Дата свадьбы"
                        Margin="0,0,0,12" />

            <TextBox Text="{Binding LocationCity, UpdateSourceTrigger=PropertyChanged}"
                     materialDesign:HintAssist.Hint="Город"
                     Margin="0,0,0,12" />

            <TextBox Text="{Binding BudgetTotal, UpdateSourceTrigger=PropertyChanged}"
                     materialDesign:HintAssist.Hint="Бюджет"
                     Margin="0,0,0,12" />

            <TextBox Text="{Binding GuestCount, UpdateSourceTrigger=PropertyChanged}"
                     materialDesign:HintAssist.Hint="Количество гостей"
                     Margin="0,0,0,12" />

            <ComboBox ItemsSource="{Binding Managers}"
                      SelectedItem="{Binding SelectedManager}"
                      DisplayMemberPath="Person.FullName"
                      materialDesign:HintAssist.Hint="Менеджер"
                      Margin="0,0,0,12" />

            <ComboBox Text="{Binding Status}">
                <ComboBoxItem>Новый</ComboBoxItem>
                <ComboBoxItem>Открыт</ComboBoxItem>
            </ComboBox>
        </StackPanel>

        <StackPanel Grid.Row="2"
                    Orientation="Horizontal"
                    HorizontalAlignment="Right"
                    Margin="0,20,0,0">
            <Button Content="Отмена"
                    Command="{Binding CancelCommand}"
                    Style="{StaticResource MaterialDesignFlatButton}"
                    Margin="0,0,8,0" />
            <Button Content="Создать"
                    Command="{Binding CreateCommand}"
                    Style="{StaticResource MaterialDesignRaisedButton}" />
        </StackPanel>
    </Grid>
</Window>
```

---

## FILE 106: CreateProjectWindow.xaml.cs

<a id='createprojectwindowxamlcs'></a>

```csharp
﻿using System.Windows;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Windows;

public partial class CreateProjectWindow : Window
{
    private readonly CreateProjectViewModel _viewModel;

    public CreateProjectWindow(CreateProjectViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;

        _viewModel.ProjectCreated += () =>
        {
            DialogResult = true;
            Close();
        };

        _viewModel.Cancelled += () =>
        {
            DialogResult = false;
            Close();
        };
    }
}
```

---

## FILE 107: LoginWindow.xaml

<a id='loginwindowxaml'></a>

```xml
﻿<Window x:Class="WeddingAgency.Views.Windows.LoginWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
        xmlns:fa="http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp"
        Title="Wedding Agency - Вход"
        Height="350"
        Width="400"
        WindowStartupLocation="CenterScreen"
        ResizeMode="NoResize"
        Background="{DynamicResource MaterialDesignBackground}">

    <Grid Margin="30">
        <StackPanel VerticalAlignment="Center">

            <fa:IconBlock Icon="Gem"
                          Width="40"
                          Height="40"
                          Foreground="{DynamicResource PrimaryHueMidBrush}"
                          HorizontalAlignment="Center"
                          Margin="0,0,0,16" />

            <TextBlock Text="Вход в систему"
                       Style="{StaticResource MaterialDesignHeadline5TextBlock}"
                       HorizontalAlignment="Center"
                       Margin="0,0,0,24" />

            <TextBox materialDesign:HintAssist.Hint="Логин"
                     Text="{Binding Login, UpdateSourceTrigger=PropertyChanged}"
                     Margin="0,0,0,12" />

            <PasswordBox x:Name="PasswordBox"
                         materialDesign:HintAssist.Hint="Пароль"
                         Margin="0,0,0,8" />

            <TextBlock Text="{Binding ErrorMessage}"
                       Foreground="{DynamicResource MaterialDesignErrorBrush}"
                       HorizontalAlignment="Center"
                       Margin="0,4"
                       Visibility="{Binding ErrorMessage, Converter={StaticResource StringToVisibilityConverter}}"
                       Style="{StaticResource MaterialDesignCaptionTextBlock}" />

            <Button Content="Войти"
                    IsDefault="True"
                    Click="LoginButton_Click"
                    IsEnabled="{Binding IsBusy, Converter={StaticResource InvertBoolConverter}}"
                    Style="{StaticResource MaterialDesignRaisedButton}"
                    Margin="0,16,0,0"
                    HorizontalAlignment="Stretch" />

        </StackPanel>
    </Grid>
</Window>
```

---

## FILE 108: LoginWindow.xaml.cs

<a id='loginwindowxamlcs'></a>

```csharp
﻿using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Windows;

public partial class LoginWindow : Window
{
    private readonly LoginViewModel _viewModel;
    private readonly IServiceProvider _serviceProvider;

    public LoginWindow(LoginViewModel viewModel, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _viewModel = viewModel;
        _serviceProvider = serviceProvider;

        DataContext = _viewModel;

        _viewModel.LoginSucceeded += OnLoginSucceeded;
        _viewModel.ChangePasswordRequired += OnChangePasswordRequired;
        _viewModel.AdminLoginSucceeded += OnAdminLoginSucceeded;

        Closed += (_, _) =>
        {
            _viewModel.LoginSucceeded -= OnLoginSucceeded;
            _viewModel.ChangePasswordRequired -= OnChangePasswordRequired;
            _viewModel.AdminLoginSucceeded -= OnAdminLoginSucceeded;
        };
    }

    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        await _viewModel.LoginAsync(PasswordBox.Password);
    }

    private void OnLoginSucceeded()
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        Close();
    }

    private void OnChangePasswordRequired()
    {
        var changePasswordWindow =
            _serviceProvider.GetRequiredService<ChangePasswordWindow>();

        changePasswordWindow.Show();
        Close();
    }

    private void OnAdminLoginSucceeded()
    {
        var adminWindow =
            _serviceProvider.GetRequiredService<AdminWindow>();

        adminWindow.Show();
        Close();
    }
}
```

---

## FILE 109: MainWindow.xaml

<a id='mainwindowxaml'></a>

```xml
﻿<Window x:Class="WeddingAgency.Views.Windows.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
        xmlns:fa="http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp"
        Title="Wedding Agency"
        Height="700"
        Width="1200"
        MinHeight="500"
        MinWidth="900"
        WindowStartupLocation="CenterScreen"
        Background="{DynamicResource MaterialDesignBackground}">

    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="240" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>

        <!-- SIDEBAR -->
        <Border Grid.Column="0"
                Background="{DynamicResource MaterialDesignPaper}"
                BorderBrush="{DynamicResource MaterialDesignDivider}"
                BorderThickness="0,0,1,0"
                Padding="0">

            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto" />
                    <RowDefinition Height="*" />
                    <RowDefinition Height="Auto" />
                </Grid.RowDefinitions>

                <!-- Заголовок приложения -->
                <StackPanel Margin="20,24,20,16">
                    <fa:IconBlock Icon="Gem"
                                  Width="32"
                                  Height="32"
                                  Foreground="{DynamicResource PrimaryHueMidBrush}"
                                  HorizontalAlignment="Center" />
                    <TextBlock Text="WEDDING AGENCY"
                               Style="{StaticResource MaterialDesignSubtitle1TextBlock}"
                               HorizontalAlignment="Center"
                               Margin="0,8,0,0" />
                </StackPanel>

                <!-- Кнопки навигации -->
                <StackPanel Grid.Row="1" Margin="12,8">

                    <Button Style="{StaticResource SidebarButton}"
                            Command="{Binding NavigateCommand}"
                            CommandParameter="Dashboard">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="32" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <fa:IconBlock Grid.Column="0" Icon="ChartBar" Width="16" Height="16"
                                          VerticalAlignment="Center"
                                          Foreground="{DynamicResource PrimaryHueMidBrush}" />
                            <TextBlock Grid.Column="1" Text="Дашборд" VerticalAlignment="Center" Margin="12,0,0,0" />
                        </Grid>
                    </Button>

                    <Button Style="{StaticResource SidebarButton}"
                            Command="{Binding NavigateCommand}"
                            CommandParameter="People">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="32" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <fa:IconBlock Grid.Column="0" Icon="Users" Width="16" Height="16"
                                          VerticalAlignment="Center"
                                          Foreground="{DynamicResource PrimaryHueMidBrush}" />
                            <TextBlock Grid.Column="1" Text="Люди" VerticalAlignment="Center" Margin="12,0,0,0" />
                        </Grid>
                    </Button>

                    <Button Style="{StaticResource SidebarButton}"
                            Command="{Binding NavigateCommand}"
                            CommandParameter="Projects">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="32" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <fa:IconBlock Grid.Column="0" Icon="FolderOpen" Width="16" Height="16"
                                          VerticalAlignment="Center"
                                          Foreground="{DynamicResource PrimaryHueMidBrush}" />
                            <TextBlock Grid.Column="1" Text="Проекты" VerticalAlignment="Center" Margin="12,0,0,0" />
                        </Grid>
                    </Button>

                    <Button Style="{StaticResource SidebarButton}"
                            Command="{Binding NavigateCommand}"
                            CommandParameter="Venues">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="32" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <fa:IconBlock Grid.Column="0" Icon="MapMarkerAlt" Width="16" Height="16"
                                          VerticalAlignment="Center"
                                          Foreground="{DynamicResource PrimaryHueMidBrush}" />
                            <TextBlock Grid.Column="1" Text="Площадки" VerticalAlignment="Center" Margin="12,0,0,0" />
                        </Grid>
                    </Button>

                    <Button Style="{StaticResource SidebarButton}"
                            Command="{Binding NavigateCommand}"
                            CommandParameter="Finance">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="32" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <fa:IconBlock Grid.Column="0" Icon="ChartLine" Width="16" Height="16"
                                          VerticalAlignment="Center"
                                          Foreground="{DynamicResource PrimaryHueMidBrush}" />
                            <TextBlock Grid.Column="1" Text="Финансы" VerticalAlignment="Center" Margin="12,0,0,0" />
                        </Grid>
                    </Button>

                    <Button Style="{StaticResource SidebarButton}"
                            Command="{Binding NavigateCommand}"
                            CommandParameter="Contractors">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="32" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <fa:IconBlock Grid.Column="0" Icon="Handshake" Width="16" Height="16"
                                          VerticalAlignment="Center"
                                          Foreground="{DynamicResource PrimaryHueMidBrush}" />
                            <TextBlock Grid.Column="1" Text="Подрядчики" VerticalAlignment="Center" Margin="12,0,0,0" />
                        </Grid>
                    </Button>

                </StackPanel>

                <!-- Кнопка выхода -->
                <Button Grid.Row="2"
                        Style="{StaticResource SidebarButton}"
                        Margin="12"
                        Command="{Binding LogoutCommand}">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="32" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <fa:IconBlock Grid.Column="0"
                                      Icon="SignOutAlt"
                                      Width="16"
                                      Height="16"
                                      VerticalAlignment="Center"
                                      Foreground="{DynamicResource PrimaryHueMidBrush}" />
                        <TextBlock Grid.Column="1"
                                   Text="Выйти"
                                   VerticalAlignment="Center"
                                   Margin="12,0,0,0" />
                    </Grid>
                </Button>
            </Grid>
        </Border>

        <!-- MAIN CONTENT -->
        <Border Grid.Column="1">
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto" />
                    <RowDefinition Height="*" />
                </Grid.RowDefinitions>

                <!-- HEADER -->
                <Border Grid.Row="0"
                        Style="{StaticResource HeaderBar}"
                        BorderBrush="{DynamicResource MaterialDesignDivider}"
                        BorderThickness="0,0,0,1">
                    <TextBlock Text="{Binding Title}"
                               Style="{StaticResource MaterialDesignHeadline5TextBlock}" />
                </Border>

                <!-- CONTENT AREA -->
                <ContentControl Grid.Row="1"
                                Content="{Binding CurrentViewModel}" />
            </Grid>
        </Border>
    </Grid>
</Window>
```

---

## FILE 110: MainWindow.xaml.cs

<a id='mainwindowxamlcs'></a>

```csharp
﻿using System.Windows;
using WeddingAgency.ViewModels;

namespace WeddingAgency.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
```

---

## FILE 111: WeddingAgency.csproj

<a id='weddingagencycsproj'></a>

```xml
﻿<Project Sdk="Microsoft.NET.Sdk">

	<PropertyGroup>
		<OutputType>WinExe</OutputType>
		<TargetFramework>net8.0-windows</TargetFramework>
		<Nullable>enable</Nullable>
		<ImplicitUsings>enable</ImplicitUsings>
		<UseWPF>true</UseWPF>
	</PropertyGroup>

	<ItemGroup>
		<PackageReference Include="BCrypt.Net-Next" Version="4.2.0" />
		<PackageReference Include="CommunityToolkit.Mvvm" Version="8.4.0" />
		<PackageReference Include="FontAwesome.Sharp" Version="6.6.0" />
		<PackageReference Include="MaterialDesignColors" Version="5.2.1" />
		<PackageReference Include="MaterialDesignThemes" Version="5.2.1" />
		<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0">
			<PrivateAssets>all</PrivateAssets>
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
		</PackageReference>
		<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0">
			<PrivateAssets>all</PrivateAssets>
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
		</PackageReference>
		<PackageReference Include="Microsoft.Extensions.Configuration" Version="8.0.0" />
		<PackageReference Include="Microsoft.Extensions.Configuration.Binder" Version="8.0.0" />
		<PackageReference Include="Microsoft.Extensions.Configuration.FileExtensions" Version="8.0.0" />
		<PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="8.0.0" />
		<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
		<PackageReference Include="Microsoft.Extensions.Hosting" Version="8.0.0" />
	</ItemGroup>

	<ItemGroup>
		<Folder Include="Core\Enums\" />
		<Folder Include="Core\Interfaces\" />
		<Folder Include="Core\DTOs\" />
		<Folder Include="Core\Services\" />
		<Folder Include="Data\Context\" />
		<Folder Include="Data\Repositories\" />
		<Folder Include="Data\Configurations\" />
		<Folder Include="Seed\" />
		<Folder Include="Views\Controls\" />
		<Folder Include="Views\Dialogs\" />
	</ItemGroup>

	<ItemGroup>
		<Compile Update="Services\INavigationAware.cs">
		  <Generator>MSBuild:Compile</Generator>
		</Compile>
		<Compile Update="Services\IProjectOverviewService.cs">
		  <Generator>MSBuild:Compile</Generator>
		</Compile>
		<Compile Update="Services\IUserManagementService.cs">
			<Generator>MSBuild:Compile</Generator>
		</Compile>
		<Compile Update="ViewModels\ProjectDetails\ProjectHeaderModel.cs">
		  <Generator>MSBuild:Compile</Generator>
		</Compile>
	</ItemGroup>

	<ItemGroup>
		<None Update="appsettings.json">
			<CopyToOutputDirectory>Always</CopyToOutputDirectory>
		</None>
	</ItemGroup>
	
</Project>
```

---

