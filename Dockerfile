# Use the official .NET SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the solution file
COPY *.sln ./

# Copy and restore dependencies for each project
COPY EmployeeAPI.Data/EmployeeAPI.Data.csproj EmployeeAPI.Data/
COPY EmployeeAPI.Services/EmployeeAPI.Services.csproj EmployeeAPI.Services/
COPY EmployeeAPI/EmployeeAPI.csproj EmployeeAPI/

# Restore the dependencies for the entire solution
RUN dotnet restore

# Copy the entire source code
COPY . .

# Build the project(s)
RUN dotnet build -c Release -o /app/build

# Publish the project(s)
RUN dotnet publish -c Release -o /app/publish

# Use the official .NET runtime image for the runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory for the runtime
WORKDIR /app

# Copy the published files from the build stage
COPY --from=build /app/publish .

# Expose the port your application will run on
EXPOSE 80

# Define the entry point for the container
ENTRYPOINT ["dotnet", "EmployeeAPI.dll"]
