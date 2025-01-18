# Leafy API Documentation

This is the backend service for the Leafy app, built using **.NET 8** with **Entity Framework** for the database layer. The backend provides APIs for user authentication, recycling activity management, and recycling summaries.

---

## Prerequisites

Before running this project, ensure you have the following installed:

- **.NET 8 SDK**: [Download .NET SDK](https://dotnet.microsoft.com/download)
- **SQL Server**: A running instance of SQL Server for the database.
- **Postman** (optional): For API testing, or use the built-in Swagger UI.

---

## Setup Instructions

### 1. Clone the Repository

Clone the repository to your local machine:

```bash
git clone <backend-repo-url>
cd <repository-folder>
```

### 2. Configure the Database Connection

The project uses **Entity Framework** with SQL Server. Update the connection string in `appsettings.json` if needed:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=LeafyDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Replace `YOUR_SERVER` with your SQL Server instance name.

### 3. Apply Migrations

Run the following commands to ensure the database is created and up-to-date:

```bash
dotnet ef database update
```

> Note: Make sure Entity Framework CLI tools are installed globally. If not, install them with:
> ```bash
> dotnet tool install --global dotnet-ef
> ```

### 4. Run the Backend

Run the backend simply by starting with debugger or by using the following command:

```bash
dotnet run
```

By default, the server will start on ` http://localhost:7007`.

---

## Features

### Authentication Endpoints
- **Signup**: Create a new user.
- **Login**: Authenticate and receive a JWT token.
- **Get Current User**: Retrieve details about the logged-in user.

### Recycling Activity Endpoints
- **Create Activity**: Log a recycling activity.
- **Get Activities**: Retrieve all recycling activities for the authenticated user.
- **Update/Delete Activities**: Modify or delete an existing activity.
- **Summary**: Get a summary of recycling activities (e.g., total points, quantities).

### Swagger UI

Once the backend is running, you can test the API directly via Swagger:

- Navigate to: `https://localhost:7007/swagger`

---

## Troubleshooting

### Common Issues

1. **Database Connection Error**:
   - Ensure your SQL Server instance is running and accessible.
   - Double-check your connection string in `appsettings.json`.

2. **CORS Issues**:
   - Ensure the React frontend is running on `http://localhost:3002` (if not, check the client localhost and change it in your Program.cs line 57.).
   - The backend allows requests from this origin by default.

3. **Entity Framework CLI Not Found**:
   - Install the EF CLI tools with:
     ```bash
     dotnet tool install --global dotnet-ef
     ```

---

## Environment Variables

The following settings are defined in `appsettings.json`. Update them as needed:

```json
"JwtSettings": {
  "Secret": "ThisIsASecureSecretKey123",
  "Issuer": "LeafyApp",
  "Audience": "LeafyAppUsers",
  "ExpiresInMinutes": 60
}
```

---

## Contributing

Feel free to submit issues or feature requests by opening an issue in the repository. Contributions are welcome!
