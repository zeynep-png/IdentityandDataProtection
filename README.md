
# Identity and Data Protection API

## Project Overview

This project demonstrates a simple user management system with identity and data protection features. It allows the creation of a `User` table that stores users' email addresses and encrypted passwords. The project utilizes Entity Framework's Code First approach to generate the database and adds API functionality for user registration.

### Key Features
- **User Registration:** Users can register by providing their email and password.
- **Password Encryption:** Passwords are securely encrypted before being stored in the database.
- **Entity Framework Code First:** The database is created using the Entity Framework Code First approach.
- **Model Validation:** User inputs are validated with `[Required]` attributes to ensure the integrity of the data.

## Technologies Used
- ASP.NET Core
- Entity Framework Core
- Microsoft Identity
- Data Protection API

## API Endpoints

### `POST /api/auth`
This endpoint registers a new user by accepting the following fields:

- `Email` (required): The email address of the user.
- `Password` (required): The password of the user, which will be encrypted before saving.


## Installation and Setup

1. Clone the repository.
2. Restore the dependencies using `dotnet restore`.
3. Update the connection string in the `appsettings.json` file to match your database configuration.
4. Run the database migrations using Entity Framework:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
5. Run the application using:
   ```bash
   dotnet run
   ```

## Code Structure

- **Controllers:** `AuthController` handles the user registration logic and interacts with the Identity service.
- **Services:** The `IIdentityService` and its implementation manage the creation of users, including password encryption and validation.
- **Models:** `RegisterRequest` and `AddIdentityDto` models define the data structure for the user registration process.
- **Validation:** Model validation is implemented to ensure proper data entry for the registration process.

## How It Works

- The user sends a `POST` request to the `/api/auth` endpoint with their email and password.
- The password is encrypted using Data Protection API before being saved to the database.
- If the registration succeeds, a success message is returned. Otherwise, an error message is provided.

## Future Improvements
- Add JWT-based authentication for login and access token generation.
- Implement additional security features such as email verification and account recovery.
