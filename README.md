# Student Management System

A basic MVC app to show CRUD operations with EF CORE

## Prerequisites

- .NET
- SQL Server
- EF CORE

## Configuration

- Add the connection string to connect to the database
- don't forget migration
```
dotnet ef migrations add InitialCreate
```
- After that update the database
```
dotnet ef database update
```

## Project Structure

- **Controllers:** (`StudentController`, `DepartmentController`)
- **Models:** (`Student`, `Department`)
- **Views:** (`GetAll`,`Create`, `Edit`, `Details`, `Delete`) For both Students and Departments
