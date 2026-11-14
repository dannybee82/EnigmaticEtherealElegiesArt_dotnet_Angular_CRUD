FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build  
WORKDIR /src  
  
# Copy solution/project files first (for layer caching)  
COPY ["EnigmaticEtherealElegiesArtWebApi/EnigmaticEtherealElegiesArtWebApi.csproj", "EnigmaticEtherealElegiesArtWebApi/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
  
# Restore (downloads from NuGet.org — no Windows paths involved)  
RUN dotnet restore ./EnigmaticEtherealElegiesArtWebApi/EnigmaticEtherealElegiesArtWebApi.csproj  
  
# Copy the rest of the source  
COPY . .  
  
# Publish (--no-restore is safe now because restore already ran above)  
RUN dotnet publish ./EnigmaticEtherealElegiesArtWebApi/EnigmaticEtherealElegiesArtWebApi.csproj \  
    -c Release \  
    -o /app/publish \  
    --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5001

ENTRYPOINT ["dotnet", "EnigmaticEtherealElegiesArtWebApi.dll"]