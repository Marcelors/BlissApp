FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS restore
WORKDIR /app

COPY ./src ./src
WORKDIR /app/src/Api
RUN dotnet restore Api.csproj

FROM restore AS publish
WORKDIR /app/src/Api
RUN dotnet publish Api.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS runtime
WORKDIR /app
EXPOSE 5000
COPY --from=publish /out .
ENTRYPOINT ["dotnet", "Api.dll"]