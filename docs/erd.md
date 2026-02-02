Auditable
- CreatedAt
- UpdatedAt
- CreatedBy
- UpdatedBy

UserRole - Enum - Admin, User
ProjectRole - Enum - ProjectOwner, ProjectAdmin, ProjectMember
TaskStatus - Enum - New, Active, Closed

User : Auditable
- Id - long (PK)
- Username - string
- Email - string
- PasswordHash - string
- UserRole - Enum

ProjectUser : Auditable
- Id - long (PK)
- UserId - long (FK to User)
- ProjectId - long (FK to Project)
- ProjectRole (Enum)

Project : Auditable
- Id (PK)
- Name - string
- Description - string
- ProjectUsers - List<ProjectUser>

Task : Auditable
- Id - long (PK)
- ProjectId - long (FK to Project)
- Title - string
- Description - string
- Status - eTaskStatus
- AssigneeId - long (FK to User)
- Assignee - User
- DueDate - DateOnly?

Attachment : Auditable
- Id - long (PK)
- TaskId - long (FK to Task)
- FilePath - string
- FileName - string
- FileType - string
- FileSize - long


Relationships:

User 1 - ProjectUser M
Project 1 - ProjectUser M
Project 1 - Tasks M
Tasks 1 - Attachments M

Indexes:
- User: Username (Unique), Email (Unique)
- ProjectUser: UserId + ProjectId (Unique)
- Tasks: ProjectId + Assignee (Index)
- Attachments: TaskId (Index)


