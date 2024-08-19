## Requirements

- If you're running on visual studio you will need the Visual Studio 2022 Version 17.8.5 or High.
- .NET 8
- The SDK and tools can be downloaded from https://dotnet.microsoft.com/en-us/download.
- Docker
- Linux or Windows with Hyper-V enable

## Technologies implemented:

- .NET 8.0
- .NET Native DI
- FluentValidator
- MediatR
- XUnit
- Swagger UI with JWT support
- Docker

## Instructions (using docker)
To run this application you just have to execute the "docker-compose build" command on base directory of the project `src`and then execute "docker-compose up -d". These commands wil run the application and automatically. After running the web api is accessed by http://localhost:8888/swagger and web app by http://localhost:8888/productionplan

## Other instructions

To run this application you just have to execute the "run-script.bat" on base directory of the project. This script will run the dotnet cli commands to run the application. After running the web api is accessed by https://localhost:8888/swagger

Also, you can run the solution open cmd on solution directory `src` and execute the following commands:

- dotnet clean
- dotnet restore
- dotnet build
- dotnet run --project .\Powerplant.Api