
FROM golang:1.20 AS builder

WORKDIR /app

COPY go.mod go.sum ./

RUN go mod download

COPY . .

RUN CGO_ENABLED=0 go build -ldflags "-w -s -extldflags '-static'" -o build/fizzbuzz

FROM gcr.io/distroless/static:latest

COPY --from=builder /app/build/fizzbuzz /
COPY --from=builder /app/templates/index.html /templates/

EXPOSE 8080

CMD ["./fizzbuzz", "serve"]
