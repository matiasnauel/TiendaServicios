#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TiendaServicio.Api.CarritoCompra/TiendaServicio.Api.CarritoCompra.csproj", "TiendaServicio.Api.CarritoCompra/"]
RUN dotnet restore "TiendaServicio.Api.CarritoCompra/TiendaServicio.Api.CarritoCompra.csproj"
COPY . .
WORKDIR "/src/TiendaServicio.Api.CarritoCompra"
RUN dotnet build "TiendaServicio.Api.CarritoCompra.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TiendaServicio.Api.CarritoCompra.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TiendaServicio.Api.CarritoCompra.dll"]
