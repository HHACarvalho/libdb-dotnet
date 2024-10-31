#!/bin/bash

# Build the docker image
docker build -t libdb-dotnet-image:latest ./

# Stop and remove any existing docker container
docker stop libdb-dotnet-container && docker rm libdb-dotnet-container

# Create and run the docker container
docker run -d -p 5000:8080 --network libdb-network --name libdb-dotnet-container libdb-dotnet-image:latest