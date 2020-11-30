FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS Build

WORKDIR /Build

COPY * *

WORKDIR /Build/ShoppApi

RUN dotnet restore

RUN dotnet build

FROM ubuntu:18.04 AS Server

COPY --from=nginx:latest bin/Release/netcoreapp3.1/publish/ App/

WORKDIR /App

ENTRYPOINT ["dotnet", "ShoppApi.dll"]