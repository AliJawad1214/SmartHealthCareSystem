# 🏥 Smart Healthcare Management System  
A full-stack ASP.NET Core MVC application designed to digitize hospital operations — from patient management and doctor scheduling to pharmacy, billing, and reports.

---

## 🌟 Overview  
The **Smart Healthcare Management System (SHMS)** is built using **ASP.NET Core MVC**, **Entity Framework Core**, and **Identity** for secure, role-based access.  
The system enables **Admins**, **Doctors**, **Staff**, and **Patients** to interact within a unified healthcare ecosystem.

---

## ⚙️ Tech Stack
- **Backend:** ASP.NET Core 9.0 (MVC)
- **Frontend:** Razor Views + Bootstrap 5
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Authentication:** ASP.NET Core Identity
- **Architecture:** N-tier (Web → Services → Repository → Core)
- **Tools:** AutoMapper, FluentValidation (planned)

---

## 🧱 Project Architecture
```
SmartHealthcare.sln
│
├── SmartHealthcare.Core        → Entities, DTOs, Interfaces
├── SmartHealthcare.Data        → EF Core DbContext, Repositories
├── SmartHealthcare.Services    → Business Logic Layer
└── SmartHealthcare.Web         → MVC Application (Controllers, Views, Identity)
```

---

## 🔐 Roles & Access Flow (Hybrid Model)
| Role | Created By | Access |
|------|-------------|--------|
| **Admin** | Seeded automatically | Full access to all modules |
| **Doctor** | Created by Admin | Access to appointments, reports, patient history |
| **Staff** | Created by Admin | Manage appointments, wards, basic operations |
| **Patient** | Self-register | Access to their dashboard after Admin assigns Patient role |

---

## 🧩 Current Progress — *Phase 1 Completed ✅*
**Deliverables:**
- ✅ Project setup with layered architecture  
- ✅ EF Core + SQL Server connection  
- ✅ ASP.NET Identity integrated  
- ✅ Default roles seeded (Admin, Doctor, Staff, Patient)  
- ✅ Hybrid role flow implemented  
- ✅ Role Management UI (Admin can assign/change user roles)  
- ✅ Role-based navigation (Admin vs others)

---

## 🧭 Smart Healthcare Management System — Development Roadmap

Below is a **phase-wise roadmap** breaking down the project into manageable milestones.  
Each phase builds upon the previous one, ensuring you always have a working version ready.

---

### 🏗️ PHASE 1 — Project Setup & Core Architecture
**Goal:** Establish the foundation and ensure scalable architecture.

**Tasks:**
- Create ASP.NET Core Web App (MVC or API-first approach)
- Setup Entity Framework Core with SQL Server
- Create Database Context and connection string
- Configure Identity for authentication (Users, Roles)
- Seed default roles: **Admin, Doctor, Staff, Patient**
- Configure AutoMapper and FluentValidation
- Setup role-based navigation and base layout

📘 **Deliverable:**  
✅ Working project with login/signup, role management, and database connection.

---

### 👥 PHASE 2 — User & Role Management
**Goal:** Implement secure user onboarding and admin role assignment.

**Tasks:**
- Admin can create or assign users to roles
- Profile management for each role
- Role-based dashboards
- Authorization setup with `[Authorize(Roles="...")]`

📘 **Deliverable:**  
✅ Multi-role system with role-specific dashboards.

---

### 🧑‍⚕️ PHASE 3 — Patient Management Module
**Goal:** Manage patients’ data, appointments, and reports.

**Tasks:**
- CRUD operations for patients
- Medical history & report uploads
- Appointment booking (basic)
- Patient onboarding workflow

📘 **Deliverable:**  
✅ Functional patient management with appointments.

---

### 🩺 PHASE 4 — Doctor & Staff Management
**Goal:** Manage hospital staff and scheduling.

**Tasks:**
- Doctor registration & specialization
- Scheduling (availability)
- Staff management
- Availability dashboard

📘 **Deliverable:**  
✅ Admin can manage doctors & staff; patients can view availability.

---

### 📅 PHASE 5 — Appointments & Operations
**Goal:** Appointment system + hospital operations.

**Tasks:**
- Booking, rescheduling, cancellation
- Operation theatre booking
- Bed/ward availability
- Duty roster

📘 **Deliverable:**  
✅ End-to-end appointment system connected to doctors and patients.

---

### 💊 PHASE 6 — Pharmacy & Inventory Management
**Goal:** Manage medicines and stock.

**Tasks:**
- Medicine CRUD
- Issue medicine & update stock
- Purchase orders & supplier management

📘 **Deliverable:**  
✅ Integrated pharmacy & inventory system.

---

### 💳 PHASE 7 — Billing & Insurance
**Goal:** Automate billing and integrate insurance.

**Tasks:**
- Auto-generate bills
- Payment tracking
- Insurance claim system
- Financial reporting

📘 **Deliverable:**  
✅ End-to-end billing & financial tracking module.

---

### 🧍‍♀️ PHASE 8 — Patient Portal
**Goal:** Frontend portal for patients.

**Tasks:**
- Dashboard with appointments, reports, bills
- Secure chat with doctor (SignalR)
- Health reminders & notifications

📘 **Deliverable:**  
✅ Complete self-service patient portal.

---

### ⚛️ PHASE 9 — Frontend Modernization (Optional)
**Goal:** Upgrade to modern UI using React or Blazor.

**Tasks:**
- Consume backend APIs
- Build reusable frontend components
- Create role-based dashboards

📘 **Deliverable:**  
✅ Modern frontend consuming backend APIs.

---

### 🚀 PHASE 10 — Testing, Deployment & Documentation
**Goal:** Final polish and public release.

**Tasks:**
- Unit & Integration Testing
- Azure/Render deployment
- Add screenshots & system diagram
- Final documentation

📘 **Deliverable:**  
✅ Publicly hosted, professional-grade system.

---

## 🧾 How to Run Locally
1. Clone the repository  
   ```bash
   git clone https://github.com/yourusername/SmartHealthcare.git
   ```
2. Open in **Visual Studio 2022**
3. Update your **connection string** in `appsettings.json`
4. Run the following commands in **Package Manager Console**:
   ```bash
   update-database
   ```
5. Press **F5** or **Run** to start the project.

6. Login As
   Email: admin@healthcare.com
   Password: Admin@123


---

## 🧑‍💻 Author
**Syed Ali Jawad** — Full Stack .NET Developer | Game Developer   
💼 Focus: ASP.NET Core, Identity, EF Core, MVC, and scalable backend systems.  

