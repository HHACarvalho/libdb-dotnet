# Use the .NET 8 SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app/

# Copy the project files
COPY libdb-dotnet/ ./

# Build the application
RUN dotnet publish -o /app/publish/

# Use the ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app/

# Copy the published application and the .env file
COPY --from=build /app/publish/ ./
COPY .env ./

# Expose the port the app runs on
EXPOSE 8080

# Launch the application
ENTRYPOINT ["dotnet", "libdb-dotnet.dll"]