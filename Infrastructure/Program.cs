var builder = WebApplication.CreateBuilder(args);

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
