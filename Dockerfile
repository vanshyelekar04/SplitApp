# Use the ASP.NET runtime image as the base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the full project into the container
COPY . .

# Restore dependencies and build
RUN dotnet restore ./WebAPI/WebAPI.csproj
RUN dotnet build ./WebAPI/WebAPI.csproj -c Release -o /app/build
RUN dotnet publish ./WebAPI/WebAPI.csproj -c Release -o /app/publish

# Use the base image to run the app
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "WebAPI.dll"]
