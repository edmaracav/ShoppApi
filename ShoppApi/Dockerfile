FROM mcr.microsoft.com/dotnet/sdk:3.1 AS Build-Container

WORKDIR /Build

COPY . .

RUN dotnet build -c Release

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS Server-Container

COPY --from=Build-Container /Build/bin/Release/netcoreapp3.1/ App/

WORKDIR /App

ENTRYPOINT ["dotnet", "ShoppApi.dll"]