using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class WorkDayDoctor
{
    public int Id { get; set; }

    public int? DoctorId { get; set; }

    public int? WorkDayId { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual WorkDay? WorkDay { get; set; }
}
