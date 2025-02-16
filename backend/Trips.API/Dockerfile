FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src

COPY ["Trips.API/Trips.API.csproj", "Trips.API/"]
COPY ["Trips.Persistence/Trips.Persistence.csproj", "Trips.Persistence/"]
COPY ["Trips.Domain/Trips.Domain.csproj", "Trips.Domain/"]

RUN dotnet restore "./Trips.API/Trips.API.csproj"

COPY . .

WORKDIR "/src/Trips.API"
RUN dotnet build "./Trips.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "./Trips.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Trips.API.dll"]