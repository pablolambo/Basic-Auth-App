# LoginExample

## What is LoginExample?

LoginExample is a simple ASP.NET Core web application that demonstrates user authentication and logout functionality. It provides endpoints for user login, register, logout and much more, allowing users to securely access and manage their accounts. Additionally, the project includes a Blazor component for integrating client-side interactivity with the part of the API.

## Features

- **User Authentication**: Users can log in using their credentials (e.g., email and password) to access protected resources.
- **Logout Functionality**: Users can log out from their accounts to end their session and protect their privacy.
- **Blazor Component**: A Blazor component is included for interactive client-side features, enhancing the user experience.
- **Swagger Documentation**: The application includes Swagger documentation to facilitate API testing and exploration.

## Technologies Used

- **ASP.NET Core**: A cross-platform, high-performance framework for building web applications.
- **Identity**: ASP.NET Core Identity is used for managing user authentication and authorization.
- **Blazor**: A framework for building interactive web UIs using C# instead of JavaScript.
- **Swagger**: Swagger UI is integrated to provide interactive documentation for the API endpoints.
- **Cookies**: The application uses cookies for user authentication, providing a seamless login experience.
- **Bearer Tokens**: The application also supports authentication using bearer tokens, allowing for stateless authentication in API scenarios.
- **SQLite**: The application uses SQLite as its database provider for storing user data.
- **.NET 8**: The project is built using .NET 8, the latest version of the .NET framework.

## Getting Started

To run the LoginExample application locally:

1. Clone this repository to your local machine.
2. Ensure you have the .NET 8 SDK installed.
3. Navigate to the project directory of the api and run `dotnet run`.
4. Navigate to the project directory of the UI and run `dotnet run`.
