# Etapa 1: Construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define o diretório de trabalho
WORKDIR ./


COPY desafio-back.sln ./
COPY desafio-back.api/*.csproj desafio-back.api/
COPY desafio-back.infrastructure/*.csproj desafio-back.infrastructure/
COPY desafio-back.domain/*.csproj desafio-back.domain/
RUN dotnet restore

COPY desafio-back.api/. desafio-back.api/
COPY desafio-back.infrastructure/. desafio-back.infrastructure/
COPY desafio-back.domain/. desafio-back.domain/

WORKDIR ./desafio-back.api
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "desafio-back.api.dll"]
