FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Socialite.Api.Web/Socialite.Api.Web.csproj", "Socialite.Api.Web/"]
COPY ["Socialite.Api.Contracts/Socialite.Api.Contracts.csproj", "Socialite.Api.Contracts/"]
COPY ["Socialite.Api.Db/Socialite.Api.Db.csproj", "Socialite.Api.Db/"]
COPY ["Socialite.Api.Core/Socialite.Api.Core.csproj", "Socialite.Api.Core/"]
COPY ["Socialite.Api.S3/Socialite.Api.S3.csproj", "Socialite.Api.S3/"]
COPY ["Socialite.Api.SignalR/Socialite.Api.SignalR.csproj", "Socialite.Api.SignalR/"]
RUN dotnet restore "Socialite.Api.Web/Socialite.Api.Web.csproj"
COPY . .
WORKDIR "/src/Socialite.Api.Web"
RUN dotnet build "Socialite.Api.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Socialite.Api.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Socialite.Api.Web.dll"]
