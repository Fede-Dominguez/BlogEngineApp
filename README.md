# Aoniken Blog API

A small, clean **REST API for managing blog posts**, built with **ASP.NET Core (.NET)** and **Entity Framework Core** over **SQL Server**. An editor can create, review, update and publish blog entries through a set of well-defined endpoints, documented and testable out of the box with **Swagger UI**.

> Built as a practice project to apply a layered architecture (Controller → Facade → Service/EF Core) and clean separation of concerns in C#.

## ✨ Features

- **CRUD endpoints** for blog posts (create, read, update).
- **Editorial workflow**: posts are created in a `Pending` state and can later be moved to `Published`.
- **Input validation** before persisting (required title and author, valid state).
- **Interactive API docs** via Swagger UI — explore and test every endpoint from the browser.
- **Layered architecture** that keeps controllers thin and business rules isolated.

## 🧱 Architecture

```
Controllers/   →  HTTP layer (BlogController): routing and error handling
Facade/        →  Business logic (BlogFacade): validation + use cases
Service/       →  EF Core DbContext (BlogContext)
Helper/        →  Reusable validation rules (ValidationHelper)
Model/         →  Domain model (Blog)
Connection/    →  Connection string resolution (ConnectionDB)
```

## 🛠️ Tech stack

- C# / ASP.NET Core (Web API)
- Entity Framework Core
- SQL Server (LocalDB)
- Swagger / OpenAPI (Swashbuckle)

## 🚀 Getting started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)
- SQL Server / SQL Server Express **LocalDB**

### 1. Create the database
Run [`Script_BlogsTable.sql`](Script_BlogsTable.sql) against your SQL Server instance to create the `BLOG` table.

### 2. Configure the connection
Edit the `ConnectionStrings:DefaultConnection` value in [`appsettings.json`](appsettings.json) so it points to your database:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=(localdb)\\YourInstance;Initial Catalog=AONIKEN;Integrated Security=True"
}
```

### 3. Run
```bash
dotnet run
```
Then open the Swagger UI shown in the console output (e.g. `https://localhost:<port>/swagger`).

## 📡 API endpoints

| Method | Route                 | Description                                   |
|--------|-----------------------|-----------------------------------------------|
| GET    | `/Blog/GetBlos`       | Returns all blogs in `Pending` state.         |
| GET    | `/Blog/GetBlogsByCod` | Returns a single blog by its code (`cod`).    |
| POST   | `/Blog/SaveBlogs`     | Creates a new blog (starts as `Pending`).     |
| PUT    | `/Blog/UpdateBlogs`   | Updates an existing blog by its code (`cod`). |

### Example: create a blog
```http
POST /Blog/SaveBlogs
Content-Type: application/json

{
  "title": "My first post",
  "description": "Hello world",
  "author": "Fede"
}
```

## 🗺️ Possible improvements

- Add a `DELETE` endpoint and a dedicated "publish" action.
- Inject `BlogContext` via dependency injection instead of instantiating it manually.
- Return proper HTTP status codes (e.g. `404`) instead of throwing on not-found.
- Add automated tests.

## 📄 License

Available for educational and portfolio purposes.
