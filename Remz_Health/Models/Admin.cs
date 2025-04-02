using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<AdminPermission> AdminPermissions { get; set; } = new List<AdminPermission>();
}
