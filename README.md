# EmployeeAttendanceWebApi

A Employee System built with .Net and SQL Server (SSMS)

## What it does
-Manages Employees (CREATE, READ, UPDATE, DELETE)

-Check in and out

-Check if attendance has been done
## Technologies Used
- .Net 10
-Swagger UI
-SQL Server (SSMS)

## How to run the project
### 1.Clone the repo git hub
https://github.com/Thepe314/EmployeeAttendanceWebAPI.git

### 2. Set up the database 
- Open SSMS  and connect to your SQL Server
- Update the connection string in appsettings with your server name: "DefaultConnection";
- "Server=YOUR_SERVER_NAME\\SQLEXPRESS;Database=BlogDB;Trusted_Connection=True;TrustServerCertificate=True;"

### 3.Run the project 
- using 'dotnet run'

### 4.Open the swagger
-Go to http://localhost:5100/swagger 
-Test the API

## Api Endpoints
### Attendance
-GET /apiAttendance/ {id}  -> Check if attended

-POST  /apiAttendance/checkin/ {id}  -> Check in

-POST /apiAttendance/checkout/ {id} -> Check out

### Employee
--GET /apiEmployee -> Get a list of employee

-POST /apiEmployee -> Create a new employee

-GET /apiEmployee/{id} ->Find a employee with id

-PUT /apiEmployee/ {id} ->Change values of employee with id

-DELETE /apiEmployees/{id} ->Delete an existing employee




