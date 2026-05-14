using System;
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
