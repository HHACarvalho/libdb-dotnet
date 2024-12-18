# LibDB ASP.NET Core API

RESTful API built with ASP.NET Core used for the business logic portion of the project.

# Endpoint documentation

- [Author](docs/author.md)
- [Book](docs/book.md)
- [BookEntry](docs/book_entry_.md)
- [Borrow](docs/borrow.md)
- [Member](docs/member.md)

# Building the application

After installing [Docker](https://www.docker.com/) and filling in the missing information in the .env file, run the [publish.sh](https://github.com/HHACarvalho/libdb-dotnet/blob/main/publish.sh) script. Note: It is recommended that the approach in the main LibDB repository be used.

# Commands

### General

Compile solution

```
dotnet publish
```

Run the compiled application

```
dotnet libdb-dotnet.dll
```

### Entity Framework Core (Tools)

Create database migration

```
Add-Migration Main
```

Apply the migration to the database

```
Update-Database
```
