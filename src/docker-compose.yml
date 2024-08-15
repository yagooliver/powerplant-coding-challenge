version: '3.8'

services:
  powerplant.api:
    image: powerplantapi:latest
    build:
      context: .
      dockerfile: ./Dockerfile
    ports:
      - "8888:8888"
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
