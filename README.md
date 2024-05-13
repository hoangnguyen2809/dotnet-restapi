# ASP.NET Core simple REST API

## Description
This project is a simple REST API application built using ASP.NET Core Minimal APIs. It provides endpoints to manage courses, including retrieving a list of courses, fetching details of a specific course, creating a new course, updating an existing course, and deleting a course. The project utilizes Entity Framework Core for data handling and SQLite as the database provider.

## Requirements to run
- Ensure you have .NET 8.0 SDK and sqlite3 installed.

## How to run
- Clone the repository to your local machine.
- Navigate to the project directory.
- Run dotnet build to build the project.
- Run dotnet run to start the application.

## Usage:
Once the application is running, you can interact with the following endpoints:
```
GET /courses: Retrieve a list of all courses.
GET /faculties: Retrieve a list of all faculties.
GET /courses/{id}: Retrieve details of a specific course by providing its ID.
GET /faculties/{id}: Retrieve details of a specific faculty by providing its ID.

POST /courses: Create a new course by providing the necessary data in the request body.

PUT /courses/{id}: Update an existing course by providing its ID and the updated data in the request body.

DELETE /courses/{id}: Delete a course by providing its ID.
```

Example http file: [myAPI.http](MyAPI/myAPI.http)

## Dependencies
- Microsoft.AspNetCore.OpenApi 8.0.4
- Microsoft.EntityFrameworkCore.Design 8.0.4
- Microsoft.EntityFrameworkCore.Sqlite 8.0.0
- MinimalApis.Extensions 0.11.0

## Notes:
- This application uses ASP.NET Core Minimal APIs for routing and handling HTTP requests.
- Ensure that the database connection string is properly configured in the appsettings.json file.
- Customize the mapping, entities, and DTOs according to your project requirements.
