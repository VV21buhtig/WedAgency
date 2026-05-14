using System;
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
