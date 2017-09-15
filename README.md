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
4. Run `dotnet run` 
5. Website will be running on `localhost:5000`

## Running from Docker
1. Install [Docker](https://docs.docker.com/engine/installation/)
2. Run `docker run -it --name mongo 27017:27017 -p 28017:28017 -d mongo` to start the mongo database
3. Run `docker build -t forge .` from the root directory of this project
4. Run `docker run -d -p 8080:80 --name forge forge` to start the container
5. Website will be running on `localhost:8080`

## Possible Names
- QuadAPI
- QCAPI (quad components api)
- Quad Forge
- Quad Forgery
- Quad Workbench
- Quadcopter Workbench

## Todo
- [ ] Connect with [mongo database](http://www.qappdesign.com/using-mongodb-with-net-core-webapi/) to Battery
- [ ] Get this to work with Docker
- [ ] Checkout [slate](https://github.com/lord/slate) for api documentation

## Notes
- [Hosting in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/hosting?tabs=aspnetcore2x)