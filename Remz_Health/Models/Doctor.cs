using System;
using System.Collections.Generic;

namespace Remz_Health.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Fin { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? ImagePath { get; set; }

    public string? ImageName { get; set; }

    public DateTime? SignUpDate { get; set; }

    public string? University { get; set; }

    public int? Experience { get; set; }

    public double? AvgRate { get; set; }

    public int? HospitalId { get; set; }

    public int? SpecialityId { get; set; }

    public int? PhoneId { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Hospital? Hospital { get; set; }

    public virtual ICollection<PatientDoctor> PatientDoctors { get; set; } = new List<PatientDoctor>();

    public virtual Phone? Phone { get; set; }

    public virtual ICollection<Rate> Rates { get; set; } = new List<Rate>();

    public virtual Speciality? Speciality { get; set; }

    public virtual ICollection<WorkDayDoctor> WorkDayDoctors { get; set; } = new List<WorkDayDoctor>();
}
