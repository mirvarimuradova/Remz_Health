using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class Permission
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<AdminPermission> AdminPermissions { get; set; } = new List<AdminPermission>();
}
