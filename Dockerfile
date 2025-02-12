# Use the ASP.NET base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base 
WORKDIR /app

# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["Mis.Services.Customer.Api/Mis.Services.Customer.Api.csproj", "./Mis.Services.Customer.Api/"]
RUN dotnet restore "./Mis.Services.Customer.Api/Mis.Services.Customer.Api.csproj"

# Copy the entire project and build
COPY . .
WORKDIR "/src/Mis.Services.Customer.Api/."
RUN dotnet build "Mis.Services.Customer.Api.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Mis.Services.Customer.Api.csproj" -c Release -o /app/publish

# Use the base image for the final stage
FROM base AS final
WORKDIR /app

# Copy the published output from the publish stage
COPY --from=publish /app/publish .
# Copy the appsettings file for specified environment
ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
# Copy the appsettings file for shrivirajQA environment
COPY ["Mis.Services.Customer.Api/appsettings.${ASPNETCORE_ENVIRONMENT}.json", "./appsettings.json"]

# Set the ASPNETCORE_ENVIRONMENT environment variable
#ENV ASPNETCORE_ENVIRONMENT=nileshQA

# Set the entry point
ENTRYPOINT ["dotnet", "Mis.Services.Customer.Api.dll"]
