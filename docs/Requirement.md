# Phase 1: Foundation + MVP (Deploy)

## Goal
Ship a functional, secure backend with the core user flows running in the cloud.

## Requirements + High-Level Design (HLD)
- User stories for registration/login, projects, tasks, attachments
- Role-based access (admin/user)
- ERD + system/component diagram
- Initial OpenAPI/Swagger spec

## User-Stories

1. As a User, I want to register/login so I can access the application.

2. Application supports roles: Admin, ProjectOwner, ProjectAdmin, User
   - Admin: Grants app access by promoting Users to ProjectOwner role.
   - ProjectOwner: Creates/deletes projects, assigns ProjectAdmins/Users to projects.
   - ProjectAdmin: Creates/updates/deletes tasks in project, assigns tasks to Users.
   - User: Views/updates status of own assigned tasks.

3. As a ProjectOwner, I want to create/list/update/delete projects and assign ProjectAdmins/Users to them.

4. As a ProjectAdmin, I want to create/list/update/delete tasks in a project and assign them to Users within the project.

5. As a User, I want to view all tasks assigned to me across projects and update their status.

6. As a User/ProjectAdmin, I want to add attachments to tasks and download them.

7. As a ProjectOwner/Admin, I want role-based access so Users can't delete projects or modify tasks they're not assigned to.

8. As an Admin, I want to manage user roles by promoting Users to ProjectOwner.

9. As a ProjectAdmin, I want to filter and search tasks by status, assigned user, and due date for better project management.

10. As any authenticated user, I want paginated lists of projects and tasks for better performance and usability.

## Data Model + Migrations
- Entities: User, Project, Task, Attachment, ProjectUser (junction table for project assignments)
- Enums: UserRole (Admin, User), ProjectRole (ProjectOwner,ProjectAdmin, User), TaskStatus (New, InProgress, Done)
- EF Core AppDbContext with proper relationships and indexes
- Initial migrations
- Seed test data (Admin user, sample ProjectOwner, projects, tasks)

## Core Backend Implementation
- CRUD for Projects and Tasks with pagination and filtering
- Task assignment endpoint with validation (user must be part of project)
- File attachments with cloud storage (Azure Blob Storage / AWS S3)
- Query parameter handling (pagination, filtering, sorting)
- Input validation with FluentValidation or Data Annotations
- Global exception handling middleware
- Response DTOs for clean API contracts

## AuthN/AuthZ
- JWT authentication with ASP.NET Core Identity
- Role-based authorization [Authorize(Roles = "Admin")]
- Resource-based authorization for project/task access
- Custom authorization handlers for complex permissions

## Docs + Testing
- Swagger/OpenAPI documentation with examples
- Unit tests for:
  - Task assignment business logic
  - Role-based authorization
  - Pagination/filtering logic
- Integration tests for critical endpoints

## Deployment
- Dockerize backend with multi-stage build
- Use environment variables for secrets (connection strings, JWT keys, storage credentials)
- Managed cloud DB (Azure SQL Database)
- Cloud storage for attachments (Azure Blob Storage) 
- Deploy to Azure App Service / Azure Container Apps
- CI/CD pipeline with GitHub Actions
- Validate end-to-end workflow live (registration - project creation - task management - file upload)

## Removed Features (Optimization)
- **Comments**: Removed to avoid redundant CRUD implementation. Focus learning on more valuable features.
  - If needed later, can be added in Phase 2 with real-time notifications for added value.

## Added Features (Learning Enhancement)
- **Pagination**: Industry-standard feature for all list endpoints
- **Filtering & Sorting**: Query parameters for tasks (status, assignedUser, dueDate)
- **User Promotion**: Admin can promote Users to ProjectOwner (role elevation pattern)
- **My Tasks Endpoint**: Users can see all their tasks across projects
- **File Download**: Proper file streaming or presigned URLs for attachments