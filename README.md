# WNBA stats engine

## Introduction
I've started this project to learn more about data handling. In the process I want to produce some fun stats that aren't the usual ones. I'm thinking about answering questions like:  
Do players perform better on their birthday? Does height really make people better basketball players? And similar things.

## Specifications
The project runs in .NET 6. It's a simple console project. The plan is to split the project up into several as it grows and makes sense.

### How to contribute
The easiest way to contribute is to look for an issue that you find interesting and leave a comment. Because I'm working on this by myself at the moment, the issues are not always very clearly worded.
So feel free to reach out and ask for clarification and let me know that you'd be interested to work on it. Then you need to fork the project and do a pull request when you're done.
Please branch off develop and not main, as this will be the most up to date branch for a while. Always reference the issue you're working on in your branch name.
e.g. feature/{issue number}/give-it-a-short-descriptive-name
If you're unsure, don't worry. Just do as you see fit and it will be fine. I'm not always sticking to my own rules either.

### How to run
To get it to run, you'll need your own SQL Database and your own Sportsradar API key. You can find the documentation [here](https://developer.sportradar.com/io-docs).
All you should have to do is fork and clone the project. Then restore the NuGet Packages and, fingers crossed, it should run. Feel free to reach out if it doesn't.

### Integrations
Currently the engine connects to the Sportsradar API on a test account with limited requests per minute and month  
to get WNBA data. Other API providers might be integrated in the future.  
The limited requests are also the reason I'm saving things to a database instead of doing the calculations on the fly. There is some basic data, that only needs to be updated every once in a while and therefore doesn't need to be fetched every time.

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