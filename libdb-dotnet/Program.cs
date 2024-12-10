using DotNetEnv;
using libdb_dotnet.Core;
using libdb_dotnet.Repos;
using libdb_dotnet.Repos.IRepos;
using libdb_dotnet.Services;
using libdb_dotnet.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from the .env file

string? dbConnectionString;

if (builder.Environment.EnvironmentName.Equals("Development", StringComparison.InvariantCultureIgnoreCase))
{
    Env.Load(@"../.env");
    dbConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_DEVELOPMENT");
}
else
{
    Env.Load();
    dbConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_PRODUCTION");
}

ArgumentException.ThrowIfNullOrEmpty(dbConnectionString, nameof(dbConnectionString));

// Setup Cross-origin resource sharing

var corsPolicyName = "AllowAllOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName, policy =>
    {
        policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Setup database

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseNpgsql(dbConnectionString);
});

// Add repositories

builder.Services.AddTransient<IAuthorRepo, AuthorRepo>();
builder.Services.AddTransient<IBookRepo, BookRepo>();
builder.Services.AddTransient<IMemberRepo, MemberRepo>();
builder.Services.AddTransient<IBookEntryRepo, BookEntryRepo>();
builder.Services.AddTransient<IBorrowRepo, BorrowRepo>();

// Add services

builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IBookEntryService, BookEntryService>();
builder.Services.AddTransient<IBorrowService, BorrowService>();

// Add controllers

builder.Services.AddControllers();

// Build the application

var app = builder.Build();

// Get an instance of the logger

var logger = app.Services.GetRequiredService<ILogger<Program>>();

// Automatically apply migrations

using (var scope = app.Services.CreateScope())
{
    try
    {
        scope.ServiceProvider.GetRequiredService<AppDBContext>().Database.Migrate();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating the database");
    }
}

// Health endpoint

app.MapGet("/health", () => Results.Ok());

// Configure the HTTP request pipeline

app.UseCors(corsPolicyName);
app.UseAuthorization();
app.MapControllers();
app.Run();