using libdb_dotnet.Core;
using libdb_dotnet.Repos;
using libdb_dotnet.Repos.IRepos;
using libdb_dotnet.Services;
using libdb_dotnet.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cross-Origin Resource Sharing (CORS)

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

// Database type

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection"));
});

// Add repositories to the container

builder.Services.AddTransient<IAuthorRepo, AuthorRepo>();
builder.Services.AddTransient<IBookRepo, BookRepo>();
builder.Services.AddTransient<IMemberRepo, MemberRepo>();
builder.Services.AddTransient<IBookEntryRepo, BookEntryRepo>();
builder.Services.AddTransient<IBorrowRepo, BorrowRepo>();

// Add services to the container.

builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IBookEntryService, BookEntryService>();
builder.Services.AddTransient<IBorrowService, BorrowService>();

// Add controllers to the container

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline

app.UseCors(corsPolicyName);
app.UseAuthorization();
app.MapControllers();
app.Run();