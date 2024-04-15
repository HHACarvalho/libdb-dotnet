# LibDB ASP.NET Core API

RESTful API built with ASP.NET Core

# Routes

Default API url - http://localhost:4000

# Endpoints

* [Author](docs/author.md)
* [Book](docs/book.md)
* [BookEntry](docs/book_entry_.md)
* [Borrow](docs/borrow.md)
* [Member](docs/member.md)

# .NET Commands

### Build the application

```
dotnet build
```

### Run the application

```
dotnet run
```

### Run the tests

```
dotnet test
```

# Docker Commands

### Create SQL Server Instance

```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Docker@1!" -p 1401:1433 --name sqlserver2022 -d mcr.microsoft.com/mssql/server:2022-latest
```

Note: [Docker Documentation](https://docs.docker.com/reference/cli/docker/container/run/)

# Entity Framework Core (Tools) Commands

### Create Database

```
Add-Migration Initial
```

### Update Database

```
Update-Database
```

### Remove Database

```
Remove-Migration
```