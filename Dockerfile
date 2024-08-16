FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["EmployeeAPI/EmployeeAPI.csproj", "EmployeeAPI/"]
COPY ["EmployeeAPI.Data/EmployeeAPI.Data.csproj", "EmployeeAPI.Data/"]
COPY ["EmployeeAPI.Services/EmployeeAPI.Services.csproj", "EmployeeAPI.Services/"]

RUN dotnet restore "EmployeeAPI/EmployeeAPI.csproj"
COPY . .

RUN dotnet build "EmployeeAPI/EmployeeAPI.csproj" -c $BUILD_CONFIGURATION  -o /app/build
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EmployeeAPI/EmployeeAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeAPI.dll"]