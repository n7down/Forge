FROM golang:1.11

WORKDIR /go/src/github.com/n7down/Forge
COPY . .

RUN go get -d -v ./...
RUN go install -v ./...

CMD ["app"]