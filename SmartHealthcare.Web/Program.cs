using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using SmartHealthcare.Core.Entities;
using SmartHealthcare.Core.Interfaces;
using SmartHealthcare.Infrastructure.Data;
using SmartHealthcare.Infrastructure.Repositories;
using SmartHealthcare.Services.Implementations;
using SmartHealthcare.Services.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

// ✅ 1. Configure Database Connection (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// ✅ 2. Add Identity for Authentication & Roles
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// ✅ 3. Register Repositories (Data Layer)
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

// ✅ 4. Register Services (Business Logic Layer)
builder.Services.AddScoped<IPatientService, PatientService>();

// Register fake email sender for development
builder.Services.AddSingleton<IEmailSender, SmartHealthcare.Web.Services.EmailSender>();
// ✅ 5. Add Controllers + Views
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();


// ✅ 6. Build the app
var app = builder.Build();

// ✅ 7. Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ✅ 8. Add Authentication + Authorization
app.UseAuthentication();
app.UseAuthorization();

// ✅ 9. Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

// ✅ 10. Seed Roles and Default Admin
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    string[] roleNames = { "Admin", "Doctor", "Patient", "Staff" };
    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    // Seed default admin
    string adminEmail = "admin@healthcare.com";
    string adminPassword = "Admin@123";

    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var user = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FullName = "System Administrator",
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}

app.Run();
