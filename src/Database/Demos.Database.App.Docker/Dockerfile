FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY src/Database/Demos.Database/Demos.Database.csproj src/Database/Demos.Database/
RUN dotnet restore src/Database/Demos.Database/Demos.Database.csproj

COPY src/Framework/Demos.Framework.Core/Demos.Framework.Core.csproj src/Framework/Demos.Framework.Core/
RUN dotnet restore src/Framework/Demos.Framework.Core/Demos.Framework.Core.csproj

COPY src/Database/Demos.Database.App.Docker/Demos.Database.App.Docker.csproj src/Database/Demos.Database.App.Docker/
RUN dotnet restore src/Database/Demos.Database.App.Docker/Demos.Database.App.Docker.csproj

COPY . .
RUN dotnet publish src/Database/Demos.Database.App.Docker -c Release -o out
 
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final-env
WORKDIR /app

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Demos.Database.App.Docker.dll"]
