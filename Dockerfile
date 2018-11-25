FROM golang:1.11-alpine as builder
RUN apk update && apk add git && apk add ca-certificates
RUN adduser -D -g '' appuser
COPY . $GOPATH/src/github.com/n7down/Forge/
WORKDIR $GOPATH/src/github.com/n7down/Forge/
RUN go get -d -v
RUN CGO_ENABLED=0 GOOS=linux GOARCH=amd64 go build -a -installsuffix cgo -ldflags="-w -s" -o /go/bin/Forge

FROM scratch
COPY --from=builder /etc/ssl/certs/ca-certificates.crt /etc/ssl/certs/
COPY --from=builder /etc/passwd /etc/passwd
COPY --from=builder /go/bin/Forge /go/bin/Forge
USER appuser

ENTRYPOINT ["/go/bin/Forge"]