# Blog Platform API

A modern .NET Core Web API for a blog platform with features like user authentication, post management, categories, and tags.

## Features

- User Authentication with JWT
- Post Management (CRUD operations)
- Category Management
- Tag Management
- Comments on Posts
- Audit Fields (CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)

## Tech Stack

- .NET 7.0
- Entity Framework Core
- SQLite Database
- JWT Authentication
- Clean Architecture

## Prerequisites

- .NET 7.0 SDK
- Visual Studio 2022 or VS Code
- Git

## Getting Started

1. Clone the repository:
```bash
git clone https://github.com/YOUR_USERNAME/BlogPlatform.git
```

2. Navigate to the project directory:
```bash
cd BlogPlatform
```

3. Restore dependencies:
```bash
dotnet restore
```

4. Run the application:
```bash
cd BlogPlatformAPI
dotnet run
```

The API will be available at `https://localhost:44355`

## API Endpoints

### Authentication
- POST /api/Auth/register - Register a new user
- POST /api/Auth/login - Login and get JWT token

### Posts
- GET /api/Posts - Get all posts
- GET /api/Posts/{id} - Get post by ID
- POST /api/Posts - Create new post (requires authentication)
- PUT /api/Posts/{id} - Update post (requires authentication)
- DELETE /api/Posts/{id} - Delete post (requires authentication)

### Categories
- GET /api/Categories - Get all categories
- GET /api/Categories/{id} - Get category by ID
- POST /api/Categories - Create new category (requires authentication)
- PUT /api/Categories/{id} - Update category (requires authentication)
- DELETE /api/Categories/{id} - Delete category (requires authentication)

## Project Structure

- `BlogPlatform.Core` - Core domain entities and interfaces
- `BlogPlatform.Application` - Application services and DTOs
- `BlogPlatform.Infrastructure` - Data access and external service implementations
- `BlogPlatformAPI` - Web API controllers and configuration

## License

This project is licensed under the MIT License - see the LICENSE file for details. 