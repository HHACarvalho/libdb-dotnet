using libdb_dotnet.Core;
using libdb_dotnet.Repos;
using libdb_dotnet.Repos.IRepos;
using libdb_dotnet.Services;
using libdb_dotnet.Services.IServices;
using Microsoft.EntityFrameworkCore;

var corsPolicyName = "AllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddDbContext<AppDBContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection"));
    options.UseInMemoryDatabase(databaseName: "libDB");
});

// Add services to the container.

builder.Services.AddTransient<IBookRepo, BookRepo>();
builder.Services.AddTransient<IBookService, BookService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();