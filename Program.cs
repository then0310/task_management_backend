using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using task_management_application.Services;

var builder = WebApplication.CreateBuilder(args);

// Register TaskService for Dependency Injection
builder.Services.AddSingleton<ITaskService, TaskService>();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
        policy.WithOrigins("http://localhost:3000")  // Allow frontend React/Angular/Vue, etc.
              .WithMethods("GET", "POST", "PUT", "DELETE") // Allow specific HTTP methods
              .WithHeaders("Content-Type")); // Allow specific headers
});

// Add services to the container.
builder.Services.AddHealthChecks();

var app = builder.Build();

// Use CORS in the middleware
app.UseCors("FrontendPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
