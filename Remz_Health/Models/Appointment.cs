using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public string? Status { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public int? HospitalId { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Hospital? Hospital { get; set; }

    public virtual Patient? Patient { get; set; }
}
