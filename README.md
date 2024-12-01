# CoreAPI_Machine_Test
This is a .NET Core API project that manages tasks with basic CRUD operations. The project allows you to create, read, update, and delete tasks with statuses like Pending, InProgress, and Completed.

## Steps to Run the Project Locally

1. **Clone the Repository**
   First, clone this repository to your local machine:
   Command:    git clone "https://github.com/Shubhamsawant3/CoreAPI_Machine_Test.git"
2. **Install Required NuGet Packages**
   Microsoft.EntityFrameworkCore.InMemory
   Swashbuckle.AspNetCore
   Serilog.AspNetCore
   Microsoft.EntityFrameworkCore.Tools

4. **Configure the Databse**
   "ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TaskDb;Trusted_Connection=True;"
}

5. **Run Migration:** (If you are trying to use Entity Framework Core)
  a. Open terminal
  b. Command:
       Add Migration: dotnet ef migrations add "Migration_Name"
       Update Database:  dotnet ef database update
       Build Project
       Run Project
*************************************************************************************************************************

**API Documentation**

**GET /api/tasks**
Retrieves a list of all tasks. You can filter tasks by status and dueDate using query parameters.
Query Parameters:
status (optional): The status of the task (e.g., "Pending", "InProgress", "Completed").
dueDate (optional): The due date for the task.
page (optional): The page number for pagination (default is 1).
pageSize (optional): The number of tasks per page (default is 10).

**GET /api/tasks/{id}**
Retrieves a task by its ID.
URL Parameters:
id (required): The ID of the task.

**POST /api/tasks**
Creates a new task. You must provide the task details in the request body.
{
  "title": "New Task",
  "description": "Task description",
  "status": 0,  // 0 = Pending, 1 = InProgress, 2 = Completed
  "dueDate": "2024-12-01T07:00:00"
}

**PUT /api/tasks/{id}**
Updates an existing task by its ID.
URL Parameters:
id (required): The ID of the task to update.
{
  "title": "Updated Task",
  "description": "Updated description",
  "status": 1,  // 0 = Pending, 1 = InProgress, 2 = Completed
  "dueDate": "2024-12-01T07:00:00"
}

**DELETE /api/tasks/{id}**
Deletes a task by its ID.
URL Parameters:
id (required): The ID of the task to delete.


**Validations & Features:**

Pagination: The GET /api/tasks endpoint supports pagination, allowing users to request tasks in pages with a defined size.

Task Status Enum: The API uses an enum (TaskStatus) for task statuses, which ensures that only valid statuses (0, 1, 2) are accepted for creating or updating tasks. When tasks are retrieved, the status is returned as a string ("Pending", "InProgress", or "Completed").

Input Validation: The API ensures that only valid task statuses are provided when creating or updating tasks. If an invalid status is given, a BadRequest response is returned with an appropriate error message.
