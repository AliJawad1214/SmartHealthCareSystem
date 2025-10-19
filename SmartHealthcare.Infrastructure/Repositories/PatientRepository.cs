using SmartHealthcare.Core.Entities;
using SmartHealthcare.Core.Interfaces;
using SmartHealthcare.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SmartHealthcare.Infrastructure.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Patient> GetPatientWithAppointmentsAsync(int patientId)
        {
            return await _context.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(p => p.Id == patientId);
        }
    }
}
