using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class AdminPermission
{
    public int Id { get; set; }

    public int? PermissionId { get; set; }

    public int? AdminId { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Permission? Permission { get; set; }
}
