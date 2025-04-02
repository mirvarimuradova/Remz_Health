using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class WorkDay
{
    public int Id { get; set; }

    public string? WeekDay { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public virtual ICollection<WorkDayDoctor> WorkDayDoctors { get; set; } = new List<WorkDayDoctor>();
}
