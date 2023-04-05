#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SchmersalGlobalTask.API/SchmersalGlobalTask.API.csproj", "SchmersalGlobalTask.API/"]
COPY ["SchmersalGlobalTask.Contracts/SchmersalGlobalTask.Contracts.csproj", "SchmersalGlobalTask.Contracts/"]
COPY ["SchmersalGlobalTask.Infrastructure/SchmersalGlobalTask.Infrastructure.csproj", "SchmersalGlobalTask.Infrastructure/"]
COPY ["SchmersalGlobalTask.Domain/SchmersalGlobalTask.Domain.csproj", "SchmersalGlobalTask.Domain/"]
COPY ["SchmersalGlobalTask.Services.Abstraction/SchmersalGlobalTask.Services.Abstraction.csproj", "SchmersalGlobalTask.Services.Abstraction/"]
COPY ["SchmersalGlobalTask.Services/SchmersalGlobalTask.Services.csproj", "SchmersalGlobalTask.Services/"]
RUN dotnet restore "SchmersalGlobalTask.API/SchmersalGlobalTask.API.csproj"
COPY . .
WORKDIR "/src/SchmersalGlobalTask.API"
RUN dotnet build "SchmersalGlobalTask.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchmersalGlobalTask.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchmersalGlobalTask.API.dll"]