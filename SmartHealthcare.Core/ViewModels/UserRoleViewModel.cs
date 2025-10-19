using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Core.ViewModels
{
    // Used for displaying users with their roles on the Admin dashboard
    public class UserRoleViewModel
    {
        public string UserId { get; set; }      // Unique user ID (from Identity)
        public string Email { get; set; }       // User email
        public string FullName { get; set; }    // User’s full name (from ApplicationUser)
        public string Role { get; set; }        // Assigned role (Admin, Doctor, Patient, Staff)
    }

    // Used when assigning or changing a user’s role
    public class AssignRoleViewModel
    {
        public string UserId { get; set; }              // User ID
        public string FullName { get; set; }            // For display
        public string Email { get; set; }               // For display
        public string SelectedRole { get; set; }        // Role chosen by admin
        public IEnumerable<SelectListItem> Roles { get; set; } // Dropdown list
    }
}
