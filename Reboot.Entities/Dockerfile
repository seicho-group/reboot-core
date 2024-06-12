FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8002
ENV ASPNETCORE_HTTP_PORTS 8001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Reboot.Entities/Reboot.Entities.csproj", "Reboot.Entities/"]
COPY ["Reboot.DB/Reboot.DB.csproj", "Reboot.DB/"]
RUN dotnet restore "Reboot.Entities/Reboot.Entities.csproj"
COPY . .
WORKDIR "/src/Reboot.Entities"
RUN dotnet build "Reboot.Entities.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Reboot.Entities.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reboot.Entities.dll"]
