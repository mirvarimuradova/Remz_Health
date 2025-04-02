using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Fin { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte[]? ImagePath { get; set; }

    public string? ImageName { get; set; }

    public DateTime? SignUpDate { get; set; }

    public int? PhoneId { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<HospitalPatient> HospitalPatients { get; set; } = new List<HospitalPatient>();

    public virtual ICollection<PatientDoctor> PatientDoctors { get; set; } = new List<PatientDoctor>();

    public virtual Phone? Phone { get; set; }

    public virtual ICollection<Rate> Rates { get; set; } = new List<Rate>();

  
}
