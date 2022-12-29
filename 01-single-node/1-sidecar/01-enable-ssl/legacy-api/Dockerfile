FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.3 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/core/sdk:2.2.105 AS build
WORKDIR /src
COPY ["legacy-api.csproj", "legacy-api/"]
RUN dotnet restore "legacy-api/legacy-api.csproj"
COPY . legacy-api/
WORKDIR "/src/legacy-api"
RUN dotnet build "legacy-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "legacy-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "legacy-api.dll"]
