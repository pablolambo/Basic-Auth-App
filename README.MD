# Basic Auth App

## What is Basic Auth App?

Basic Auth App is a simple ASP.NET Core web application that demonstrates user authentication and logout functionality. It provides endpoints for user login, register, logout and much more, allowing users to securely access and manage their accounts. Additionally, the project includes a Blazor component for integrating client-side interactivity with the part of the API.

## Features

- **POST /register**: Registers a new user and send's him verification code for email.
- **POST /login**: Logs in a user using cookies.
- **POST /refresh**: Refreshes the authentication bearer token.
- **GET /confirmEmail**: Confirms a user's email address.
- **POST /resendConfirmationEmail**: Resends the email confirmation.
- **POST /forgotPassword**: Sends a password reset code to the user's email.
- **POST /resetPassword**: Resets the user's password using the provided reset code.
- **POST /manage/2fa**: Manages two-factor authentication settings.
- **GET /manage/info**: Retrieves the current user's information.
- **POST /manage/info**: Updates the current user's information.
- **GET /account/id**: Retrieves the currently logged-in user's ID.
- **GET /account/email**: Retrieves the email of the currently logged-in user.
- **POST /account/logout**: Logs out the authenticated user. 

## Technologies Used

- **ASP.NET Core**: A cross-platform, high-performance framework for building web applications.
- **Identity**: ASP.NET Core Identity is used for managing user authentication and authorization.
- **Blazor**: A framework for building interactive web UIs using C# instead of JavaScript.
- **Swagger**: Swagger UI is integrated to provide interactive documentation for the API endpoints.
- **Cookies**: The application uses cookies for user authentication, providing a seamless login experience.
- **Bearer Tokens**: The application also supports authentication using bearer tokens, allowing for stateless authentication in API scenarios.
- **SQLite**: The application uses SQLite as its database provider for storing user data.
- **.NET 8**: The project is built using .NET 8, the latest version of the .NET framework.

## Security

- **Transport Layer Security (TLS)**: The communication between the client and server is encrypted using TLS, ensuring data confidentiality and integrity.

## EF Core Migrations

Entity Framework Core migrations are used to manage changes to your database schema over time, allowing you to evolve your database alongside your application.

### Adding a Migration

To add a new migration, run the following command at the root directory:

```bash
dotnet ef migrations add NewMigration --project .\LoginExample.Infrastructure\ --startup-project .\LoginExample.Api\
```

Apply migrations to your database:
```bash
dotnet ef database update --project .\LoginExample.Infrastructure\ --startup-project .\LoginExample.Api\
``` 

## Getting Started

### To run the Basic Auth App application locally:

1. Clone this repository to your local machine.
2. Ensure you have the .NET 8 SDK installed.
3. To be able to use the email service, we must have the local smtp server running, I used a development email server which is called smtp4dev.
```bash
dotnet tool install -g Rnwood.Smtp4dev
```
4. Then run the server by just writing smtp4dev in the shell.
```bash
smtp4dev
```
The server is now running at http://localhost:5000

5. Navigate to the project directory of the api and run `dotnet run`.
6. Navigate to the project directory of the UI and run `dotnet run`.

Please note that not everything may work, for example i haven't touched /manage/2fa endpoint. It comes out of the box from asp.net, that's why this app is basic.
