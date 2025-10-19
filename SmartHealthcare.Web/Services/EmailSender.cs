using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Threading.Tasks;

namespace SmartHealthcare.Web.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // This is just for testing — prints emails in console output
            Console.WriteLine("==================================");
            Console.WriteLine($"Simulated Email To: {email}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {htmlMessage}");
            Console.WriteLine("==================================");
            return Task.CompletedTask;
        }
    }
}
