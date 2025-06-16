# Use the ASP.NET 8.0 runtime as the base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET 8.0 SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore ./WebAPI/WebAPI.csproj
RUN dotnet build ./WebAPI/WebAPI.csproj -c Release -o /app/build
RUN dotnet publish ./WebAPI/WebAPI.csproj -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "WebAPI.dll"]
