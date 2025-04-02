using Remz_Health.DAL.Data;
using Remz_Health.DAL.Interface;
using Remz_Health.Models;
using System;

namespace Remz_Health.DAL
{
    public class PatientRepository: IPatientRepository
    {
        private readonly RemzContext _context;

        public PatientRepository(RemzContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Addpatient(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            _context.Patients.Add(patient);
            _context.SaveChanges();
        }
        public  void Removepatient(Patient patient) { 
        
            _context?.Patients.Remove(patient);
           _context?.SaveChangesAsync();
        }
       public  void Updatepatient()
        {


        }

      

       


    }

    
}
