using System.Threading.Tasks;
using SmartHealthcare.Core.Entities;

namespace SmartHealthcare.Core.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient> GetPatientWithAppointmentsAsync(int patientId);
    }
}
