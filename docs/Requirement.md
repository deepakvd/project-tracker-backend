# Phase 1: Foundation + MVP (Deploy)

## Goal
Ship a functional, secure backend with the core user flows running in the cloud.

## Requirements + High-Level Design (HLD)
- User stories for registration/login, projects, tasks, comments, attachments
- Role-based access (admin/manager/user)
- ERD + system/component diagram
- Initial OpenAPI/Swagger spec

## User-Stories

1. As a User, I want to register/login so I can access the application.

2. Application supports roles: Admin, ProjectOwner, ProjectAdmin, User
   - Admin: Grants app access to ProjectOwners.
   - ProjectOwner: Creates/deletes projects, assigns ProjectAdmins/Users.
   - ProjectAdmin: Creates/updates/deletes tasks in project, assigns Users.
   - User: Views/updates own tasks.

3. As a ProjectOwner, I want to create/list/update/delete projects and assign ProjectAdmins/Users.

4. As a ProjectAdmin, I want to create/list/update/delete tasks in a project and assign Users.

5. As a User, I want to view tasks assigned to me and update status.

6. As a User/ProjectAdmin, I want to add comments/attachments to tasks.

7. As a ProjectOwner/Admin, I want role-based access so Users can't delete projects.

8. As an Admin, I want to manage user roles for app access.

## Data Model + Migrations
- Entities: User, Project, Task, Comment, Attachment
- enum - UserRole, ProjectRole, TaskStatus
- EF Core AppDbContext
- Initial migrations
- Seed test data

## Core Backend Implementation
- CRUD for Projects and Tasks
- Basic task assignment
- Comments + file attachments
- Input validation
- Global exception handling/middleware

## AuthN/AuthZ
- JWT auth or ASP.NET Identity
- Role-based endpoint restrictions

## Docs + Testing
- Minimal Swagger docs
- Unit tests for core logic (example: task assignment)

## Deployment
- Dockerize backend
- Use environment variables for secrets
- Managed cloud DB (Azure SQL or similar)
- Deploy to Azure App Service/Render/etc
- Validate end-to-end workflow live