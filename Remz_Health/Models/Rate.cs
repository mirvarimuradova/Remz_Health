using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class Rate
{
    public int Id { get; set; }

    public int? Rate1 { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }
}
