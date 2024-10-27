# Use the ASP.NET Core Runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published app to the docker image
COPY libdb-dotnet/bin/Release/net8.0/publish/ .

# Copy the .env file
COPY .env .

# Expose the port the app runs on
EXPOSE 8080

# Launch the application
ENTRYPOINT ["dotnet", "libdb-dotnet.dll"]
