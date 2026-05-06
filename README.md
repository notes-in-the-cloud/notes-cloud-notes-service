Notes API

This service provides CRUD operations for managing user notes. Each note is associated with a specific user and is accessed via RESTful endpoints.

Base Route
/api/users/{userId}/notes

All endpoints require a valid userId (GUID) in the route.

Endpoints

-Get All Notes

GET /api/users/{userId}/notes

Returns all notes for a given user.

Response:

200 OK - List of notes

-Get Note by ID

GET /api/users/{userId}/notes/{noteId}

Returns a specific note by its ID.

Response:

200 OK – Note object
404 Not Found – If note does not exist

-Create Note

POST /api/users/{userId}/notes

Creates a new note for the specified user.

Request Body:

{
  "title": "string",
  "content": "string",
  "color": "string"
}

Response:

201 Created – Returns created note
Location header contains URL to the new resource

-Update Note

PUT /api/users/{userId}/notes/{noteId}

Updates an existing note.

Request Body:

{
  "title": "string",
  "content": "string",
  "color": "string"
}

Response:

200 OK – Updated note
404 Not Found – If note does not exist

-Delete Note

DELETE /api/users/{userId}/notes/{noteId}

Deletes a note.

Response:

204 No Content – Successfully deleted

Models
NoteDto

Used for creating and updating notes.

Field	Type	Required
Title	string	Yes
Content	string	Yes
Color	string	Yes

Note

Represents a stored note.

Field	     Type
Id	         Guid
UserId	     Guid
Title	     string
Content	     string
Color	     string
CreatedAt	 DateTime
UpdatedAt	 DateTime

Notes
userId and noteId are passed via the URL path, not in the request body or query parameters.
Model validation is handled via data annotations ([Required]).
Invalid GUIDs in the route will automatically result in a 400 Bad Request.