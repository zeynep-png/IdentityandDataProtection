# Identity, Data Protection, and JWT Authentication API

## Project Overview
This project is a simple user management system with identity and data protection features, enhanced with JWT (JSON Web Token) authentication for secure access. It enables the creation of a User table to store users' email addresses and securely encrypted passwords. By using Entity Framework's Code First approach, the project generates the database schema automatically and includes API functionality for user registration and login with JWT-based access control.

## Key Features

- **User Registration**: Users can register by providing their email and password through the API.
- **Password Encryption**: Passwords are encrypted using the Data Protection API before being stored in the database.
- **JWT Authentication**: Users can log in and receive a JWT token for secure API access.
- **Entity Framework Code First**: The database is created automatically using Entity Framework's Code First approach.
- **Model Validation**: User inputs are validated using `[Required]` attributes, ensuring data integrity during registration and login.

## Technologies Used

- **ASP.NET Core**: Framework for building the web API and implementing identity and JWT authentication.
- **Entity Framework Core**: ORM for database management using Code First migrations.
- **Microsoft Identity**: Provides identity features like password encryption and user management.
- **Data Protection API**: Encrypts user passwords for secure storage.
- **JWT (JSON Web Token)**: Issues and validates tokens for secure and stateless API access.

## API Endpoints

### **POST /api/auth/register**
Registers a new user by accepting the following fields:

- **Email** (required): The email address of the user.
- **Password** (required): The password of the user, which is encrypted before saving.

### **POST /api/auth/login**
Logs in an existing user by accepting the following fields:

- **Email** (required): The email address of the user.
- **Password** (required): The password of the user.

Upon successful login, a JWT token is returned for authenticating subsequent requests.

## Installation and Setup

1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   ```

2. **Restore the dependencies**:
   ```bash
   dotnet restore
   ```

3. **Update the connection string**:
   - Modify the `appsettings.json` file to match your database configuration.

4. **Run the database migrations**:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Run the application**:
   ```bash
   dotnet run
   ```

## Code Structure

- **Controllers**: 
  - `AuthController`: Manages user registration and login, including JWT creation and validation.

- **Services**: 
  - `IIdentityService` and its implementation manage user creation, password encryption, and login logic.

- **Models**:
  - `RegisterRequest` and `LoginRequest` models define the data structure for the user registration and login processes.
  - `User` model represents the User table with properties for `Id`, `Email`, and `Password`.

- **Validation**: 
  - Model validation is implemented to ensure proper data entry during registration and login.

## How It Works

1. **User Registration**:
   - A user sends a `POST` request to the `/api/auth/register` endpoint with their email and password.
   - The password is encrypted using the Data Protection API and stored in the database.
   - If registration is successful, a success message is returned; otherwise, an error message is provided.

2. **User Login**:
   - The user sends a `POST` request to the `/api/auth/login` endpoint with their email and password.
   - The system verifies the user's credentials and, if valid, generates a JWT token.
   - The JWT token is returned to the user, allowing authenticated access to other secure endpoints.

3. **JWT Authentication**:
   - JWT tokens are generated upon successful login and are validated for each request to secure endpoints.
   - Secure endpoints are decorated with the `[Authorize]` attribute to ensure only authenticated users can access them.






