# Forge
An API for the components that are used to build quadcopters

## Prerequisites
- [Git](https://git-scm.com/)
- [.Net Core 2.0 SDK](https://www.microsoft.com/net/download/core)
- [NodeJS](https://nodejs.org/en/)
- [Docker](https://www.docker.com/)

## Getting Started
1. Clone this directory with `https://github.com/n7down/Forge.git`
2. Run `docker run -it --name mongo 27017:27017 -p 28017:28017 -d mongo` to start the mongo database
3. Run `npm install` from given directory
4. Run `dotnet build`
5. Run `dotnet run` to run in production and `ASPNETCORE_ENVIRONMENT=Development dotnet watch run` to run in development
6. Website will be running on `localhost:5000`

## Running from Docker
1. Run `docker run -it --name mongo 27017:27017 -p 28017:28017 -d mongo` to start the mongo database
2. Run `docker build -t forge .` from the root directory of this project
3. Run `docker run -d -p 8080:80 --name forge forge` to start the container
4. Website will be running on `localhost:8080`
