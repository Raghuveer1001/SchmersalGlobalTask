# Build Stage
from mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . . 
RUN dotnet restore "./SchmersalGlobalTask.API/SchmersalGlobalTask.API.csproj" --disable-parallel
RUN dotnet publish "./SchmersalGlobalTask.API/SchmersalGlobalTask.API.csproj" -c relelase -o /app --no-restore

# Serve Stage
from mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY  --from=build /app  ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "SchmersalGlobalTask.API.dll"]