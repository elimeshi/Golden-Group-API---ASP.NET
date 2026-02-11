FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["GoldenGroupAPI/GoldenGroupAPI.csproj", "GoldenGroupAPI/"]
RUN dotnet restore "GoldenGroupAPI/GoldenGroupAPI.csproj"
COPY . .
WORKDIR "/src/GoldenGroupAPI"
RUN dotnet build "GoldenGroupAPI.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "GoldenGroupAPI.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GoldenGroupAPI.dll"]
