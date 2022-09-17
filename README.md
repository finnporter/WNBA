# WNBA stats engine

## Introduction

## Specifications
Everything that seems important to know.

### Integrations
Currently the engine connects to the Sportsradar API on a test account with limited requests per minute and month  
to get WNBA data. Other API providers might be integrated in the future.

### Versions
Current version: v1

### Formats
Requests should have a JSON formatted request body, if needed.
Responses will also be provided either as simple status codes or JSON formatted response body.


## Endpoints
All endpoints are preceded by the api version you want to address. eg. /v0/ping

### Ping
- GET: /ping  
Used to check if the engine is up and running and reachable.

### Venues
- GET: /venues  
Represents the index function and returns all venues.
- GET: /venues/{id}  
Represents the read function and returns a specific value. Param needed: valid venue id
- POST: /venue  
Creates a new venue if provided with valid data.
- PATCH: /venue/{id}
Updates a venue, given a valid venue id and JSON.
- PATCH: /venues  
Updates multiple venues, given a valid JSON
- DELETE: /venue/{id}
Desctructive action. Please be sure you really want to delete this venue.