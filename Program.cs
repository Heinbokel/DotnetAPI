using System.Data;
using DotnetAPI.Repositories;
using DotnetAPI.Repositories.Configuration;
using DotnetAPI.Services;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args); //Builder that builds the actual API/Server

builder.Services.AddControllers(); //Adds our controllers to our application to find.

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS Policies
builder.Services.AddCors((options) =>
    {
        options.AddPolicy("DevCors", (corsBuilder) =>
            {
                corsBuilder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        options.AddPolicy("ProdCors", (corsBuilder) =>
            {
                corsBuilder.WithOrigins("https://bobhomeuploadtest1.azurewebsites.net")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
    });

//Add our mappings for dependency injection.

//Repositories
builder.Services.AddScoped<DataContextEF>();
builder.Services.AddScoped<IDbConnection>(_ => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepositoryEF>();

//Services
builder.Services.AddScoped<IUserService, UserService>();

//Singletons/Factories
// builder.Services.AddSingleton<DatabaseConnectionFactory>(impl => {
//     return new DatabaseConnectionFactory(builder.Configuration.GetConnectionString("DefaultConnection"));
// });

var app = builder.Build(); //app is our built application.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
    app.UseSwagger();
    app.UseSwaggerUI();
} else {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("ProdCors");
    app.UseHttpsRedirection(); // We don't want this while in development locally, generally causes more issues than anything else.
}


app.MapControllers(); //Actually maps our built controllers by adding endpoints for the controller actions.

app.Run();


