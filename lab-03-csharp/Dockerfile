FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

COPY AppWeather/ ./AppWeather/

# add dependencies
WORKDIR /source/AppWeather
RUN dotnet restore

RUN dotnet publish AppWeather.csproj -c Release -o /app/out


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/out ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "AppWeather.dll"]
