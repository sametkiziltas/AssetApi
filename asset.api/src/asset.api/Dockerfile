FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["asset.api/src/asset.api/asset.api.csproj", "asset.api/src/asset.api/"]
RUN dotnet restore "asset.api/src/asset.api/asset.api.csproj"
COPY . .
WORKDIR "/src/asset.api/src/asset.api"
RUN dotnet build "asset.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "asset.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "asset.api.dll"]
