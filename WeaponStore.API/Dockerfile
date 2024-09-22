FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WeaponStore.API/WeaponStore.API.csproj", "WeaponStore.API/"]
COPY ["WeaponStore.Application/WeaponStore.Application.csproj", "WeaponStore.Application/"]
COPY ["WeaponStore.Core/WeaponStore.Core.csproj", "WeaponStore.Core/"]
COPY ["WeaponStore.DataAccess/WeaponStore.DataAccess.csproj", "WeaponStore.DataAccess/"]
RUN dotnet restore "WeaponStore.API/WeaponStore.API.csproj"
COPY . .
WORKDIR "/src/WeaponStore.API"
RUN dotnet build "WeaponStore.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WeaponStore.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeaponStore.API.dll"]
