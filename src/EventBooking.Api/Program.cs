using EventBooking.Api.Infrastructure;
using EventBooking.Api.Services;
using EventBooking.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddOpenApi();
builder.Services.AddSingleton<TimeProvider>(TimeProvider.System);
// Reuse one service instance: the fixed event collection is initialized once and only read across requests.
builder.Services.AddSingleton<IEventService, InMemoryEventService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
    
var app = builder.Build();

// Wrap the middleware and endpoints below so their unhandled exceptions become ProblemDetails responses.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
