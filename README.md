# Rock Paper Scissors Lizard Spock Game Service

## Project Overview

This project is an implementation of the Rock Paper Scissors Lizard Spock game as a Service using ASP.NET Core. This project was developed as part of a code challenge for Billups company.
## Technologies and Requirements

### Technologies Used
- **ASP.NET Core 8**
- **Entity Framework Core**
- **Postgres**

### Requirements
- .NET 8 SDK
- Postgres server

### How to Run the Project

There are two ways to run the project: using Docker Compose or on a local machine.

#### Using Docker Compose

- Run `docker-compose up --build`
- The API will be accessible at http://localhost:8080/.
- API documentation http://localhost:8080/swagger/index.html.

#### Running on a Local Machine

- Ensure PostgreSQL is installed and running.
- Update the connection string in appsettings.json to point to your PostgreSQL database.
- Run `dotnet ef database update`
- Build and Run the Project
  - `dotnet build`
  - `dotnet run`
- The API and documentation will be accessible at https://localhost:7191/swagger/index.html

## Comments Regarding the Implementation

### Implemented Features

#### Required Features
- **GET /api/game/choices**: Retrieve all possible choices.
- **GET /api/game/choice**: Retrieve a random choice for the computer opponent.
- **POST /api/game/play**: Play a round against the computer opponent.

#### Additional Features
- Integration Tests
- Unit Tests for Game Logic
- Docker compose

#### Design Decisions
- The backend service uses a single project to avoid overengineering. The logic was straightforward, and I purposely did not follow a clean architecture approach to split it into multiple projects or add additional layers of abstraction.
- I considered using Vertical Slices architecture with handlers, but that also seemed excessive at this point. If we were to add more features, I would then split the code per feature (for example, if we add multiplayer support).

### What could be improved
- TODO
