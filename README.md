# Forge
An API for the components that are used to build quadcopters

## Prerequisites
- [Git](https://git-scm.com/)
- [.Net Core 2.0 SDK](https://www.microsoft.com/net/download/core)
- [NodeJS](https://nodejs.org/en/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Getting Started
1. Clone this directory with `https://github.com/n7down/Forge.git`
2. Run `docker run -it --name mongo -p 27017:27017 -p 28017:28017 -d mongo` to start the mongo database
3. Run `npm install`
4. Run `dotnet build`
5. Run `dotnet run` to run in production and `ASPNETCORE_ENVIRONMENT=Development dotnet watch run` to run in development
6. Website will be running on `localhost:5000`

## Running with Docker Compose
1. Run `docker-compose up`
2. Website will be running on `localhost:8080`
