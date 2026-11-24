# Progress

## Week 1

- Day 1: Installed tools, created the repository, and initialized the project.
- Day 2: Refined the MVP requirements, added payment and booking history, standardized role names, and clarified performance and concurrency requirements. Documented a configurable 10-minute seat hold, all-or-nothing group booking and its rationale, and public browsing with authentication required for all other endpoints.
- Day 3: Added GET /api/events with three hardcoded events, renamed the controller to EventsController, and moved EventListItem into Contracts. Completed the controllers-versus-Minimal-APIs decision record and the business rules in requirements.md. Removed WeatherForecast.cs and updated the HTTP request example.
- Day 4: Added a singleton event service with constructor injection and event lookup (200/404). Ran and reverted the scoped-into-singleton DI experiment. Added and verified global exception handling, then removed the temporary throwing endpoint. Moved service files into Services/ and made event listings return only upcoming events using an injected UTC clock. Replaced UnitTest1.cs with InMemoryEventServiceTests.cs and added two FakeTimeProvider tests: GetUpcoming on 2027-02-01 returns two events, and GetById with an unknown ID returns null.
- Day 5: Documented the proposed Seat, EventSeat, and BookingSeat model in docs/data-model.md, with supporting entities, relationships, keys, seat holds, all-or-nothing booking, and double-booking constraints. Marked field choices and unresolved implementation decisions for review. Removed the stale requirements copy from docs/progress/week1/PROGRESS.MD; requirements remain in docs/requirements.md and progress in this root file.
