FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Trips.API/Trips.API.csproj", "Trips.API/"]
COPY ["Trips.Persistence/Trips.Persistence.csproj", "Trips.Persistence/"]
COPY ["Trips.Domain/Trips.Domain.csproj", "Trips.Domain/"]
COPY ["Trips.Infrastructure/Trips.Infrastructure.csproj", "Trips.Infrastructure/"]
COPY ["Trips.Application/Trips.Application.csproj", "Trips.Application/"]
RUN dotnet restore "./Trips.API/Trips.API.csproj"

COPY . .
WORKDIR "/src/Trips.API"
RUN dotnet publish "./Trips.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Trips.API.dll"]