FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Fit4TheFloor/Fit4TheFloor.csproj", "Fit4TheFloor/"]
RUN dotnet restore "Fit4TheFloor/Fit4TheFloor.csproj"
COPY . .
WORKDIR "/src/Fit4TheFloor"
RUN dotnet build "Fit4TheFloor.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Fit4TheFloor.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Fit4TheFloor.dll"]