using System;
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

            entity.HasIndex(e => e.PersonId, "UQ__users__543848DE5DC1FC61").IsUnique();

            entity.HasIndex(e => e.Login, "UQ__users__7838F272D17C6DD3").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");

            entity.Property(e => e.LastLogin)
                .HasColumnName("last_login");

            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");

            entity.Property(e => e.PersonId)
                .HasColumnName("person_id");

            entity.Property(e => e.IsAdmin)
                .HasDefaultValue(false)
                .HasColumnName("is_admin");

            entity.Property(e => e.MustChangePassword)
                .HasDefaultValue(false)
                .HasColumnName("must_change_password");

            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");

            entity.HasOne(d => d.Person)
                .WithOne(p => p.User)
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
