# 001: Controllers instead of Minimal APIs

## Status
Accepted

## Context
We are deciding on the primary HTTP API architecture for our ASP.NET Core application: traditional MVC-style **Controllers** (`ControllerBase`) versus **Minimal APIs** (`MapGet`, `MapPost`, etc.).

The event booking API will cover events, seats, bookings, and payments. We want to group those endpoints by resource while learning controller routing, request validation, and dependency injection.

## Decision
We use controllers.

## Why

- **Enforced structure at scale:** Class-based controllers provide a predictable convention for grouping endpoints and sharing constructor-injected dependencies, preventing `Program.cs` or route extension files from becoming cluttered as the domain grows.
- **Built-in model binding and validation:** The `[ApiController]` attribute automatically validates Data Annotations and returns standardized `400 Bad Request` (`ValidationProblemDetails`) responses without extra boilerplate or third-party validation libraries.
- **Mature filter pipeline:** Declarative action, resource, exception, and result filters give us granular lifecycle hooks at the global, controller, or endpoint level.
- **Straightforward unit testing:** Controllers are standard C# classes that can be instantiated directly in unit tests with mocked dependencies, rather than relying heavily on integration tests.

## Consequences

**What we gain:**

- Consistent, self-organizing project structure that scales cleanly with multiple developers and complex domains.
- Out-of-the-box request validation, complex binding (`[FromForm]`, `[FromQuery]`, `[FromBody]`), and JSON responses by default, with other formatters available if configured.
- Easier isolated unit testing of endpoint behavior and status codes.

**What we give up:**

- **Lower overhead and raw throughput:** Controllers carry slightly higher memory allocation and routing overhead compared to Minimal APIs.
- **Native AOT compatibility:** Minimal APIs support .NET Native AOT compilation, whereas MVC Controllers rely on runtime reflection and are not compatible with Native AOT.
- **Conciseness for simple endpoints:** Small utility or health-check endpoints require more boilerplate (class definitions, attributes, constructors) than a one-line `MapGet`.
