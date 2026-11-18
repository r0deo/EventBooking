# Event Booking system 
# problem: Organizers need a way to sell seats for events, and customers need to find an event, pick a seat and pay, without ever getting a seat someone else already bought

# user/ roles 
Customer (browses and books), Organizer (creates events and seats), Admin (manages the platform).

# core features. mvp 
Customer can see the list of upcoming events
customer can see a list of available seats
customer can choose a seat to book 
customer can unbook or cancel his seat
customer can select many seats for himself and others from his side 
Organizer can create an event with a venue and seats
Owner can manage organizers
Owner can show seats 
Check seat is available 
check the token



# out of scope 
1. front end
2. caching Not in version 1

# non-functional requirements 
1. response should be sent in 500ms
2. a seat must never be sold twice 
3. 2000 peopel only alowed to select seates. in order to prevent load 
4. two users should not choose the same seat. that creates race condition 
5. only logged in users should book 
