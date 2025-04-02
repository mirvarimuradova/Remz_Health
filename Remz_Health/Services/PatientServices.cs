using Microsoft.AspNetCore.Mvc;
using Remz_Health.DAL;
using Remz_Health.DAL.Interface;
using Remz_Health.DTOs;
using Remz_Health.Models;
using System.Text.RegularExpressions;

namespace Remz_Health.Services
{
    public class PatientServices
    {
        private PatientCreateDTO patientdto;
        private readonly IPatientRepository _patientRepository;



        public PatientServices(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public bool  AddPatient(PatientCreateDTO patientdto)
        {

            if (patientdto == null) return false;

            // Ad və soyad yoxlaması
            if (!Regex.IsMatch(patientdto.Name, "^[A-Za-zƏəİıÖöÜüĞğÇçŞş]{2,50}$") ||
                !Regex.IsMatch(patientdto.Surname, "^[A-Za-zƏəİıÖöÜüĞğÇçŞş]{2,50}$"))
            {
                return false;
            }

            // FIN yoxlaması
            if (!Regex.IsMatch(patientdto.FIN, "^[A-Z0-9]{7}$"))
            {
                return false;
            }

            // Email yoxlaması
            if (!Regex.IsMatch(patientdto.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false;
            }

            // Şifrə yoxlaması
            if (!Regex.IsMatch(patientdto.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
            {
                return false;
            }

            // Yeni patient yaradılır
            Patient patient = new Patient
            {
                Name = patientdto.Name,
                Surname = patientdto.Surname,
                Fin = patientdto.FIN,
                Email = patientdto.Email,
                Password = patientdto.Password,
                BirthDate = patientdto.Birthdate,
                Gender = patientdto.Gender
            };


            _patientRepository.Addpatient(patient);



            return true;
        }

        public bool DeletePatient()
        {


            return true;
        }
      
    }


}
