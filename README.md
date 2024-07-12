# Rock Paper Scissors Lizard Spock Game Service

## Project Overview

This project is an implementation of the Rock Paper Scissors Lizard Spock game as a Service using ASP.NET Core. This project was developed as part of a code challenge for Billups company.
## Technologies and Requirements

### Technologies Used
- **ASP.NET Core 8**
- **Entity Framework Core**
- **Postgres**
- **Next.js**

### Requirements
- .NET 8 SDK
- Postgres server
- Node.js >= 20.x

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
- API routes can be accessed on `/api/game` and `/api/scoreboard`.
- The API and documentation will be accessible at https://localhost:7191/swagger/index.html

#### To run the Client app
Please note that Client app has only rudimentary setup due to time constraints.
- Run the development server `npm run dev`.
- Open http://localhost:3000 with your browser.
- Depending on how the API is running, you may need to change the API_BASE_URL in config/api.ts. If you are using Docker, it runs on port 8080; otherwise, it runs on port 7191.

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
- Scoreboard
    - **GET api/Scoreboard/top-players**: Get the top players based on their win streaks with pagination.
    - **DELETE api/Scoreboard/reset**: Resets the scoreboard.

#### Design Decisions
- The backend service uses a single project to avoid overengineering. The logic was straightforward, and I purposely did not follow a clean architecture approach to split it into multiple projects or add additional layers of abstraction.
- I considered using Vertical Slices architecture with handlers, but that also seemed excessive at this point. If we were to add more features, I would then split the code per feature (for example, if we add multiplayer support).
- The client application is written using Next.js and utilizes other opinionated libraries such as Chakra UI. This choice was made due to time constraints. The client application is not containerized and is designed to work alongside the API service.

### What could be improved
- Fetching the computer's choice from the random number service could be more resilient and fail gracefully.
- The game result (e.g., "win") could be reused to avoid hardcoding.
- Add and improve unit and integration tests for additional features.
- Containerize Client App
- Fetch available choices only once per app load instead each time Game component is opened
