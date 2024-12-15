using Application.Services;
using Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .MinimumLevel.Information()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Use Serilog as the logging provider
builder.Host.UseSerilog();

// Register services
builder.Services.AddSingleton<IShipmentService, ShipmentService>();

// Register FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<ShipmentValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Add WebAPI controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger for API testing
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.UseRouting();

// Map the controllers
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
