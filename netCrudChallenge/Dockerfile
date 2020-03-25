FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["netCrudChallenge/netCrudChallenge.csproj", "netCrudChallenge/"]
RUN dotnet restore "netCrudChallenge/netCrudChallenge.csproj"
COPY . .
WORKDIR "/src/netCrudChallenge"
RUN dotnet build "netCrudChallenge.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "netCrudChallenge.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "netCrudChallenge.dll"]