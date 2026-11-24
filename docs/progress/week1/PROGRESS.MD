

# Event Booking system 
# problem: User may choose or select the same seat in the same time. that creates a race condition, withen the system we are creating. we will solve this issue 

# user/ roles 
1. normal users
2. owners 
3. labors(mentors, organizars, etc)

# core features. mvp 
1. api for selecting a seat (endpoint, validation, request body, enity, buisness rules file, table in db, response)
2. authentacation 
2. tests (unit test, integration tests)


# out of scope 
1. front end
2. caching 

# non-functional requirements 
1. response should be sent under 5 sec
2. check if the seat is availabe before we sent a response 
3. check the token of the request 