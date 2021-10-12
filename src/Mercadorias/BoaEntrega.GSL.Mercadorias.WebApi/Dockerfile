# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . .
WORKDIR /build/src/Mercadorias/BoaEntrega.GSL.Mercadorias.WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Stage 2
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
EXPOSE 9002
COPY --from=build /app .
ENTRYPOINT ["dotnet", "BoaEntrega.GSL.Mercadorias.WebApi.dll"]