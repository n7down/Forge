# Drone Forge
An API for the components that are used to build quadcopters

## Prerequisites
- [Go](https://golang.org/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Getting Started
1. Clone this directory with `https://github.com/n7down/Forge.git`
2. Run `docker build -t forge-db dockerfiles/db` to start the postgres database
3. Run `go build src/main.go`
4. Run `go run src/main.go`