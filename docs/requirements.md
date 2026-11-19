# Event Booking System

## Problem

Organizers need a way to sell seats for events, and customers need to find an event, pick a seat and pay, without ever getting a seat someone else already bought.

## User roles

- Customer: browses events and books seats.
- Organizer: creates events and seats.
- Admin: manages the platform.

## Core features (MVP)

- Customer can view upcoming events.
- Customer can view available seats for an event.
- Customer can book one or more seats for themselves and others.
  - Rules: validate the Customer's authentication token and check that every selected seat is available before accepting the booking.
- Customer can pay for a booking.
  - Rules: validate the Customer's authentication token and booking ownership; confirm the booking only after successful payment.
- Customer can view their bookings and payment status.
  - Rules: validate the Customer's authentication token and return only their own bookings.
- Customer can cancel their booking.
  - Rules: validate the Customer's authentication token and booking ownership before cancellation.
- Organizer can create an event with a venue and seats.
  - Rules: validate the authentication token and require the Organizer role.
- Admin can manage organizers.
  - Rules: validate the authentication token and require the Admin role.

## Out of scope

- Front end.
- Caching in version 1.

## Non-functional requirements

- Responses must be sent within 500 ms.
- A seat must never be sold twice, even when many users try to book it at the same moment (race condition).
- The system must handle 2,000 booking attempts in the first minute of a popular event.

## buisness rules 
- the seat hold time (configrable in appesetting. 10 min for paying)
- booking should be handled with atomicity 
- 
