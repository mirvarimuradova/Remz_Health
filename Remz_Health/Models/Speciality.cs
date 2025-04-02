using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class Speciality
{
    public int Id { get; set; }

    public string? SpecialityName { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
