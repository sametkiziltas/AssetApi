FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["user.api/src/user.api/user.api.csproj", "user.api/src/user.api/"]
RUN dotnet restore "user.api/src/user.api/user.api.csproj"
COPY . .
WORKDIR "/src/user.api/src/user.api"
RUN dotnet build "user.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "user.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "user.api.dll"]
