#!/bin/bash

# Build the docker image
docker build -t libdb-dotnet-image:latest ./

# Stop and remove any existing docker container
docker stop libdb-dotnet-container && docker rm libdb-dotnet-container

# Create and run the docker container
docker run -d -p 8080:8080 --name libdb-dotnet-container -e ENVIRONMENT=PRODUCTION libdb-dotnet-image:latest
