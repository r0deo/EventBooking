// Create the application's builder, which sets up configuration, logging, and services using the command-line arguments.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Services is the dependency injection registration list: it tells ASP.NET Core which objects it can create and supply when requested.
// AddControllers registers the framework services needed to discover controllers, bind request data, and format responses.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Register the services that generate an OpenAPI document describing the API's endpoints; this does not expose its URL yet.
builder.Services.AddOpenApi();

// Build the application and its dependency injection container from the registrations above, ready to configure request handling.
var app = builder.Build();

// Configure the HTTP request pipeline.
// Only expose the API description when the configured environment is Development.
if (app.Environment.IsDevelopment())
// Begin the Development-only configuration block.
{
    // Map an endpoint that serves the OpenAPI JSON document, by default at /openapi/v1.json; this does not add a Swagger UI.
    app.MapOpenApi();
// End the Development-only configuration block.
}

// Middleware is a step in the request pipeline: it can handle a request itself or pass it to the next step.
// Requests pass through middleware in registration order, and responses travel back through those steps in reverse.
// Redirect HTTP requests to HTTPS when an HTTPS port is configured; putting this first allows redirects before authorization checks.
app.UseHttpsRedirection();

// Check the matched endpoint's authorization rules before its action runs; endpoints without those rules can still allow public access.
// This checks access permissions, not login credentials. If authentication is added later, UseAuthentication belongs before UseAuthorization.
app.UseAuthorization();

// Register controller actions as endpoints using their route attributes, including GET /api/events.
// Map calls declare endpoints rather than adding ordinary middleware steps. WebApplication supplies routing and endpoint execution automatically,
// so the matched controller action runs after the authorization middleware has had a chance to check access.
app.MapControllers();

// Start the web server and keep this process running to handle requests until the application shuts down.
app.Run();
