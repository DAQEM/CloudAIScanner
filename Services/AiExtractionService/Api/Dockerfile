FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/AiExtractionService/Api/Api.csproj", "./"]
COPY ["Services/AiExtractionService/Extraction/Extraction.csproj", "/Extraction/"]
COPY ["Services/AiExtractionService/Logic/Logic.csproj", "/Logic/"]

RUN dotnet restore "Api.csproj"
RUN dotnet restore "/Extraction/Extraction.csproj"
RUN dotnet restore "/Logic/Logic.csproj"

COPY ["Services/AiExtractionService/Api/", "./"]
COPY ["Services/AiExtractionService/Extraction/", "/Extraction"]
COPY ["Services/AiExtractionService/Logic/", "/Logic"]

WORKDIR "/src/"

RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
