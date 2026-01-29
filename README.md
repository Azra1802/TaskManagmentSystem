# Task Management System
---

## Overview

<p>This project is a Task Management System built with ASP.NET Core MVC and C#  </p>
<p>The application includes a REST API for managing tasks and a simple Razor View (MVC) frontend that consumes the API. </p> 
<p>All data is stored in memory using standard .NET data structures, without any database or external storage libraries.</p>



## Architecture Overview

- **TasksApiController**
  - Handles REST API endpoints
  - Used for Create, Update, Delete operations

- **TasksController**
  - MVC controller for Razor Views
  - Returns views and partial views (modals, table rows)

- **TaskService**
  - In-memory data storage using `Dictionary<int, TaskModel>`
  - Central business logic layer

---

## Installation & Run

**Prerequisites**    
- Visual Studio
  
**Steps**
 1.  Clone the repository:
  ```bash
  git clone https://github.com/Azra1802/TaskManagmentSystem.git
  ```
 2.  Restore dependencies:
  ```bash
  dotnet restore
  ```
 3.  Run:
  ```bash
  dotnet run
  ```
 4.  Access:    
  Navigate to https://localhost:{port}/Tasks


