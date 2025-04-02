using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class HospitalPatient
{
    public int Id { get; set; }

    public int? HospitalId { get; set; }

    public int? PatientId { get; set; }

    public virtual Hospital? Hospital { get; set; }

    public virtual Patient? Patient { get; set; }
}
