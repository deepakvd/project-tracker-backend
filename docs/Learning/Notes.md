Backend Foundations – To Revisit Later
1️ Client–Server Architecture

What is a client?
What is a server?
What is an API?
Request → Response lifecycle
Stateless communication

2️ HTTP Basics

HTTP methods (GET, POST, PUT, DELETE)
Status codes (200, 201, 400, 401, 403, 404, 500)
Headers
JSON request/response structure

3️ Relational Database Fundamentals

Table
Primary Key
Foreign Key
Index
One-to-Many relationship
Many-to-Many relationship
ACID properties

4️ Authentication vs Authorization
Authentication (Who are you?)
Authorization (What can you access?)
JWT basics
Role-based access control

5️ Environment Variables
What are environment variables?
Why not hardcode secrets?
Dev vs Prod configuration

6️ Docker & Containers
Image vs Container
Port mapping
Environment variables in containers
Docker volumes (data persistence)
Container lifecycle (start, stop, remove)
WSL (Windows Subsystem for Linux)

What I Learned
WSL allows Linux to run inside Windows.
Docker containers are Linux-based.
WSL 2 provides a lightweight Linux kernel.
Docker uses WSL 2 backend on Windows.

Why It Matters
Containers are Linux-native.
Without WSL, Docker cannot properly run Linux containers on Windows.

Commands Used
wsl --install
wsl --status
wsl -l -v
Key Insight

WSL creates a small Linux environment inside Windows.
Docker runs containers inside that Linux layer.

2️ Docker Basics

What is Docker?
Docker is a platform to run applications inside containers.

What is an Image?
Blueprint/template.

Contains OS + software.
Example: postgres:15

Does NOT run by itself.

What is a Container?
Running instance of an image.

Like:
Image = Class
Container = Object

Important Commands
docker --version
docker ps
docker run
Key Insight

docker run:

Pulls image (if not present)
Creates container
Starts container
All in one command.

3️ Ports & Networking Basics

What is a Port?
A port is a gate through which applications communicate.

Example:
PostgreSQL → 5432
HTTP → 80
HTTPS → 443

What is Port Mapping?
-p 5432:5432

Format:
HOST_PORT : CONTAINER_PORT

Meaning:
My laptop’s port 5432 forwards to container’s port 5432.
Without this, external apps (DBeaver/API) cannot connect.

Key Insight
Port mapping exposes container services to host machine.

4️ Running PostgreSQL in Docker

Command Used
docker run --name postgres-dev -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=ProjectTrackerDb -p 5432:5432 -d postgres:15
What Each Part Means

--name postgres-dev → container name

-e KEY=VALUE → set environment variable

POSTGRES_USER → DB username

POSTGRES_PASSWORD → DB password

POSTGRES_DB → initial DB name

-p 5432:5432 → expose DB to localhost

-d → run in background

postgres:15 → official PostgreSQL image version 15

What Are Environment Variables?

They are configuration values passed to container at startup.

Example:

-e POSTGRES_USER=postgres

Means:
Create database user named postgres.

Key Insight

We did NOT install PostgreSQL on Windows.
We created a container that runs PostgreSQL.

5️⃣ Architecture Mental Model So Far
Windows
   ↓
WSL 2 (Linux layer)
   ↓
Docker Engine
   ↓
PostgreSQL Container
   ↓
Port 5432 exposed

DBeaver / API will connect to:

localhost:5432

6️ Why Docker Instead of Local Install?

Clean system
Easy reset
Production-like setup
Cloud-ready mindset
No OS-level dependency

7️ Important Concepts to Revisit Later

Container networking
Docker volumes (data persistence)
Difference between image vs container lifecycle
What happens when container is deleted
How PostgreSQL stores data inside container

Your Foundation Built Today

You now understand:

WSL
Docker image vs container
Port mapping
Environment variables
Running PostgreSQL without installing it


## Why Run Database in Docker? (Clear Answer)

## Core Reasons

* Same DB version for every developer
* Same configuration everywhere
* No “works on my machine” issues
* Easy setup (one command)
* Easy reset (delete container → fresh DB)
* Clean system (no OS-level installation)
* Production-like environment
* Automation-ready (CI/CD compatible)
* Portable across Windows/Mac/Linux
* Infrastructure becomes reproducible

---

#  Local Install vs Docker DB (Comparison)

| Aspect                | Local PostgreSQL Install | PostgreSQL in Docker        |
| --------------------- | ------------------------ | --------------------------- |
| Setup                 | Manual installation      | One command                 |
| Cleanup               | Uninstall required       | Delete container            |
| Version Control       | Hard to manage           | Specify exact image version |
| Team Consistency      | Risk of mismatch         | Same image for all          |
| OS Dependency         | Tied to OS               | OS independent              |
| Reproducibility       | Hard                     | Fully reproducible          |
| CI/CD Friendly        | No                       | Yes                         |
| Production Similarity | Low                      | High                        |

---

# Important Clarification

Running DB in Docker does NOT mean:

* Production DB must run in Docker.
* Cloud DB must run in Docker.

In production, usually:

* App → Docker container
* DB → Managed cloud service (Azure/GCP/AWS)

Docker DB is mainly for:

* Development
* Testing
* Automation
* Local environment parity

---

# One-Line Summary

We use Docker for DB to ensure **consistent, reproducible, and clean development environments** that match production behavior.


## Program.cs Structure


┌─────────────────────────────────────────────────────┐
│ PROGRAM.CS STRUCTURE                                │
├─────────────────────────────────────────────────────┤
│ 1. SERVICES (builder.Services.Add...)               │
│    ├─ Database                                      │
│    ├─ Identity & Authentication                     │
│    ├─ Authorization                                 │
│    ├─ Business Services (DI)                        │
│    ├─ Infrastructure (Storage, etc.)                │
│    └─ Web Features (Controllers, Swagger)           │
│                                                     │
│ 2. BUILD (var app = builder.Build())                │
│                                                     │
│ 3. MIDDLEWARE (app.Use...)                          │
│    ├─ Exception Handler                             │
│    ├─ HTTPS Redirect                                │
│    ├─ CORS                                          │
│    ├─ Routing                                       │
│    ├─ Authentication (WHO?)                         │
│    ├─ Authorization (WHAT?)                         │
│    └─ MapControllers                                │
│                                                     │
│ 4. RUN (app.Run())                                  │
└─────────────────────────────────────────────────────┘



sample Program.cs Code

var builder = WebApplication.CreateBuilder(args);

// ═══════════════════════════════════════════════════════════
// PHASE 1: SERVICES REGISTRATION (builder.Services.Add...)
// ═══════════════════════════════════════════════════════════
// Memory Trigger: "Database → Business Logic → Web Stuff"

// 1️ DATABASE (Foundation of the house)
builder.Services.AddDbContext<AppDbContext>(...);

// 2️ IDENTITY & AUTHENTICATION (Who can enter?)
builder.Services.AddIdentity<User, IdentityRole>(...);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(...);

// 3️ AUTHORIZATION (What can they do?)
builder.Services.AddAuthorization(options => { ... });

// 4️ BUSINESS SERVICES (Your app logic - DI)
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITaskService, TaskService>();
// ... other services

// 5️ INFRASTRUCTURE SERVICES (External integrations)
builder.Services.AddScoped<IStorageService, AzureBlobStorageService>();

// 6️ VALIDATION (Input checking)
builder.Services.AddFluentValidation(...);

// 7️ WEB API FEATURES (Controllers, JSON, etc.)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 8️ CORS (Cross-origin requests)
builder.Services.AddCors(...);

// 9️ LOGGING & MONITORING (Optional but useful)
builder.Services.AddLogging();

// ═══════════════════════════════════════════════════════════
// PHASE 2: BUILD THE APP
// ═══════════════════════════════════════════════════════════
var app = builder.Build();

// Optional: Database initialization/seeding
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync(); // Auto-apply migrations
    await DbInitializer.SeedAsync(dbContext); // Seed data
}

// ═══════════════════════════════════════════════════════════
// PHASE 3: MIDDLEWARE PIPELINE (app.Use...)
// ═══════════════════════════════════════════════════════════
// Memory Trigger: "Security First, Functionality Last"
// Order MATTERS! Requests flow top-to-bottom.

// 1️ DEVELOPMENT TOOLS (Dev only)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

// 2️ GLOBAL EXCEPTION HANDLER (Catch all errors)
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// 3️ HTTPS REDIRECTION (Force secure connections)
app.UseHttpsRedirection();

// 4️ CORS (Allow frontend to call API)
app.UseCors("AllowFrontend");

// 5️ ROUTING (Match URLs to controllers)
app.UseRouting();

// 6️ AUTHENTICATION (Who are you?)
app.UseAuthentication();

// 7️ AUTHORIZATION (What can you do?)
app.UseAuthorization();

// 8️ MAP ENDPOINTS (Execute controller actions)
app.MapControllers();

// ═══════════════════════════════════════════════════════════
// PHASE 4: RUN THE APP
// ═══════════════════════════════════════════════════════════
app.Run();

## EF CORE Packages 

## EF Core Mental Model

EF Core = ORM abstraction
Provider = Database-specific adapter
Tools = Migration support
Design = Design-time support

Only provider changes per database

| Purpose                | Package Name                          | Why Needed                                     | Changes Per DB? |
| ---------------------- | ------------------------------------- | ---------------------------------------------- | --------------- |
| EF Core ORM Engine     | Microsoft.EntityFrameworkCore         | Core ORM abstraction layer                     |  No            |
| PostgreSQL Provider    | Npgsql.EntityFrameworkCore.PostgreSQL | Allows EF Core to talk to PostgreSQL           |  Yes           |
| Migrations & CLI Tools | Microsoft.EntityFrameworkCore.Tools   | Enables Add-Migration & Update-Database        |  No            |
| Design-Time Support    | Microsoft.EntityFrameworkCore.Design  | Required for design-time services (migrations) |  No            |

| Database   | Provider Package                        |
| ---------- | --------------------------------------- |
| PostgreSQL | Npgsql.EntityFrameworkCore.PostgreSQL   |
| SQL Server | Microsoft.EntityFrameworkCore.SqlServer |
| MySQL      | Pomelo.EntityFrameworkCore.MySql        |
| SQLite     | Microsoft.EntityFrameworkCore.Sqlite    |
