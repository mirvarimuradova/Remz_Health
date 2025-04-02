using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class Phone
{
    public int Id { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
