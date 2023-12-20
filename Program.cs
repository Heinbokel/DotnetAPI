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
                corsBuilder.WithOrigins("https://myProductionSite.com")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
    });

var app = builder.Build(); //app is our built application.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
    app.UseSwagger();
    app.UseSwaggerUI();
} else {
    app.UseCors("ProdCors");
    app.UseHttpsRedirection(); // We don't want this while in development locally, generally causes more issues than anything else.
}


app.MapControllers(); //Actually maps our built controllers by adding endpoints for the controller actions.

app.Run();


