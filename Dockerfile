FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BookStore.API/BookStore.API.csproj", "BookStore.API/"]
COPY ["BookStore.Core/BookStore.Core.csproj", "BookStore.Core/"]
COPY ["BookStore.Application/BookStore.Application.csproj", "BookStore.Application/"]
COPY ["BookStore.Infrastructure/BookStore.Infrastructure.csproj", "BookStore.Infrastructure/"]
RUN dotnet restore "BookStore.API/BookStore.API.csproj"
COPY . .
WORKDIR "/src/BookStore.API"
RUN dotnet build "./BookStore.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookStore.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStore.API.dll"]