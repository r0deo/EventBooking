using EventBooking.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();
// Reuse one service instance: the fixed event collection is initialized once and only read across requests.
builder.Services.AddSingleton<IEventService, InMemoryEventService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
