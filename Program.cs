var builder = WebApplication.CreateBuilder(args); //Builder that builds the actual API/Server

builder.Services.AddControllers(); //Adds our controllers to our application to find.

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); //app is our built application.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} else {
    app.UseHttpsRedirection(); // We don't want this while in development locally, generally causes more issues than anything else.
}


app.MapControllers(); //Actually maps our built controllers by adding endpoints for the controller actions.

app.Run();


