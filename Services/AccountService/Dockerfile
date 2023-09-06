# Use the base image for ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

# Expose port 443 (HTTPS)
EXPOSE 443

# FROM instructions for build, publish, and final stages remain the same

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AccountService.csproj", "./"]
RUN dotnet restore "AccountService.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "AccountService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccountService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set environment variable for HTTPS
ENV ASPNETCORE_URLS=https://+:443

# Modify the entry point to use HTTPS on port 443
ENTRYPOINT ["dotnet", "AccountService.dll"]
