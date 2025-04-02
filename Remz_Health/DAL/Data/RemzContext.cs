using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Remz_Health.Models;

namespace Remz_Health.DAL.Data;

public partial class RemzContext : DbContext
{
    public RemzContext()
    {
    }

    public RemzContext(DbContextOptions<RemzContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminPermission> AdminPermissions { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<HospitalPatient> HospitalPatients { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientDoctor> PatientDoctors { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<WorkDay> WorkDays { get; set; }

    public virtual DbSet<WorkDayDoctor> WorkDayDoctors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder
        .UseSqlServer("Server =localhost; Database= Remz;Trusted_Connection = True; TrustServerCertificate=True;");


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        var configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //            .Build();

    //        string connectionString = configuration.GetConnectionString("SqlCon");
    //        Console.WriteLine($"Connection String: {connectionString}");
    //        optionsBuilder.UseSqlServer(connectionString);
    //    }
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin__3214EC273B887707");

            entity.ToTable("Admin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<AdminPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin_Pe__3214EC27BDC45A00");

            entity.ToTable("Admin_Permission");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminId).HasColumnName("Admin_ID");
            entity.Property(e => e.PermissionId).HasColumnName("Permission_ID");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdminPermissions)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__Admin_Per__Admin__4222D4EF");

            entity.HasOne(d => d.Permission).WithMany(p => p.AdminPermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__Admin_Per__Permi__412EB0B6");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC275AF86251");

            entity.ToTable("Appointment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");
            entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Appointme__Docto__5EBF139D");

            entity.HasOne(d => d.Hospital).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK__Appointme__Hospi__5FB337D6");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Appointme__Patie__5DCAEF64");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctor__3214EC274F5FE919");

            entity.ToTable("Doctor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fin)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("FIN");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");
            entity.Property(e => e.ImageName).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.PhoneId).HasColumnName("Phone_ID");
            entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.University)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Hospital).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK__Doctor__Hospital__59063A47");

            entity.HasOne(d => d.Phone).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.PhoneId)
                .HasConstraintName("FK__Doctor__Phone_ID__5AEE82B9");

            entity.HasOne(d => d.Speciality).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.SpecialityId)
                .HasConstraintName("FK__Doctor__Speciali__59FA5E80");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hospital__3214EC27C02B1D77");

            entity.ToTable("Hospital");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AboutText).HasColumnType("text");
            entity.Property(e => e.Branch)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HospitalName).HasMaxLength(255);
            entity.Property(e => e.ImageName).HasMaxLength(255);
            entity.Property(e => e.PhoneId).HasColumnName("Phone_ID");
            entity.Property(e => e.SubscriptionId).HasColumnName("Subscription_ID");

            entity.HasOne(d => d.Phone).WithMany(p => p.Hospitals)
                .HasForeignKey(d => d.PhoneId)
                .HasConstraintName("FK__Hospital__Phone___45F365D3");

            entity.HasOne(d => d.Subscription).WithMany(p => p.Hospitals)
                .HasForeignKey(d => d.SubscriptionId)
                .HasConstraintName("FK__Hospital__Subscr__44FF419A");
        });

        modelBuilder.Entity<HospitalPatient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hospital__3214EC279AEBBE3A");

            entity.ToTable("Hospital_Patient");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");

            entity.HasOne(d => d.Hospital).WithMany(p => p.HospitalPatients)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK__Hospital___Hospi__4BAC3F29");

            entity.HasOne(d => d.Patient).WithMany(p => p.HospitalPatients)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Hospital___Patie__4CA06362");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient__3214EC27BACE6CF6");

            entity.ToTable("Patient");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fin)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("FIN");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ImageName).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.PhoneId).HasColumnName("Phone_ID");
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Phone).WithMany(p => p.Patients)
                .HasForeignKey(d => d.PhoneId)
                .HasConstraintName("FK__Patient__Phone_I__48CFD27E");
        });

        modelBuilder.Entity<PatientDoctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC27B1FAD90E");

            entity.ToTable("Patient_Doctor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");

            entity.HasOne(d => d.Doctor).WithMany(p => p.PatientDoctors)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Patient_D__Docto__6754599E");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientDoctors)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Patient_D__Patie__66603565");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC2705C0691C");

            entity.ToTable("Permission");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Phone__3214EC2741D2C750");

            entity.ToTable("Phone");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rate__3214EC27A4545550");

            entity.ToTable("Rate");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            entity.Property(e => e.Rate1).HasColumnName("Rate");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Rates)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Rate__Doctor_ID__6383C8BA");

            entity.HasOne(d => d.Patient).WithMany(p => p.Rates)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Rate__Patient_ID__628FA481");
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Speciali__3214EC27B5E33EE7");

            entity.ToTable("Speciality");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SpecialityName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrip__3214EC2746D68D50");

            entity.ToTable("Subscription");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SubscriptionName).HasMaxLength(30);
        });

        modelBuilder.Entity<WorkDay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkDay__3214EC274A813A86");

            entity.ToTable("WorkDay");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.WeekDay)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WorkDayDoctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkDay___3214EC27402E3527");

            entity.ToTable("WorkDay_Doctor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");
            entity.Property(e => e.WorkDayId).HasColumnName("WorkDay_ID");

            entity.HasOne(d => d.Doctor).WithMany(p => p.WorkDayDoctors)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__WorkDay_D__Docto__6C190EBB");

            entity.HasOne(d => d.WorkDay).WithMany(p => p.WorkDayDoctors)
                .HasForeignKey(d => d.WorkDayId)
                .HasConstraintName("FK__WorkDay_D__WorkD__6D0D32F4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
