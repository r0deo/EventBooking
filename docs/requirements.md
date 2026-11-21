# Event Booking System

## Problem

Organizers need a way to sell seats for events, and customers need to find an event, pick a seat and pay, without ever getting a seat someone else already bought.

## User roles

- Customer: browses events and books seats.
- Organizer: creates events and seats.
- Admin: manages the platform.

## Core features (MVP)

- Customer can view upcoming events.
  - Rule: only return events whose start time is later than the current UTC time.
- Customer can view available seats for an event.
- Customer can book one or more seats for themselves and others.
  - Rule: check that every selected seat is available before holding the seats.
- Customer can pay for a booking.
  - Rules: verify booking ownership and an active seat hold; confirm the booking only after successful payment before the hold expires.
- Customer can view their bookings and payment status.
  - Rule: return only the Customer's own bookings.
- Customer can cancel their booking.
  - Rule: verify booking ownership before cancellation.
- Organizer can create an event with a venue and seats.
  - Rule: require the Organizer role.
- Admin can manage organizers.
  - Rule: require the Admin role.

## Out of scope

- Front end.
- Caching in version 1.

## Non-functional requirements

- Responses must be sent within 500 ms.
- A seat must never be sold twice, even when many users try to book it at the same moment (race condition).
- The system must handle 2,000 booking attempts in the first minute of a popular event.

## Business rules

### Authentication

- Viewing upcoming events and available seats is public; customers can browse without logging in.
- All other endpoints require authentication with a valid token, plus the role and ownership checks specified for each feature.

### Seat hold

- When a customer selects seats, they are held for 10 minutes (configurable in appsettings.json).
- Held seats cannot be selected by other customers.
- If payment is not completed before the hold expires, the seats are released.

### Group booking

- Decision: all-or-nothing.
- Every requested seat must be held together and confirmed together after successful payment. If any requested seat is unavailable, reject the entire request without holding any of the seats.
- Why: customers booking for a group need the full set of seats. Giving them only 3 of 4 requested seats could leave someone out and force them to cancel or find another set. Rejecting the whole request lets them choose a complete set before paying.
