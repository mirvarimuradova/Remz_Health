using Remz_Health.Models;

namespace Remz_Health.DAL.Interface
{
    public interface IPatientRepository
    {

        public void Addpatient(Patient patient);
        public void Updatepatient();
        public void Removepatient(Patient patient);
    }
}
