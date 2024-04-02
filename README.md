# Book Library API

## Prerequisites

- .NET 6 SDK or later
- Visual Studio 2022 or later (with ASP.NET and web development workload installed)

### Setup

1. Clone the repository or download the source code.
2. Open the project by navigating to the project folder and opening the .sln file directly with Visual Studio.
3. Restore all NuGet packages by right-clicking on the solution and selecting "Restore NuGet Packages".

### Run the Application

1. Press `F5` or click on the "IIS Express" button in Visual Studio to start the application.
2. The application will open in your default web browser, and you can navigate to `https://localhost:7148/swagger` to access the Swagger UI for testing the API endpoints.

### Testing the API

- Use the Swagger UI to send requests to the API and view responses.
- For automated testing, you can run the included unit tests within the Visual Studio Test Explorer.

## Features

The API supports the following operations on books:

- `GET /api/books`: Retrieve a list of all books.
- `GET /api/books/{isbn}`: Retrieve a book by its ID.
- `POST /api/books`: Add a new book to the library.
- `PUT /api/books/{isbn}`: Update the details of an existing book.
- `DELETE /api/books/{isbn}`: Remove a book from the library.

## Data Seeding

The API is pre-configured to seed the in-memory database with a set of initial books.
