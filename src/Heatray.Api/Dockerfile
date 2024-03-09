#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Heatray.Api/Heatray.Api.csproj", "src/Heatray.Api/"]
COPY ["src/Heatray.Application/Heatray.Application.csproj", "src/Heatray.Application/"]
COPY ["src/Heatray.Infrastructure/Heatray.Infrastructure.csproj", "src/Heatray.Infrastructure/"]
RUN dotnet restore "./src/Heatray.Api/./Heatray.Api.csproj"
COPY . .
WORKDIR "/src/src/Heatray.Api"
RUN dotnet build "./Heatray.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Heatray.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Heatray.Api.dll", "--urls", "http://0.0.0.0:80"]