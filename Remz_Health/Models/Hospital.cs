using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class Hospital
{
    public int Id { get; set; }

    public string? HospitalName { get; set; }

    public string? AboutText { get; set; }

    public int? HospitalCode { get; set; }

    public string? Branch { get; set; }

    public string? Location { get; set; }

    public string? ImagePath { get; set; }

    public string? ImageName { get; set; }

    public int? SubscriptionId { get; set; }

    public int? PhoneId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public virtual ICollection<HospitalPatient> HospitalPatients { get; set; } = new List<HospitalPatient>();

    public virtual Phone? Phone { get; set; }

    public virtual Subscription? Subscription { get; set; }
}
