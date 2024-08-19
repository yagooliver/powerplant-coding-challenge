FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY ["Powerplant.Api/Powerplant.Api.csproj", "Powerplant.Api/"]
COPY ["Powerplant.Domain/Powerplant.Domain.csproj", "Powerplant.Domain/"]
COPY ["Powerplant.Application/Powerplant.Application.csproj", "Powerplant.Application/"]
RUN dotnet restore "./Powerplant.Api/Powerplant.Api.csproj"
# Copy all other files
COPY . .

WORKDIR /app
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /publish .

ENV ASPNETCORE_URLS=http://+:8888

# Run the application
ENTRYPOINT ["dotnet", "Powerplant.Api.dll"]