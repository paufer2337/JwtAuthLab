# JWT Authentication Lab

> **Implementing JWT authentication and authorization in ASP.NET Core Web API.**

This project demonstrates how JWT (JSON Web Tokens) can be used to authenticate users, protect API endpoints and authorize requests using Bearer tokens through Swagger.

---

# Tech Stack

- C#
- ASP.NET Core Web API (.NET 10)
- JWT Bearer Authentication
- Swashbuckle (Swagger / OpenAPI)

---

# Requirements

- .NET 10 SDK

Check installed version:

```bash
dotnet --version
```

---

# Installation

## Restore dependencies

```bash
dotnet restore
```

## Build

```bash
dotnet build
```

## Run

```bash
dotnet run
```

Swagger:

```
http://localhost:5099/swagger
```

---

# Project Structure

```
JwtAuthLab
│
├── Controllers
│   ├── AuthController.cs
│   └── SecureDataController.cs
│
├── Configuration
│   └── JwtSettings.cs
│
├── Models
│   └── LoginRequest.cs
│
├── Program.cs
└── appsettings.json
```

---

# Authentication Flow

```
Login
    │
    ▼
JWT Token
    │
    ▼
Swagger Authorize
    │
    ▼
Protected Endpoint
    │
    ▼
Authorized Response
```

---

# Endpoints

## Authentication

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/login` | Generates a JWT token |

## Protected

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/securedata` | Requires a valid JWT token |

---

# Test Credentials

```text
Username: admin
Password: hemligt
```

---

# Features

- JWT Authentication
- JWT Authorization
- Protected API endpoints
- Swagger Authorization
- Strongly typed JWT configuration

---

# Notes

This laboratory uses a hardcoded user to keep the focus on JWT authentication.

In a production environment this would typically be replaced with:

- ASP.NET Core Identity
- Database-backed users
- Password hashing
- Refresh Tokens
- Role-based authorization