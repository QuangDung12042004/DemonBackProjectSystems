# Sử dụng .NET 9 SDK để build code
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy toàn bộ code vào và restore thư viện
COPY . .
RUN dotnet restore "DemonBackProjectSystems.Api/DemonBackProjectSystems.Api.csproj"

# Build ra file chạy
RUN dotnet publish "DemonBackProjectSystems.Api/DemonBackProjectSystems.Api.csproj" -c Release -o /app/publish

# Môi trường chạy siêu nhẹ (chỉ có Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Mở port và chạy app
EXPOSE 8080
ENTRYPOINT ["dotnet", "DemonBackProjectSystems.Api.dll"]