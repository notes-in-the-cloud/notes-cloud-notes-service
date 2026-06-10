Notes API Readme

NotesService
│
├── Controllers
│   └── NotesController.cs
│
├── Models
│   ├── Note.cs
│   └── NoteDTO.cs
│
├── Services
│
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── NotesService.csproj

This is a C# ASP.NET Core REST API service that provides CRUD operations for managing user notes. Each note is associated with a specific user and is accessed via RESTful endpoints.

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

Infrastructure
The Kubernetes manifests for this service are maintained in the notes-cloud-infrastructure repository under k8s/notes-service/.

ConfigMap (notes-service-config-map.yaml)
Provides non-sensitive environment configuration injected into the container at runtime:
Key	Value
ASPNETCORE_ENVIRONMENT	Development
ASPNETCORE_URLS	http://+:8082

Secret (notes-service-secret.yaml)
Provides sensitive configuration injected into the container at runtime:
Key	Description
ConnectionStrings__DefaultConnection	PostgreSQL connection string targeting the notes_service schema in the notes_cloud database

Deployment (notes-service-deployment.yaml)
Namespace: notes-cloud
Image: hristo12319/notes-cloud-notes-service:v1
Replicas: 1
Port: 8082
Config source: notes-service-config (ConfigMap) + notes-service-secret (Secret)
Readiness probe: GET /api/readyz on port 8082
Liveness probe: GET /api/healthz on port 8082
Resource requests: 100m CPU / 128Mi memory
Resource limits: 500m CPU / 256Mi memory

Service (notes-service-cluster-ip.yaml)
Exposes the deployment internally within the cluster via a ClusterIP service on port 8082. This means the service is not directly reachable from outside the cluster and is intended to be accessed through an ingress or API gateway.
