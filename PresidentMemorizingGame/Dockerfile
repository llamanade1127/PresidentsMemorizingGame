FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PresidentMemorizingGame/PresidentMemorizingGame.csproj", "PresidentMemorizingGame/"]
RUN dotnet restore "PresidentMemorizingGame/PresidentMemorizingGame.csproj"
COPY . .
WORKDIR "/src/PresidentMemorizingGame"
RUN dotnet build "PresidentMemorizingGame.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PresidentMemorizingGame.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PresidentMemorizingGame.dll"]
