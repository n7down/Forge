# Drone Forge
An API for the components that are used to build quadcopters

## Prerequisites
- [Go](https://golang.org/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Getting Started
1. Clone this directory with `https://github.com/n7down/Forge.git`
2. Run `docker run -it --name mongo -p 27017:27017 -p 28017:28017 -d mongo` to start the mongo database
3. Run `go build` in the src directory
4. Run `go run main.go` in the src directory