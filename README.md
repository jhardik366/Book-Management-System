# Book Management Service

It has 2 controllers
- TokenController: For generating JWT token with an access time of 5 minutes
- BookController: For all book-related CRUD operations

Endpoint for generating token: [HttpPost] https://localhost:44378/api/token

Endpoint for getting the list of books: [HttpGet] https://localhost:44378/api/book
<br />
Endpoint for getting info of a book: [HttpGet] https://localhost:44378/api/book/{id}
<br />
Endpoint for getting creating a book: [HttpPost] https://localhost:44378/api/book/
<br />
Endpoint for getting updating a book: [HttpPut] https://localhost:44378/api/book/{id}
<br />
Endpoint for getting deleting a book: [HttpDelete] https://localhost:44378/api/book/{id}
<br />
