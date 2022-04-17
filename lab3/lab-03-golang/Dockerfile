FROM golang:1.18.1
COPY . /myApp
WORKDIR /myApp
RUN CGO_ENABLED=0 go build -o build/fizzbuzz

FROM gcr.io/distroless/static-debian11  
WORKDIR /myDistroless/
COPY --from=0 /myApp/templates /myDistroless/templates
COPY --from=0 /myApp/build/fizzbuzz /myDistroless/build/fizzbuzz
CMD [ "./build/fizzbuzz", "serve" ]