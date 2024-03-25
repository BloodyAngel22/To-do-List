# To-do-List
Basic to-do list for a single user

## Description

>This project is a basic to-do list for a single user. It uses ASP.NET Core and Entity Framework Core.

## Dependencies
- [Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation](https://github.com/dotnet/AspNetCore/tree/main/src/Mvc/Mvc.Razor.RuntimeCompilation)
- [Microsoft.EntityFrameworkCore.Design](https://github.com/dotnet/AspNetCore/tree/main/src/EntityFrameworkCore.Design)
- [Npgsql.EntityFrameworkCore.PostgreSQL](https://github.com/dotnet/AspNetCore/tree/main/src/EntityFrameworkCore.PostgreSQL)

## Usage

- PostgreSQL

## How to run

- First you need to create a postgres database:

```sh
sudo -u postgres psql
```

- Then run the following commands:

```psql
CREATE DATABASE todolist;
```

- Then you need update migrations:

```bash
dotnet ef database update
```

- Then you can run the application:

```bash
dotnet build
dotnet run
```