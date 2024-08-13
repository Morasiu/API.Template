#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Template.Api/Template.Api.csproj", "Template.Api/"]
COPY ["Template.Application/Template.Application.csproj", "Template.Application/"]
COPY ["Template.Persistence/Template.Persistence.csproj", "Template.Persistence/"]
COPY ["Template.Shared/Template.Shared.csproj", "Template.Shared/"]
COPY ["Template.Infrastructure/Template.Infrastructure.csproj", "Template.Infrastructure/"]
RUN dotnet restore "Template.Api/Template.Api.csproj"
COPY . .
WORKDIR "/src/Template.Api"
RUN dotnet build "Template.Api.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Template.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ARG ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT ${ENVIRONMENT}
ENTRYPOINT ["dotnet", "Template.Api.dll"]