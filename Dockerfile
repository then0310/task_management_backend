# Use official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy all files and build
COPY . ./
RUN dotnet publish -c Release -o /out

# Use official ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
EXPOSE 8080
EXPOSE 80
EXPOSE 443
CMD ["dotnet", "task_management_backend.dll"]