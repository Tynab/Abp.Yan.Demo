#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/Yan.Demo.Web/Yan.Demo.Web.csproj", "src/Yan.Demo.Web/"]
COPY ["src/Yan.Demo.Application/Yan.Demo.Application.csproj", "src/Yan.Demo.Application/"]
COPY ["src/Yan.Demo.Domain/Yan.Demo.Domain.csproj", "src/Yan.Demo.Domain/"]
COPY ["src/Yan.Demo.Domain.Shared/Yan.Demo.Domain.Shared.csproj", "src/Yan.Demo.Domain.Shared/"]
COPY ["src/Yan.Demo.Application.Contracts/Yan.Demo.Application.Contracts.csproj", "src/Yan.Demo.Application.Contracts/"]
COPY ["src/Yan.Demo.HttpApi/Yan.Demo.HttpApi.csproj", "src/Yan.Demo.HttpApi/"]
COPY ["src/Yan.Demo.EntityFrameworkCore/Yan.Demo.EntityFrameworkCore.csproj", "src/Yan.Demo.EntityFrameworkCore/"]
RUN dotnet restore "src/Yan.Demo.Web/Yan.Demo.Web.csproj"
COPY . .
WORKDIR "/src/src/Yan.Demo.Web"
RUN dotnet build "Yan.Demo.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Yan.Demo.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yan.Demo.Web.dll"]