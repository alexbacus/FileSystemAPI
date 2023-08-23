using FileSystemAPI;
using FileSystemAPI.Interfaces;
using FileSystemAPI.Managers;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDirectoryManager, DirectoryManager>();
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserSessionManager, UserSessionManager>();
builder.Services.AddDbContext<FileSystemContext>(options => options.UseSqlServer("Server=tcp:alexb-filesystem.database.windows.net,1433;Initial Catalog=filesystem_db;Persist Security Info=False;User ID=alexb;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
