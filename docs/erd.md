Auditable
- CreatedAt
- UpdatedAt
- CreatedBy
- UpdatedBy

UserRole - Enum - Admin, User
ProjectRole - Enum - ProjectOwner, ProjectAdmin, User
TaskStatus - Enum - New, InProgress, Done

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
- Assignee - long (FK to User)

Comment : Auditable
- Id - long (PK)
- TaskId - long (FK to Task)
- UserId - long (FK to User)
- Content - string

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
Tasks 1 - Comments M
Tasks 1 - Attachments M

Indexes:
- User: Username (Unique), Email (Unique)
- ProjectUser: UserId + ProjectId (Unique)
- Tasks: ProjectId + Assignee (Index)
- Comments: TaskId (Index)
- Attachments: TaskId (Index)


