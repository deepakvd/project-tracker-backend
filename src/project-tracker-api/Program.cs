using Microsoft.EntityFrameworkCore;
using project_tracker_api.Middleware;
using project_tracker_application;
using project_tracker_infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database Wiring
builder.Services.AddInfrastructureServices(builder.Configuration);

// Application Services Wiring
builder.Services.AddApplicationServices();


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();
