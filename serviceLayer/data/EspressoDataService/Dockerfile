# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official ASP.NET Core SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EspressoDataService.csproj", "EspressoDataService/"]
RUN dotnet restore "EspressoDataService/EspressoDataService.csproj"
COPY . "EspressoDataService/"
WORKDIR "/src/EspressoDataService"
RUN dotnet build "EspressoDataService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EspressoDataService.csproj" -c Release -o /app/publish

# Use the base image to run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EspressoDataService.dll"]