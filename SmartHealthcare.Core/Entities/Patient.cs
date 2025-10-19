using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Core.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string MedicalHistory { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
