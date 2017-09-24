[![Build Status](https://travis-ci.org/lreimer/cloud-native-basta17.svg?branch=master)](https://https://travis-ci.org/lreimer/cloud-native-basta17)
[![MIT License Status](https://img.shields.io/badge/license-MIT%20License-blue.svg)](https://github.com/lreimer/enterprise-spock/blob/master/LICENSE)

# Cloud-native .NET Microservices Showcase BASTA! 2017

The Cloud Native .NET Core + Steeltoe OSS + Kubernetes showcases for the BASTA! 2017 conference.

## Prerequisites

In order to build and run this showcase you need to have a couple of things installed:

- .NET Core SDK installed locally

## Building

```bash
$ dotnet restore
$ dotnet build
```

## Running

```bash
$ dotnet run

$ http GET localhost:5000/api/hello
$ http GET localhost:5000/admin/health
$ http GET localhost:5000/admin/info
```

## Containerizing

```bash
$ dotnet publish -c Release -o out

$ docker build -t cloud-native-basta17 .
$ docker run -it -p 5000:5000 cloud-native-basta17
```

Alternatively, you may use Docker Compose to build and run the microservice in one command:
```bash
$ docker-compose up --build
```

## References

- https://basta.net/microservices-services/cloud-native-net-microservices-mit-kubernetes/
- http://steeltoe.io/docs/
- https://github.com/SteeltoeOSS/Samples

## License

This software is provided under the MIT open source license, read the `LICENSE` file for details.
