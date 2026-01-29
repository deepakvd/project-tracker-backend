# API Endpoints Documentation

This document provides an overview of the available API endpoints, 
their methods, parameters, and expected responses.

## Admin Endpoints
- POST /api/admin/create-project-owner
	- Description: Create a new ProjectOwner user (Admin only).
	- Request Body:
		- username (string, required)
		- password (string, required)
		- email (string, required)
	- Responses:
		- 201 Created: ProjectOwner successfully created.
		- 400 Bad Request: Invalid input data.
		- 403 Forbidden: User does not have Admin role.
		- 401 Unauthorized: User not authenticated.

- PUT /api/admin/promote-user/{userId}
	- Description: Promote a User to ProjectOwner role (Admin only).
	- Path Parameters:
		- userId (int, required)
	- Request Body:
		- newRole (string, required) - one of: ProjectOwner
	- Responses:
		- 200 OK: User successfully promoted.
		- 400 Bad Request: Invalid role or user.
		- 403 Forbidden: User does not have Admin role.
		- 401 Unauthorized: User not authenticated.

## User Endpoints
- POST /api/users/register
	- Description: Register a new user (default role: User).
	- Request Body:
		- username (string, required)
		- password (string, required)
		- email (string, required)
	- Responses:
		- 201 Created: User successfully registered.
		- 400 Bad Request: Invalid input data.

- POST /api/users/login
	- Description: Authenticate a user and return a JWT token.
	- Request Body:
		- username (string, required)
		- password (string, required)
	- Responses:
		- 200 OK: Returns JWT token.
		- 401 Unauthorized: Invalid credentials.

- GET /api/users/me
	- Description: Get current authenticated user's profile.
	- Responses:
		- 200 OK: Returns user profile with roles.
		- 401 Unauthorized: User not authenticated.

## Project Endpoints
- POST /api/projects
	- Description: Create a new project (ProjectOwner only).
	- Request Body:
		- name (string, required)
		- description (string, optional)
	- Responses:
		- 201 Created: Project successfully created.
		- 400 Bad Request: Invalid input data.
		- 403 Forbidden: User does not have permission to create projects.
		- 401 Unauthorized: User not authenticated.

- GET /api/projects
	- Description: Retrieve a paginated list of projects accessible to the user.
	- Query Parameters:
		- page (int, optional, default: 1)
		- pageSize (int, optional, default: 20, max: 100)
		- searchTerm (string, optional) - Search by project name or description
	- Responses:
		- 200 OK: Returns paginated list with metadata (totalCount, totalPages, currentPage).
		- 401 Unauthorized: User not authenticated.

- GET /api/projects/{projectId}
	- Description: Retrieve details of a specific project.
	- Path Parameters:
		- projectId (int, required)
	- Responses:
		- 200 OK: Returns project details.
		- 404 Not Found: Project does not exist.
		- 401 Unauthorized: User not authenticated.
		- 403 Forbidden: User does not have permission to view the project.

- PUT /api/projects/{projectId}
	- Description: Update an existing project (ProjectOwner only).
	- Path Parameters:
		- projectId (int, required)
	- Request Body:
		- name (string, optional)
		- description (string, optional)
	- Responses:
		- 200 OK: Project successfully updated.
		- 400 Bad Request: Invalid input data.
		- 403 Forbidden: User does not have permission to update the project.
		- 401 Unauthorized: User not authenticated.
		- 404 Not Found: Project does not exist.

- DELETE /api/projects/{projectId}
	- Description: Delete a project (ProjectOwner only).
	- Path Parameters:
		- projectId (int, required)
	- Responses:
		- 204 No Content: Project successfully deleted.
		- 403 Forbidden: User does not have permission to delete the project.
		- 401 Unauthorized: User not authenticated.
		- 404 Not Found: Project does not exist.

- POST /api/projects/{projectId}/users
	- Description: Assign a ProjectAdmin or User to a project (ProjectOwner only).
	- Path Parameters:
		- projectId (int, required)
	- Request Body:
		- userId (int, required)
		- projectRole (string, required) - one of: ProjectAdmin, User
	- Responses:
		- 200 OK: User successfully assigned to the project.
		- 400 Bad Request: Invalid input data or user already assigned.
		- 403 Forbidden: User does not have permission to assign users to the project.
		- 401 Unauthorized: User not authenticated.
		- 404 Not Found: Project or user does not exist.

- DELETE /api/projects/{projectId}/users/{userId}
	- Description: Remove a ProjectAdmin or User from a project (ProjectOwner only).
	- Path Parameters:
		- projectId (int, required)
		- userId (int, required)
	- Responses:
		- 204 No Content: User successfully removed from the project.
		- 403 Forbidden: User does not have permission to remove users from the project.
		- 401 Unauthorized: User not authenticated.
		- 404 Not Found: Project or user assignment does not exist.

- GET /api/projects/{projectId}/users
	- Description: Retrieve a list of users assigned to a project.
	- Path Parameters:
		- projectId (int, required)
	- Query Parameters:
		- projectRole (string, optional) - Filter by role: ProjectAdmin, User
	- Responses:
		- 200 OK: Returns a list of users with their project roles.
		- 404 Not Found: Project does not exist.
		- 401 Unauthorized: User not authenticated.
		- 403 Forbidden: User does not have permission to view project users.

- PUT /api/projects/{projectId}/users/{userId}/role
	- Description: Change the role of a user within a project (ProjectOwner only).
	- Path Parameters:
		- projectId (int, required)
		- userId (int, required)
	- Request Body:
		- newProjectRole (string, required) - one of: ProjectAdmin, User
	- Responses:
		- 200 OK: User role successfully changed.
		- 400 Bad Request: Invalid input data.
		- 403 Forbidden: User does not have permission to change user roles in the project.
		- 401 Unauthorized: User not authenticated.
		- 404 Not Found: Project or user assignment does not exist.

## Task Endpoints

- POST /api/projects/{projectId}/tasks
	- Description: Create a new task within a project (ProjectAdmin only).
	- Path Parameters:
		- projectId (int, required)
	- Request Body:
		- title (string, required)
		- description (string, optional)
		- assignedUserId (int, optional)
		- status (string, optional, default: ToDo) - one of: ToDo, InProgress, Done
		- dueDate (datetime, optional)
	- Responses:
		- 201 Created: Task successfully created with task details.
		- 400 Bad Request: Invalid input data.
		- 403 Forbidden: User does not have permission to create tasks in the project.
		- 401 Unauthorized: User not authenticated.
		- 404 Not Found: Project does not exist.

- GET /api/projects/{projectId}/tasks
	- Description: Retrieve a paginated and filtered list of tasks within a project.
	- Path Parameters:
		- projectId (int, required)
	- Query Parameters:
		- page (int, optional, default: 1)
		- pageSize (int, optional, default: 20, max: 100)
		- status (string, optional) - Filter by: ToDo, InProgress, Done
		- assignedUserId (int, optional) - Filter by assigned user
		- sortBy (string, optional, default: createdDate) - Sort by: createdDate, dueDate, title
		- sortOrder (string, optional, default: desc) - asc or desc
	- Responses:
		- 200 OK: Returns paginated list of tasks with metadata.
		- 401 Unauthorized: User not authenticated.
		- 403 Forbidden: User does not have permission to view tasks in the project.
		- 404 Not Found: Project does not exist.

- GET /api/tasks/my-tasks
	- Description: Retrieve all tasks assigned to the current user across all projects.
	- Query Parameters:
		- page (int, optional, default: 1)
		- pageSize (int, optional, default: 20, max: 100)
		- status (string, optional) - Filter by: ToDo, InProgress, Done
	- Responses:
		- 200 OK: Returns paginated list of user's tasks.
		- 401 Unauthorized: User not authenticated.

- GET /api/projects/{projectId}/tasks/{taskId}
	- Description: Retrieve details of a specific task.
	- Path Parameters:
		- projectId (int, required)
		- taskId (int, required)
	- Responses:
		- 200 OK: Returns task details.
		- 401 Unauthorized: User not authenticated.
		- 403 Forbidden: User does not have permission to view the task.
		- 404 Not Found: Project or task does not exist.

- PUT /api/projects/{projectId}/tasks/{taskId}
	- Description: Update an existing task (ProjectAdmin or assigned User can update status).
	- Path Parameters:
		- projectId (int, required)
		- taskId (int, required)
	- Request Body:
		- title (string, optional) - ProjectAdmin only
		- description (string, optional) - ProjectAdmin only
		- assignedUserId (int, optional) - ProjectAdmin only
		- status (string, optional) - one of: ToDo, InProgress, Done
		- dueDate (datetime, optional) - ProjectAdmin only
	- Responses:
		- 200 OK: Task successfully updated.
		- 400 Bad Request: Invalid input data.
		- 403 Forbidden: User does not have permission to update the task.
		- 401 Unauthorized: User not authenticated.
		- 404 Not Found: Project or task does not exist.

- PUT /api/projects/{projectId}/tasks/{taskId}/assign
	- Description: Assign or reassign a task to a user (ProjectAdmin only).
	- Path Parameters:
		- projectId (int, required)
		- taskId (int, required)
	- Request Body:
		- assignedUserId (int, required) - Must be a user assigned to the project
	- Responses:
		- 200 OK: Task successfully assigned.
		- 400 Bad Request: User not part of the project.
		- 403 Forbidden: User does not have permission to assign tasks.
		- 401 Unauthorized: User not authenticated.
		- 404 Not Found: Project, task, or user does not exist.

- DELETE /api/projects/{projectId}/tasks/{taskId}
	- Description: Delete a task from a project (ProjectAdmin only).
	- Path Parameters:
		- projectId (int, required)
		- taskId (int, required)
	- Responses:
		- 204 No Content: Task successfully deleted.
		- 403 Forbidden: User does not have permission to delete the task.
		- 401 Unauthorized: User not authenticated.
		- 404 Not Found: Project or task does not exist.

## Attachment Endpoints

- POST /api/tasks/{taskId}/attachments
	- Description: Upload an attachment to a task (multipart/form-data).
	- Path Parameters:
		- taskId (int, required)
	- Request Body:
		- file (file, required) - Max size: 10MB, allowed types: pdf, doc, docx, txt, png, jpg, jpeg
		- description (string, optional)
	- Responses:
		- 201 Created: Attachment successfully uploaded with attachment URL.
		- 400 Bad Request: Invalid file type or size.
		- 403 Forbidden: User does not have permission to add attachments to the task.
		- 401 Unauthorized: User not authenticated.
		- 404 Not Found: Task does not exist.

- GET /api/tasks/{taskId}/attachments
	- Description: Retrieve list of attachments for a task.
	- Path Parameters:
		- taskId (int, required)
	- Responses:
		- 200 OK: Returns list of attachments with metadata (filename, size, uploadDate, downloadUrl).
		- 401 Unauthorized: User not authenticated.
		- 403 Forbidden: User does not have permission to view attachments on the task.
		- 404 Not Found: Task does not exist.

- GET /api/tasks/{taskId}/attachments/{attachmentId}/download
	- Description: Download a specific attachment (generates presigned URL or streams file).
	- Path Parameters:
		- taskId (int, required)
		- attachmentId (int, required)
	- Responses:
		- 200 OK: Returns file stream or redirect to presigned URL.
		- 401 Unauthorized: User not authenticated.
		- 403 Forbidden: User does not have permission to download the attachment.
		- 404 Not Found: Task or attachment does not exist.

- DELETE /api/tasks/{taskId}/attachments/{attachmentId}
	- Description: Delete an attachment from a task (ProjectAdmin or uploader only).
	- Path Parameters:
		- taskId (int, required)
		- attachmentId (int, required)
	- Responses:
		- 204 No Content: Attachment successfully deleted from storage and database.
		- 403 Forbidden: User does not have permission to delete the attachment.
		- 401 Unauthorized: User not authenticated.
		- 404 Not Found: Task or attachment does not exist.