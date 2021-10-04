# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . . 
WORKDIR /build/src/BoaEntrega.GSL.ApiGateway
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Stage 2
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
EXPOSE 9000
COPY --from=build /app .
ENTRYPOINT ["dotnet", "BoaEntrega.GSL.ApiGateway.dll"]