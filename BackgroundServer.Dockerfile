#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BackgroundServer.Client.ConsoleApplication/BackgroundServer.Client.ConsoleApplication.csproj", "BackgroundServer.Client.ConsoleApplication/"]
COPY ["BackgroundServer.Hangfire/BackgroundServer.Hangfire.csproj", "BackgroundServer.Hangfire/"]
COPY ["BackgroundServer.Abstractions/BackgroundServer.Abstractions.csproj", "BackgroundServer.Abstractions/"]
RUN dotnet restore "BackgroundServer.Client.ConsoleApplication/BackgroundServer.Client.ConsoleApplication.csproj"
COPY . .
WORKDIR "/src/BackgroundServer.Client.ConsoleApplication"
RUN dotnet build "BackgroundServer.Client.ConsoleApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackgroundServer.Client.ConsoleApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh