# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY PruebaTecnicaCarsalesBackEnd/PruebaTecnicaCarsalesBackEnd.csproj PruebaTecnicaCarsalesBackEnd/
RUN dotnet restore PruebaTecnicaCarsalesBackEnd/PruebaTecnicaCarsalesBackEnd.csproj

COPY . .
WORKDIR /src/PruebaTecnicaCarsalesBackEnd
RUN dotnet build PruebaTecnicaCarsalesBackEnd.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish PruebaTecnicaCarsalesBackEnd.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5001

ENTRYPOINT ["dotnet", "PruebaTecnicaCarsalesBackEnd.dll"]