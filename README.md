# Drone Forge
An API for the components that are used to build quadcopters

## Prerequisites
- [Go](https://golang.org/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [Mockgen](https://github.com/golang/mock/mockgen)

## Getting Started
1. Clone this directory with `https://github.com/n7down/Forge.git`
2. Run `docker-compose up` to start the service

## Generate Mocked Data
1. Get mockgen `go get github.com/golang/mock/mockgen`
2. Run `go generate ./...` from the projects root directory to generate mocks
