# Forge
An API for the components that are used to build quadcopters

## Prerequisites
- [Git](https://git-scm.com/)
- [.Net Core 2.0 SDK](https://www.microsoft.com/net/download/core)
- [NodeJS](https://nodejs.org/en/)

## Getting Started
1. Clone this directory with `https://github.com/n7down/Forge.git`
2. Run `npm install` from given directory
3. Run `dotnet run` 
4. Website will be running on `localhost:5000`

## Running from Docker
1. Install [Docker](https://docs.docker.com/engine/installation/)
2. Run `docker build -t forge .` from the root directory of this project
3. Run `docker run -d -p 8080:80 --name forge forge` to start the container
4. Website will be running on `localhost:8080`

## Possible Names
- QuadAPI
- QCAPI (quad components api)
- Quad Forge
- Quad Forgery
- Quad Workbench
- Quadcopter Workbench

## Todo
- [ ] Get this to work with Docker
- [ ] Checkout [slate](https://github.com/lord/slate) for api documentation